using GlobalHakathon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseViewModel baseViewModel;
        public MainWindow()
        {
            InitializeComponent();
            baseViewModel = BaseViewModel.GetViewModelObject();
            baseViewModel.CreatUserCredentialObject();
            this.DataContext = baseViewModel;
            baseViewModel.Process += call;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtpassword.Password) || string.IsNullOrEmpty(txtuserid.Text))
            {
                MessageBox.Show("Username or Password can not be Empty");
                return;
            }
            baseViewModel.MyCredentials.Password = txtpassword.Password;
            baseViewModel.ISAdmin = (bool)this.IsAdmin.IsChecked;


            new RequestMonitor().Show();
            this.Close();
        }

        public void call(Window wnd, string str, bool p)
        {
            if (p)
            {
                baseViewModel.ShowMsg = str;
                wnd.Owner = Application.Current.MainWindow;
                maingrid.Visibility = Visibility.Hidden;
                wnd.Show();
            }
            else
            {
                wnd.Close();
                maingrid.Visibility = Visibility.Visible;
            }
        }
    }
}
