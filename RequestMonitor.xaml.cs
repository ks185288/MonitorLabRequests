using GlobalHakathon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GlobalHakathon
{
    /// <summary>
    /// Interaction logic for RequestMonitor.xaml
    /// </summary>
    public partial class RequestMonitor : Window
    {
        BaseViewModel baseViewModel;
        public RequestMonitor()
        {
            InitializeComponent();
            baseViewModel = BaseViewModel.GetViewModelObject();
            baseViewModel.CreateRequestObject();
            this.DataContext = baseViewModel;
        }

        private void Button_RaiseRequest_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            this.Submit.Content = "Submit";
            this.Submit.Visibility = Visibility.Visible;
            CreateRequestPanel.Visibility = GobackPanel.Visibility = Visibility.Visible;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (CreateRequestPanel.IsVisible)
            {
                baseViewModel.CreateRequest();
                MessageBox.Show("Your request has been submitted.\n Please check your mail-box for more details");
            }
            if (SearchRequestPanel.IsVisible)
            {
                baseViewModel.SendMail("Follow-up on :" + this.checkStatus.RequestId.Text, this.checkStatus.Comment.Text);
            }
            if(PendinRequestPanel.IsVisible)
            {
                baseViewModel.AppoveRequests();
            }
           GobackPanel.Visibility = PendinRequestPanel.Visibility = SearchRequestPanel.Visibility = CreateRequestPanel.Visibility = Visibility.Collapsed;
        }

        private void Button_CheckStatus_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            this.checkStatus.InitalizeStatus();
            this.Submit.Content = "Submit";
            this.Submit.Visibility = Visibility.Visible;
            SearchRequestPanel.Visibility = GobackPanel.Visibility = Visibility.Visible;
        }


        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
        }

        private void HideAll()
        {
           this.PendinRequestPanel.Visibility = SearchRequestPanel.Visibility = GobackPanel.Visibility = CreateRequestPanel.Visibility = Visibility.Collapsed;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Pending_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            baseViewModel.PendingReuests();
            this.PendinRequestPanel.Visibility = GobackPanel.Visibility = Visibility.Visible;
            this.PendingRequests.SetPendingList();
            if(baseViewModel.PendingRequestList.Count > 0)
            {
                this.Submit.Content = "Approve";
            }
            else
            {
                this.Submit.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Expired_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            baseViewModel.PendingReuests();
            this.ExpireRequests.Visibility = GobackPanel.Visibility = Visibility.Visible;
            //this.ExpireRequests.SetPendingList();
            if (baseViewModel.ExpiryRequestList.Count > 0)
            {
                this.Submit.Content = "Notify";
            }
            else
            {
                this.Submit.Visibility = Visibility.Collapsed;
            }

        }
    }
}
