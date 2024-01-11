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

namespace Wpf_ComputerStore.Dialog_Windows
{
    /// <summary>
    /// Interaction logic for EditPeripheralWindow.xaml
    /// </summary>
    public partial class EditPeripheralWindow : Window
    {
        public string? Name { get; set; }
        public virtual PeripheralsType PeripheralsType { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

        public EditPeripheralWindow(Peripherals selectedPeripherals)
        {
            InitializeComponent();

            Name = selectedPeripherals.Name;
            PeripheralsType = selectedPeripherals.PeripheralsType;
            Quantity = selectedPeripherals.Quantity;
            Price = selectedPeripherals.Price;
            Description = selectedPeripherals.Description;

            // Задайте відповідні значення елементам у вікні
            NameTextBox.Text = Name;
            PeripheralsTypeComboBox.SelectedValue = PeripheralsType.Name;
            QuantityTextBox.Text = Quantity.ToString();
            PriceTextBox.Text = Price.ToString();
            DescriptionTextBox.Text = Description;
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
