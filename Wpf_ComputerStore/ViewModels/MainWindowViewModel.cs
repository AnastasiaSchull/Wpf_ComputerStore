using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_ComputerStore.Dialog_Windows;
using Wpf_ComputerStore.Models;
using Wpf_ComputerStore.Services;

namespace Wpf_ComputerStore.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {


        private List<ComputerDetail> computerDetailsList = new List<ComputerDetail>();
        private List<Category> categoriesList = new List<Category>();
        private List<Computer> computersList = new List<Computer>();
        private ObservableCollection<Peripherals> peripheralsList = new ObservableCollection<Peripherals>();
        private List<PeripheralsType> peripheralsTypeList = new List<PeripheralsType>();

        public List<PeripheralsType> PeripheralsTypeList
        {
            get { return peripheralsTypeList; }
            set
            {
                peripheralsTypeList = value;
                NotifyPropertyChanged("PeripheralsTypeList");
            }
        }

        public ObservableCollection<Peripherals> PeripheralsList
        {
            get { return peripheralsList; }

            set
            { 
                peripheralsList = value;
                NotifyPropertyChanged("PeripheralsList");
            }
        }

        public List<ComputerDetail> ComputerDetailsList
        {
            get { return computerDetailsList; }
            set
            {
                computerDetailsList = value;
                NotifyPropertyChanged("ComputerDetailsList");
            }
        }

        public List<Category> CategoriesList
        {
            get { return categoriesList; }

            set
            {
                categoriesList = value;
                NotifyPropertyChanged("CategoriesList");
            }
        }

        public List<Computer> ComputersList
        {
            get { return computersList; }
            set
            {
                computersList = value;
                NotifyPropertyChanged("ComputersList");
            }
        }

        public MainWindowViewModel()
        {
            getComputers();
            getPeripherals();           
            getComputerDetails();
            getCategoriesList();
            getPeripheralsTypes();
            AddCommand = new RelayCommand((param) => AddPeripheral());
        }

        public void getPeripherals()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    PeripheralsList = new ObservableCollection<Peripherals>(db.Peripheralss.Include(p => p.PeripheralsType).ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getComputerDetails()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputerDetailsList = db.ComputerDetails.ToList();
                    string res = "";
                    foreach (ComputerDetail cd in ComputerDetailsList) //костиль бо не працюе лiнива загрузка
                    {
                        res += cd.Category.Name;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getCategoriesList()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    CategoriesList = db.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getComputers()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputersList = db.Computers.ToList();
                    string rams = "";
                    foreach(Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        rams += computer.RAM.Name;
                        
                    }
                    string rams2 = "";
                    foreach (Computer computer in ComputersList) 
                    {
                        rams2 += computer.Motherboard.Name;

                    }
                    string rams3 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        rams3 += computer.CPU.Name;

                    }
                    string rams4 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        rams4 += computer.HardDrive.Name;

                    }
                    string rams5 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        rams5 += computer.SDD.Name;

                    }
                    string rams6 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        rams6 += computer.VideoCard.Name;

                    }
                    string rams7 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        rams7 += computer.PowerSupply.Name;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getPeripheralsTypes()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    PeripheralsTypeList = db.PeripheralsType.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand AddCommand { get; private set; }

        public void AddPeripheral()
        {
            try
            {
                var addPeripheralWindow = new AddPeripheralWindow();
                var result = addPeripheralWindow.ShowDialog();

                if (result == true)
                {
                    string? Name = addPeripheralWindow.Name;
                    PeripheralsType peripheralsType = addPeripheralWindow.PeripheralsType;
                    int Quantity = addPeripheralWindow.Quantity;
                    double Price = addPeripheralWindow.Price;
                    string? Description = addPeripheralWindow.Description;

                    if (string.IsNullOrEmpty(Name) || Quantity <= 0 || Price <= 0)
                    {
                        MessageBox.Show("Please fill in all required fields (Name, Quantity, Price).");
                        return;
                    }

                    // Створюємо новий об'єкт Peripherals
                    var newPeripheral = new Peripherals
                    {
                        Name = Name,
                        PeripheralsType = peripheralsType,
                        Quantity = Quantity,
                        Price = Price,
                        Description = Description
                    };

                    // Додаємо новий об'єкт до списку
                    PeripheralsList.Add(newPeripheral);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
