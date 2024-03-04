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
    /// Interaction logic for DiscountWindow.xaml
    /// </summary>
    public partial class DiscountWindow : Window
    {
        public DiscountWindow(BaseViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // является ли вводимый символ числом
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // если символ не является числом, отменяем маршрутизацию события
            }
            else
            {
                // получаем текущее содержимое текстового поля
                var textBox = sender as TextBox;
                string currentText = textBox.Text + e.Text;

                // если введенное значение больше 100, отменяем его
                if (!string.IsNullOrEmpty(currentText) && int.Parse(currentText) > 100)
                {
                    e.Handled = true;
                }
            }
        }

        private void clickMakeDicount(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
