using GlobalHakathon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlobalHakathon
{
    /// <summary>
    /// Interaction logic for CheckStatus.xaml
    /// </summary>
    public partial class CheckStatus : UserControl
    {
        BaseViewModel baseViewModel;
        public CheckStatus()
        {
            InitializeComponent();
            baseViewModel = BaseViewModel.GetViewModelObject();
            this.DataContext = baseViewModel;
            StatusPanel.Visibility = Visibility.Collapsed;
        }

        public void InitalizeStatus()
        {
            this.StatusPanel.Visibility = Visibility.Collapsed;
            this.RequestId.Text = "";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow wnd = new PopUpWindow();
            //onProcess(wnd, "Loading Data Please wait....", true);

            this.Comment.Text = "";
            StatusValue.Content = "";
            if (!string.IsNullOrEmpty(RequestId.Text))
            {
                string status =baseViewModel.SearchReuest(RequestId.Text);

                if (!string.IsNullOrEmpty(RequestId.Text))
                { 
                    StatusPanel.Visibility = Visibility.Visible;
                    StatusValue.Content = status;
                }
            }

            //onProcess(wnd, "Loading Data Please wait....", false);
        }
    }
}
