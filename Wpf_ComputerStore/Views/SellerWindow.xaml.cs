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
using System.Windows.Shapes;
using Wpf_ComputerStore.ViewModels;

namespace Wpf_ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow(BaseViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;//щоб розташувати у центрi діалогове вікно додавання ( редагування) деталей
        }
        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
