using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using GlobalHakathon.ViewModel;

namespace GlobalHackathon
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum authenticationType
    {
        Basic,
        NTLM
    }

    public enum autheticationTechnique
    {
        RollYourOwn,
        NetworkCredential
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public authenticationType authType { get; set; }
        public autheticationTechnique authTech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string postJSON { get; set; }

        BaseViewModel baseViewModel;
        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
            baseViewModel = BaseViewModel.GetViewModelObject();
        }
        

        public string makeRequest()
        {
            string strResponseValue = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();



            String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
            //String authHeaer = "utcO6CfVxiJOSOBMabxJ0FF9";
            request.Headers.Add("Authorization", "Basic " + authHeaer);


            if (request.Method == "POST" && postJSON != string.Empty)
            {
                request.ContentType = "application/json";
                using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
                {
                    swJSONPayload.Write(postJSON);

                    swJSONPayload.Close();
                }
            }


            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            return strResponseValue;
        }

    }
}
