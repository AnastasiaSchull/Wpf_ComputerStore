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
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow()
        {
            InitializeComponent();
            MessageViewModel vm = new MessageViewModel();
            DataContext = vm;
           vm.CloseAction = new Action(() => this.Close());//iнiцiалiзуэмо делегат, щоб закривалося саме це вiкно

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;           
        }

       
    }
   
}
