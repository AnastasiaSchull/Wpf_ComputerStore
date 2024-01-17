using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_ComputerStore.Dialog_Windows;
using Wpf_ComputerStore.Models;
using Wpf_ComputerStore.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            cmdAddComputer = new RelayCommand((param) => AddComputer());
            cmdDeleteComputer = new RelayCommand((param) => DeleteComputer(), (param) => SelectedComputer != null);
            cmdEditComputer = new RelayCommand((param) => EditComputer(), (param) => SelectedComputer != null);
            cmdGetComputer = new RelayCommand((param) => getComputers());
            cmdFindComputer = new RelayCommand((param) => FindComputer());
            AddCommand = new RelayCommand((param) => AddPeripheral());
            DeleteCommand = new RelayCommand((param) => DeletePeripheral(), (param) => SelectedPeripherals != null);
            EditCommand = new RelayCommand((param) => EditPeripheral(), (param) => SelectedPeripherals != null);
            FindCommand = new RelayCommand((param) => FindPeripheral());
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
                            ComputerDetailsList = db.ComputerDetails.Where(cd => cd.Category.Name.ToLower().Contains(CriteriaComputerDetail.ToLower())).ToList();

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

        private int selectedFindCriteriaPeripheral;
        public int SelectedFindCriteriaPeripheral
        {
            get { return selectedFindCriteriaPeripheral; }
            set
            {
                selectedFindCriteriaPeripheral = value;
                NotifyPropertyChanged("SelectedFindCriteriaPeripheral");
            }
        }

        private string criteriaPeripheral;
        public string CriteriaPeripheral
        {
            get { return criteriaPeripheral; }
            set
            {
                criteriaPeripheral = value;
                NotifyPropertyChanged("CriteriaPeripheral");
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
        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand FindCommand { get; private set; }

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

        public void EditPeripheral()
        {
            try
            {
                EditPeripheralWindow editPeripheralWindow = new EditPeripheralWindow(SelectedPeripherals);
                bool? editResult = editPeripheralWindow.ShowDialog();

                if (editResult == true)
                {
                    // Оновлюємо властивості виділеної периферії
                    SelectedPeripherals.Name = editPeripheralWindow.Name;
                    SelectedPeripherals.PeripheralsType = editPeripheralWindow.PeripheralsType;
                    SelectedPeripherals.Quantity = editPeripheralWindow.Quantity;
                    SelectedPeripherals.Price = editPeripheralWindow.Price;
                    SelectedPeripherals.Description = editPeripheralWindow.Description;

                    using (DBContext db = new DBContext())
                    {
                        // Відстежуємо зміни і зберігаємо їх в базі даних
                        db.Entry(SelectedPeripherals).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    getPeripherals();
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

        public void FindPeripheral()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    List<Peripherals> result = new List<Peripherals>();

                    switch (SelectedFindCriteriaPeripheral)
                    {
                        case 0:
                            result = db.Peripheralss.Where(pr => pr.Name.ToLower().Contains(CriteriaPeripheral.ToLower())).ToList();
                            break;
                        case 1:
                            result = db.Peripheralss.Where(pr => pr.Description.ToLower().Contains(CriteriaPeripheral.ToLower())).ToList();
                            break;
                        case 2:
                            result = db.Peripheralss.Where(pr => pr.PeripheralsType.Name.ToLower().Contains(CriteriaPeripheral.ToLower())).ToList();
                            break;
                        case 3:
                            result = db.Peripheralss.Where(pr => pr.Quantity == Int32.Parse(CriteriaPeripheral)).ToList();
                            break;
                        case 4:
                            result = db.Peripheralss.Where(pr => pr.Price == Int32.Parse(CriteriaPeripheral)).ToList();
                            break;
                    }

                    // Створюємо новий об'єкт ObservableCollection на основі результатів запиту
                    PeripheralsList = new ObservableCollection<Peripherals>(result);

                    string res = "";
                    foreach (Peripherals peripheral in PeripheralsList)
                    {
                        res += peripheral.PeripheralsType.Name;
                    }
                }
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

        private Computer selectedComputer;
        public Computer SelectedComputer
        {
            get { return selectedComputer; }
            set
            {
                selectedComputer = value;
                NotifyPropertyChanged("SelectedComputer");
            }
        }

        private int selectedFindCriteriaC;
        public int SelectedFindCriteriaC
        {
            get { return selectedFindCriteriaC; }
            set
            {
                selectedFindCriteriaC = value;
                NotifyPropertyChanged("SelectedFindCriteriaC");
            }
        }
        private string criteriaComputer;
        public string CriteriaComputer
        {
            get { return criteriaComputer; }
            set
            {
                criteriaComputer = value;
                NotifyPropertyChanged("CriteriaComputer");
            }
        }
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

        public ICommand cmdGetComputer { get; private set; }
        public void getComputers()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputersList = db.Computers.ToList();
                    string res = "";
                    foreach (Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        res += computer.ComputerType.Name;

                    }
                    string res1 = "";

                    foreach (Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        res1 += computer.RAM.Name;

                    }
                    string res2 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res2 += computer.Motherboard.Name;

                    }
                    string res3 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res3 += computer.CPU.Name;

                    }
                    string res4 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res4 += computer.HardDrive.Name;

                    }
                    string res5 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res5 += computer.SDD.Name;

                    }
                    string res6 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res6 += computer.VideoCard.Name;

                    }
                    string res7 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res7 += computer.PowerSupply.Name;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ICommand cmdEditComputer { get; private set; }

        public void EditComputer()
        {
            windowService.openComputerWindow(new ComputerViewModel(SelectedComputer));
            getComputers();
        }
        public ICommand cmdAddComputer { get; private set; }

        public void AddComputer()
        {
            windowService.openComputerWindow(new ComputerViewModel());
            getComputers();
        }

        public ICommand cmdDeleteComputer { get; private set; }

        public void DeleteComputer()
        {

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this computer?", "Delete Computer", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (DBContext db = new DBContext())
                    {
                        db.Attach(SelectedComputer);
                        db.Remove(SelectedComputer);
                        db.SaveChanges();
                    }
                    getComputers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public ICommand cmdFindComputer { get; private set; }

        public void FindComputer()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputersList = db.Computers.ToList();
                    switch (SelectedFindCriteriaC)
                     {
                        
                         case 0:
                             ComputersList = db.Computers.Where(c => c.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                             break;
                        case 1:
                            ComputersList = db.Computers.Where(c => c.ComputerType.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();

                            break;
                        case 2:
                            ComputersList = ComputersList.Where(c => c.Motherboard.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                        case 3:
                            ComputersList = ComputersList.Where(c => c.RAM.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                        case 4:
                            ComputersList = ComputersList.Where(c => c.CPU.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                        case 5:
                            ComputersList = ComputersList.Where(c => c.HardDrive.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                        case 6:
                            ComputersList = ComputersList.Where(c => c.SDD.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                        case 7:
                            ComputersList = ComputersList.Where(c => c.VideoCard.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                        case 8:
                            ComputersList = ComputersList.Where(c => c.PowerSupply.Name.ToLower().Contains(CriteriaComputer.ToLower())).ToList();
                            break;
                            
                        case 9:
                             ComputersList = db.Computers.Where(cd => cd.Price == Int32.Parse(CriteriaComputer)).ToList();

                             break;
                     }
                    
                    string res = "";
                    foreach (Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        res += computer.ComputerType.Name;

                    }
                    string res1 = "";

                    foreach (Computer computer in ComputersList) //костиль бо не працюе лiнива загрузка
                    {
                        res1 += computer.RAM.Name;

                    }
                    string res2 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res2 += computer.Motherboard.Name;

                    }
                    string res3 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res3 += computer.CPU.Name;

                    }
                    string res4 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res4 += computer.HardDrive.Name;

                    }
                    string res5 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res5 += computer.SDD.Name;

                    }
                    string res6 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res6 += computer.VideoCard.Name;

                    }
                    string res7 = "";
                    foreach (Computer computer in ComputersList)
                    {
                        res7 += computer.PowerSupply.Name;

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
