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
    /// Interaction logic for ComputerDetailWindow.xaml
    /// </summary>
    public partial class ComputerDetailWindow : Window
    {
        public ComputerDetailWindow(BaseViewModel model)
        {
            DataContext = model;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;//щоб розташувати у центрi діалогове вікно додавання ( редагування) деталей
        }
        public void CloseWindow(object sender, RoutedEventArgs e) {
            Close();
        }        

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "0")
            {
                textBox.Clear(); 
            }
            textBox.SelectAll(); 
        }

    }
}
