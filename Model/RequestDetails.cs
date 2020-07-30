using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHakathon.Models
{
    class RequestDetailsModel : INotifyPropertyChanged
    {
        public string ProjectName { get; set; }
        public string DeviceName { get; set; }
        public string RFQDetails { get; set; }
        public string Customername { get; set; }
        public string PersonWhoisusing { get; set; }
        public string BookingStartDate { get; set; }
        public string BookingEndDate { get; set; }
        public string ManagerName { get; set; }
        public string Status { get; set; }
        public string HWPresence { get; set; }
        public string comments { get; set; }

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
