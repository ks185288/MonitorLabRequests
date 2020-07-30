using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHackathon
{
    class JSONtoClass
    {

    }
   // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Priority
        {
            public string self { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public string id { get; set; }

        }

        /*  public class AvatarUrls
          {
              public string 48x48 { get; set; }
          public string 24x24 { get; set; }
      public string 16x16 { get; set; } 
              public string 32x32 { get; set; } 

          }
      */
        public class Assignee
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            //    public AvatarUrls avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }

        }

        public class StatusCategory
        {
            public string self { get; set; }
            public int id { get; set; }
            public string key { get; set; }
            public string colorName { get; set; }
            public string name { get; set; }

        }

        public class Status
        {
            public string self { get; set; }
            public string description { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public string id { get; set; }
            public StatusCategory statusCategory { get; set; }

        }
        /*
        public class AvatarUrls2
        {
            public string 48x48 { get; set; }
        public string 24x24 { get; set; } 
                public string 16x16 { get; set; } 
                public string 32x32 { get; set; } 

            }
        */
        public class Creator
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            //        public AvatarUrls2 avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }

        }
        /*
        public class AvatarUrls3
        {
            public string 48x48 { get; set; }
        public string 24x24 { get; set; } 
                public string 16x16 { get; set; } 
                public string 32x32 { get; set; } 

            }
        */
        public class Reporter
        {
            public string self { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public string emailAddress { get; set; }
            //    public AvatarUrls3 avatarUrls { get; set; }
            public string displayName { get; set; }
            public bool active { get; set; }
            public string timeZone { get; set; }

        }

        public class Aggregateprogress
        {
            public int progress { get; set; }
            public int total { get; set; }

        }

        public class Progress
        {
            public int progress { get; set; }
            public int total { get; set; }

        }

        public class Votes
        {
            public string self { get; set; }
            public int votes { get; set; }
            public bool hasVoted { get; set; }

        }

        public class Worklog
        {
            public int startAt { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public List<object> worklogs { get; set; }

        }

        public class Issuetype
        {
            public string self { get; set; }
            public string id { get; set; }
            public string description { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public bool subtask { get; set; }
            public int avatarId { get; set; }

        }
        /*
        public class AvatarUrls4
        {
            public string 48x48 { get; set; }
        public string 24x24 { get; set; } 
                public string 16x16 { get; set; } 
                public string 32x32 { get; set; } 

            }
        */
        public class Project
        {
            public string self { get; set; }
            public string id { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            //    public AvatarUrls4 avatarUrls { get; set; }

        }

        public class Watches
        {
            public string self { get; set; }
            public int watchCount { get; set; }
            public bool isWatching { get; set; }

        }

        public class Customfield13530
        {
            public string self { get; set; }
            public string value { get; set; }
            public string id { get; set; }

        }

        public class Customfield10010
        {
            public string self { get; set; }
            public string value { get; set; }
            public string id { get; set; }

        }

        public class Timetracking
        {

        }

        public class Customfield14042
        {
            public string self { get; set; }
            public string value { get; set; }
            public string id { get; set; }

        }

        public class Comment
        {
            public List<object> comments { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public int startAt { get; set; }

        }

        public class Fields
        {
            public object customfield_14032 { get; set; }
            public object customfield_14033 { get; set; }
            public object customfield_14031 { get; set; }
            public object customfield_14432 { get; set; }
            public object customfield_14433 { get; set; }
            public object customfield_10230 { get; set; }
            public object customfield_14430 { get; set; }
            public List<object> fixVersions { get; set; }
            public object resolution { get; set; }
            public DateTime lastViewed { get; set; }
            public object customfield_10060 { get; set; }
            public string customfield_11030 { get; set; }
            public object customfield_13330 { get; set; }
            public object customfield_10220 { get; set; }
            public object customfield_10100 { get; set; }
            public Priority priority { get; set; }
            public object customfield_10222 { get; set; }
            public object customfield_10223 { get; set; }
            public List<object> labels { get; set; }
            public object aggregatetimeoriginalestimate { get; set; }
            public object timeestimate { get; set; }
            public List<object> versions { get; set; }
            public List<object> issuelinks { get; set; }
            public Assignee assignee { get; set; }
            public Status status { get; set; }
            public List<object> components { get; set; }
            public object customfield_10170 { get; set; }
            public object customfield_10050 { get; set; }
            public object customfield_12231 { get; set; }
            public object customfield_10294 { get; set; }
            public object customfield_12230 { get; set; }
            public object customfield_12232 { get; set; }
            public string customfield_10330 { get; set; }
            public object customfield_14530 { get; set; }
            public object customfield_10210 { get; set; }
            public string customfield_12631 { get; set; }
            public string customfield_12630 { get; set; }
            public object customfield_10730 { get; set; }
            public object aggregatetimeestimate { get; set; }
            public Creator creator { get; set; }
            public object customfield_10280 { get; set; }
            public List<object> subtasks { get; set; }
            public object customfield_10160 { get; set; }
            public object customfield_10040 { get; set; }
            public object customfield_10161 { get; set; }
            public object customfield_11130 { get; set; }
            public Reporter reporter { get; set; }
            public Aggregateprogress aggregateprogress { get; set; }
            public object customfield_13830 { get; set; }
            public object customfield_10200 { get; set; }
            public object customfield_10201 { get; set; }
            public Progress progress { get; set; }
            public Votes votes { get; set; }
            public Worklog worklog { get; set; }
            public Issuetype issuetype { get; set; }
            public object timespent { get; set; }
            public Project project { get; set; }
            public object customfield_12334 { get; set; }
            public object aggregatetimespent { get; set; }
            public object customfield_10431 { get; set; }
            public object customfield_10035 { get; set; }
            public object customfield_10432 { get; set; }
            public object customfield_14632 { get; set; }
            public object customfield_10302 { get; set; }
            public object customfield_10303 { get; set; }
            public object resolutiondate { get; set; }
            public int workratio { get; set; }
            public Watches watches { get; set; }
            public DateTime created { get; set; }
            public object customfield_10260 { get; set; }
            public object customfield_10261 { get; set; }
            public Customfield13530 customfield_13530 { get; set; }
            public object customfield_10301 { get; set; }
            public DateTime updated { get; set; }
            public object timeoriginalestimate { get; set; }
            public object customfield_10250 { get; set; }
            public string description { get; set; }
            public Customfield10010 customfield_10010 { get; set; }
            public object customfield_10253 { get; set; }
            public object customfield_10256 { get; set; }
            public string customfield_12830 { get; set; }
            public Timetracking timetracking { get; set; }
            public object customfield_10006 { get; set; }
            public List<object> attachment { get; set; }
            public string summary { get; set; }
            public object customfield_10080 { get; set; }
            public object customfield_14041 { get; set; }
            public Customfield14042 customfield_14042 { get; set; }
            public object customfield_11331 { get; set; }
            public object customfield_13630 { get; set; }
            public object customfield_10242 { get; set; }
            public object customfield_11330 { get; set; }
            public object customfield_10243 { get; set; }
            public object customfield_13631 { get; set; }
            public object customfield_10003 { get; set; }
            public object customfield_11335 { get; set; }
            public object customfield_10004 { get; set; }
            public object environment { get; set; }
            public object duedate { get; set; }
            public Comment comment { get; set; }

        }

        public class Root
        {
            public string expand { get; set; }
            public string id { get; set; }
            public string self { get; set; }
            public string key { get; set; }
            public Fields fields { get; set; }

        }
    }

