using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHakathon.Model
{
    class Request : INotifyPropertyChanged
    {
        private string _requestId;
        public string RequestId
        {
            get
            {
                return _requestId;
            }
            set
            {
                _requestId = value;
                OnPropertyChanged("RequestId");
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
                OnPropertyChanged("Summary");
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
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
        private string _summary;
        #endregion


    }
}

