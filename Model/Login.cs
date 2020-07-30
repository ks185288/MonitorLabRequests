using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHakathon.Models
{
    class LoginModel : INotifyPropertyChanged
    {
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _userid;
        public string userID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
                OnPropertyChanged("userID");
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
