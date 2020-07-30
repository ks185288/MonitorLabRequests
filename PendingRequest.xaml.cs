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
    /// Interaction logic for PendingRequest.xaml
    /// </summary>
    public partial class PendingRequest : UserControl
    {
        BaseViewModel baseViewModel;
        public PendingRequest()
        {
            InitializeComponent();
            baseViewModel = BaseViewModel.GetViewModelObject();
            this.DataContext = baseViewModel;
        }

        public void SetPendingList()
        {
            this.PendlingList.ItemsSource = baseViewModel.PendingRequestList;
        }

     
    }
}
