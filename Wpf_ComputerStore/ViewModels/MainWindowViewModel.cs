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
        public MainWindowViewModel()
        {
            getComputers();
            getPeripherals();
            getComputerDetails();
            getCategoriesList();
            getPeripheralsTypes();
            AddCommand = new RelayCommand((param) => AddPeripheral());
            DeleteCommand = new RelayCommand((param) => DeletePeripheral(), (param) => SelectedPeripherals != null);
            cmdAddComputerDetail = new RelayCommand((param) => AddComputerDetail());
            cmdEditComputerDetail = new RelayCommand((param) => EditComputerDetail(), (param) => SelectedComputerDetail != null);
            cmdDeleteComputerDetail = new RelayCommand((param) => DeleteComputerDetail(), (param) => SelectedComputerDetail != null);
            cmdGetComputerDetail = new RelayCommand((param)=>getComputerDetails());
            cmdFindComputerDetail = new RelayCommand ((param) => FindComputerDetail());
            SelectedFindCriteriaCD = 0;
            windowService = new WindowService();
        }



        #region computer_detail
        private int selectedFindCriteriaCD;
        public int SelectedFindCriteriaCD
        {
            get { return selectedFindCriteriaCD;}
            set {
                selectedFindCriteriaCD = value;
                NotifyPropertyChanged("SelectedFindCriteriaCD");
            }
        }
        private string criteriaComputerDetail;
        public string CriteriaComputerDetail
        {
            get { return criteriaComputerDetail; }
            set
            {
                criteriaComputerDetail = value;
                NotifyPropertyChanged("CriteriaComputerDetail");
            }
        }

        private List<ComputerDetail> computerDetailsList = new List<ComputerDetail>();
        private ComputerDetail selectedComputerDetail;
        public ComputerDetail SelectedComputerDetail
        {
            get { return selectedComputerDetail; }
            set
            {
                selectedComputerDetail = value;
                NotifyPropertyChanged("SelectedComputerDetail");
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
        public ICommand cmdGetComputerDetail { get; private set; }

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
        public ICommand cmdFindComputerDetail { get; private set; }

        public void FindComputerDetail()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    switch (SelectedFindCriteriaCD)
                    {
                        case 0:
                            ComputerDetailsList =db.ComputerDetails.Where(cd=>cd.Name.ToLower().Contains(CriteriaComputerDetail.ToLower())).ToList();
                             break;
                        case 1:
                            ComputerDetailsList = db.ComputerDetails.Where(cd => cd.Description.ToLower().Contains(CriteriaComputerDetail.ToLower())).ToList();

                            break;
                        case 2:
                            ComputerDetailsList = db.ComputerDetails.Where(cd => cd.Category.Name.ToLower().Equals(CriteriaComputerDetail.ToLower())).ToList();

                            break;
                        case 3:
                            ComputerDetailsList = db.ComputerDetails.Where(cd => cd.ID == Int32.Parse(CriteriaComputerDetail)).ToList();

                            break;
                    }
                    string res = "";
                    foreach (ComputerDetail cd in ComputerDetailsList) //костиль бо не працюе лiнива загрузка
                    {
                        res += cd.Category.Name;

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand cmdAddComputerDetail { get; private set; }

        public void AddComputerDetail()
        {
            windowService.openComputerDetailWindow(new ComputerDetailViewModel());
            getComputerDetails();
        }

        public ICommand cmdEditComputerDetail { get; private set; }

        public void EditComputerDetail()
        {
            windowService.openComputerDetailWindow(new ComputerDetailViewModel(SelectedComputerDetail));
            getComputerDetails();
        }

        public ICommand cmdDeleteComputerDetail { get; private set; }

        public void DeleteComputerDetail()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this computer detail?", "Delete computer detail", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) {
                return;
            }
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Attach(SelectedComputerDetail);
                    db.Remove(SelectedComputerDetail);
                    db.SaveChanges();
                }
                getComputerDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region peripherals_type

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

        private Peripherals selectedPeripherals;

        public Peripherals SelectedPeripherals
        {
            get { return selectedPeripherals; }
            set
            {
                selectedPeripherals = value;
                NotifyPropertyChanged("SelectedPeripherals");
            }
        }

        #endregion


        #region peripheral
        private ObservableCollection<Peripherals> peripheralsList = new ObservableCollection<Peripherals>();


        public ObservableCollection<Peripherals> PeripheralsList
        {
            get { return peripheralsList; }

            set
            {
                peripheralsList = value;
                NotifyPropertyChanged("PeripheralsList");
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

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

                    // Отримуємо контекст бази даних
                    using (DBContext db = new DBContext())
                    {
                        // Додаємо новий об'єкт до контексту
                        db.Peripheralss.Add(newPeripheral);

                        // Зберігаємо зміни в базі даних
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeletePeripheral()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this computer detail?", "Delete computer detail", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Attach(SelectedPeripherals);
                    db.Remove(SelectedPeripherals);
                    db.SaveChanges();
                }
                getPeripherals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region category
        private List<Category> categoriesList = new List<Category>();

        public List<Category> CategoriesList
        {
            get { return categoriesList; }

            set
            {
                categoriesList = value;
                NotifyPropertyChanged("CategoriesList");
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

        #endregion

        #region computers

        private List<Computer> computersList = new List<Computer>();


        public List<Computer> ComputersList
        {
            get { return computersList; }
            set
            {
                computersList = value;
                NotifyPropertyChanged("ComputersList");
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
                    foreach (Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        rams += computer.ComputerType.Name;

                    }
                    string rams1 = "";

                    foreach (Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        rams1 += computer.RAM.Name;

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


        #endregion








    }
       
}
