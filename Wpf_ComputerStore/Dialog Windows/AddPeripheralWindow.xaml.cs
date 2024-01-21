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
using Wpf_ComputerStore.Models;
using Wpf_ComputerStore.ViewModels;
using Wpf_ComputerStore.Views;

namespace Wpf_ComputerStore.Dialog_Windows
{
    /// <summary>
    /// Interaction logic for AddPeripheralWindow.xaml
    /// </summary>
    public partial class AddPeripheralWindow : Window
    {
        public string? Name { get; set; }
        public virtual PeripheralsType PeripheralsType { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

      
        public AddPeripheralWindow()
        {       
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;//щоб розташувати у центрi діалогове вікно додавання ( редагування) 
        }

       

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Name = NameTextBox.Text;

                string selectedPeripheralsTypeName = (string)PeripheralsTypeComboBox.SelectedValue;
                PeripheralsType = new PeripheralsType { Name = selectedPeripheralsTypeName };

                if (int.TryParse(QuantityTextBox.Text, out int quantity))
                {
                    Quantity = quantity;
                }

                if (double.TryParse(PriceTextBox.Text, out double price))
                {
                    Price = price;
                }

                Description = DescriptionTextBox.Text;

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
