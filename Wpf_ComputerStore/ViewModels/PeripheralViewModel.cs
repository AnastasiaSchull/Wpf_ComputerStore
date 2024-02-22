using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Wpf_ComputerStore.Models;

namespace Wpf_ComputerStore.ViewModels
{
    public class PeripheralViewModel : BaseViewModel
    {
        private Peripherals peripheral;
    
        public PeripheralViewModel()
        {
            getPeripherals();
            Peripheraltype = Peripheralstype[0];
            AddCommand = new RelayCommand((param) => AddPeripheral(), (param) => CanExecute);
        }

      
        public PeripheralViewModel(Peripherals peripheral) 
        {         
            this.peripheral = peripheral;
            getPeripherals();
            Peripheraltype = Peripheralstype.Find(c => c.ID == peripheral.PeripheralsType.ID);
            Name = peripheral.Name;
            Quantity = peripheral.Quantity;
            Description = peripheral.Description;
            Price = peripheral.Price;
            AddCommand = new RelayCommand((param) => AddPeripheral(), (param) => CanExecute);
        }

        void getPeripherals()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    Peripheralstype = db.PeripheralsType.ToList();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
        #region variables
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }
        private double price;
        public double Price
        {
            get => price;
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }
        private PeripheralsType peripheraltype;
        public PeripheralsType Peripheraltype
        {
            get => peripheraltype;
            set
            {
                peripheraltype = value;
                NotifyPropertyChanged("Peripheraltype");
            }
        }

        private List<PeripheralsType> peripheralstype;
        public List<PeripheralsType> Peripheralstype
        {
            get => peripheralstype;
            set
            {
                peripheralstype = value;
                NotifyPropertyChanged("Peripheralstype");
            }
        }
        #endregion

        public ICommand AddCommand { get; set; }

        public void AddPeripheral()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Attach(Peripheraltype);
                    if (peripheral == null)
                    {
                        Peripherals peripheral = new Peripherals { Name = Name, Quantity = Quantity, PeripheralsType = Peripheraltype, Description = Description, Price = Price };
                        db.Peripheralss.Add(peripheral);
                    }
                    else
                    {
                        peripheral.Name = Name;
                        peripheral.Quantity = Quantity;
                        peripheral.PeripheralsType = Peripheraltype;
                        peripheral.Price = Price;
                        peripheral.Description = Description;
                        db.Peripheralss.Update(peripheral);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool CanExecute
        {
            get { return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Description) && Quantity != 0 && Price != 0; }
        }
    }
}