using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using GlobalHakathon.ViewModel;
namespace GlobalHakathon
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
       BaseViewModel dvm;
        public PopUpWindow()
        {
            InitializeComponent();
            dvm = BaseViewModel.GetViewModelObject();
            //lbl.Visibility = Visibility.Visible;
            this.DataContext = dvm;
        }
    }
}
