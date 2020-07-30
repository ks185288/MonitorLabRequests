using GlobalHackathon;
using GlobalHakathon.Model;
using GlobalHakathon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GlobalHakathon.ViewModel
{
    public delegate void Notify(Window hnd, string str, bool p);
    class BaseViewModel : INotifyPropertyChanged
    {

        LoginModel userCredentials;
        public bool _isAdmin;
        public event Notify Process;
        public bool ISAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged("ISAdmin");
            }
        }
        RequestDetailsModel reuest;

        static BaseViewModel viewModelObject = null;

        public void CreateRequestObject()
        {
            reuest = new RequestDetailsModel();
        }

        public void CreatUserCredentialObject()
        {
            userCredentials = new LoginModel();
        }

        protected virtual void onProcess(Window hnd, string str, bool p)
        {
            Process?.Invoke(hnd, str, p);
        }

        public string SearchReuest(string id)
        {
            PopUpWindow wnd = new PopUpWindow();
            onProcess(wnd, "Loading Data Please wait....", true);
            string status="";

            RestClient rClient = new RestClient();
            rClient.endPoint = "https://jira.ncr.com/rest/api/2/issue/" + id;
            rClient.userName = MyCredentials.userID;
            rClient.userPassword = MyCredentials.Password;
            rClient.httpMethod = httpVerb.GET;

            string strResponse = rClient.makeRequest();

            string newStrRwesponse = strResponse.Replace('\"', '\'');
            //debugOutput(newStrRwesponse);
            Root root1 = JsonConvert.DeserializeObject<Root>(newStrRwesponse);
            if (root1.fields.status != null)
            {
                status = root1.fields.status.name;
            }
            switch(status)
            {
                case "Not Started":
                    status = "Not Approved";
                    break;
                case "In Dev":
                    status = "Approved";
                    break;
            }

            onProcess(wnd, "Loading Data Please wait....", false);
            return status;

        }

       public List<Request> _pendingRequestList { get; set; }

        public List<Request> PendingRequestList
        {

            get
            {
                return _pendingRequestList;
            }
            set
            {

                _pendingRequestList = value;
                OnPropertyChanged("PendingRequestList");
            }



        }

        public List<Request> _expiryRequestList { get; set; }

        public List<Request> ExpiryRequestList
        {

            get
            {
                return _expiryRequestList;
            }
            set
            {

                _expiryRequestList = value;
                OnPropertyChanged("ExpiryRequestList");
            }



        }
        public void PendingReuests()
        {
            _pendingRequestList = new List<Request>();
            PopUpWindow wnd = new PopUpWindow();
            onProcess(wnd, "Loading Data Please wait....", true);
            //string extra = "https://jira.ncr.com/rest/api/2/search?jql=project%20%3D%20HYDHKTN%20AND%20status%20%3D%20\"Not % 20Started\"%20";
            RestClient rClientPending = new RestClient();
            rClientPending.endPoint = "https://jira.ncr.com/rest/api/2/search?jql=project%20%3D%20HYDHKTN%20AND%20status%20%3D%20%22Not%20Started%22%20";
            //rClientPending.after = "\"Not%20Started\"%20";
            rClientPending.userName = MyCredentials.userID;
            rClientPending.userPassword = MyCredentials.Password;
            rClientPending.httpMethod = httpVerb.GET;

            string PendingstrResponse = rClientPending.makeRequest();

            string PendingnewStrRwesponse = PendingstrResponse.Replace('\"', '\'');
            //debugOutput(newStrRwesponse);
            GlobalHakathon.ViewModel1.Root root2 = JsonConvert.DeserializeObject<GlobalHakathon.ViewModel1.Root>(PendingnewStrRwesponse);
            Request newRequest;
            foreach (var pendingresp in root2.issues)
            {
                newRequest = new Request();
                newRequest.Summary = pendingresp.fields.summary;
                newRequest.RequestId = pendingresp.key;
                _pendingRequestList.Add(newRequest);
            }
            onProcess(wnd, "Loading Data Please wait....", false);
        }


        public void AppoveRequests()
        {
            foreach (Request pr in PendingRequestList)
            {
                if (pr.IsChecked)
                {
                    RestClient rApprovePending = new RestClient();
                    rApprovePending.endPoint = "https://jira.ncr.com/rest/api/2/issue/" + pr.RequestId + "/transitions";
                    rApprovePending.userName = MyCredentials.userID;
                    rApprovePending.userPassword = MyCredentials.Password;
                    rApprovePending.httpMethod = httpVerb.POST;
                    rApprovePending.postJSON = "{\"transition\": { \"id\": \"31\"}}";
                    
                    string PendingstrResponse = rApprovePending.makeRequest();
                }
            }

        }

        public void CreateRequest()
        {
            RestClient rApprovePending = new RestClient();
            rApprovePending.endPoint = "https://jira.ncr.com/rest/api/2/issue/";
            rApprovePending.userName = MyCredentials.userID;
            rApprovePending.userPassword = MyCredentials.Password;
            rApprovePending.httpMethod = httpVerb.POST;
            string details = ("Need " + MyJiraDetails.DeviceName + " Lane for customer: " + MyJiraDetails.Customername);
            rApprovePending.postJSON = "{\"fields\":{\"project\":{\"id\":\"39155\"},\"summary\":\""+details+"\",\"issuetype\":{\"id\":\"11\"},\"assignee\":{\"name\":\"ks185288\"},\"reporter\":{\"name\":\""+MyCredentials.userID+"\"},\"priority\":{\"id\":\"3\"},\"description\":\""+details+"\",\"customfield_14042\":{\"id\":\"38853\"}}}";

           
                string PendingstrResponse = rApprovePending.makeRequest();
                
           

        }

        private string showMsg;
        public string ShowMsg
        {
            get
            {
                return showMsg;
            }
            set
            {
                showMsg = value;
            }
        }


        public static BaseViewModel GetViewModelObject()
        {
            if(viewModelObject == null)
            {
                viewModelObject = new BaseViewModel();
            }
            return viewModelObject;
        }

        public BaseViewModel()
        {
            /*

            string userid = obj.userID;
            int password = obj.Password;
            string projectName = obj1.ProjectName;
            string DeviceName = obj1.DeviceName;
            string RFQDetails = obj1.RFQDetails;
            string Customername = obj1.Customername;
            string PersonWhoisusing = obj1.PersonWhoisusing;
            string BookingStartDate = obj1.BookingStartDate;
            string BookingEndDate = obj1.BookingEndDate;
            string ManagerName = obj1.ManagerName;
            */
        }

        public void SendMail(string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("ncrusout1.ncr.com");

            mail.From = new MailAddress("KS185288@ncr.com");
            mail.To.Add("KS185288@ncr.com");
            mail.Subject = subject;
            mail.Body = body;
            //Attachment attachment = new Attachment(filename);
            //  mail.Attachments.Add(attachment);

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("KS185288@ncr.com", "SivaRamaSai@2");
            SmtpServer.EnableSsl = true;

            NEVER_EAT_POISON_Disable_CertificateValidation();
            SmtpServer.Send(mail);
        }

        static void NEVER_EAT_POISON_Disable_CertificateValidation()
        {

            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                ) {
                    return true;
                };
        }
        private LoginModel _myCredentials;
        public LoginModel MyCredentials
        {

            get
            {
                return userCredentials;
            }
            set
            {

                _myCredentials = value;
                OnPropertyChanged("MyCredentials");
            }



        }
        private RequestDetailsModel _myJiraDetails;
        public RequestDetailsModel MyJiraDetails
        {

            get
            {
                return reuest;
            }
            set
            {

                _myJiraDetails = value;
                OnPropertyChanged("MyJiraDetails");
            }



        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
