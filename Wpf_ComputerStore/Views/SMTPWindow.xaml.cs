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
    /// Interaction logic for SMTPWindow.xaml
    /// </summary>
    public partial class SMTPWindow : Window
    {
        public SMTPWindow(BaseViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void MyPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            if (DataContext is SMTPViewModel viewModel)
            {
                viewModel.Password = passwordBox.Password;
            }
        }

        private void close_Window(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
