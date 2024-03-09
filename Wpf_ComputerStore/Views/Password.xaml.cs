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
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password(BaseViewModel vm)
        {
            DataContext = vm;
            (vm as PasswordViewModel).CloseAction = new Action(() => this.Close());//iнiцiалiзуэмо делегат, щоб закривалося саме це вiкно
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;           
        }

        //властивість Pass в ViewModel буде оновлюватися при кожній зміні вмісту PasswordBox
        private void MyPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            if (DataContext is PasswordViewModel viewModel)
            {
                viewModel.Pass = passwordBox.Password;
               
            }
           
        }    
    }
}
