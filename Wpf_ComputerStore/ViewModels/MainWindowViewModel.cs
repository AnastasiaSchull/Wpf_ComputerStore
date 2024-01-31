using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using Wpf_ComputerStore.Models;
using Wpf_ComputerStore.Services;

namespace Wpf_ComputerStore.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public bool IsAdmin { get; set; }
       
        public MainWindowViewModel(bool isAdmin)
        {
            IsAdmin = isAdmin;
            getComputers();
            getPeripherals();
            getComputerDetails();
            getCategoriesList();
            getPeripheralsTypes();
            cmdAddComputer = new RelayCommand((param) => AddComputer(),(param) => IsAdmin );// щоб тільки адмін міг додати комп'ютер
            cmdDeleteComputer = new RelayCommand((param) => DeleteComputer(), (param) => SelectedComputer != null && IsAdmin );
            cmdEditComputer = new RelayCommand((param) => EditComputer(), (param) => SelectedComputer != null && IsAdmin);
            cmdGetComputer = new RelayCommand((param) => getComputers());
            cmdFindComputer = new RelayCommand((param) => FindComputer());
            cmdSaleComputer = new RelayCommand((param) => SaleComputer(), (param) => SelectedComputer != null && IsAdmin);          

            AddCommand = new RelayCommand((param) => AddPeripheral(), (param) => IsAdmin);
            DeleteCommand = new RelayCommand((param) => DeletePeripheral(), (param) => SelectedPeripherals != null && IsAdmin);
            EditCommand = new RelayCommand((param) => EditPeripheral(), (param) => SelectedPeripherals != null && IsAdmin);
            GetPeripheralsCommand = new RelayCommand((param) => getPeripherals());
            FindCommand = new RelayCommand((param) => FindPeripheral());
            SalePeripheralCommand = new RelayCommand((param) => SalePeripheral(), (param) => SelectedPeripherals != null && IsAdmin);

            cmdAddComputerDetail = new RelayCommand((param) => AddComputerDetail(), (param) => IsAdmin);
            cmdEditComputerDetail = new RelayCommand((param) => EditComputerDetail(), (param) => SelectedComputerDetail != null && IsAdmin);
            cmdDeleteComputerDetail = new RelayCommand((param) => DeleteComputerDetail(), (param) => SelectedComputerDetail != null && IsAdmin);
            cmdGetComputerDetail = new RelayCommand((param)=> getComputerDetails());
            cmdFindComputerDetail = new RelayCommand ((param) => FindComputerDetail());
            cmdSaleComputerDetail = new RelayCommand((param) => SaleComputerDetail(), (param) => SelectedComputerDetail != null && IsAdmin);           
           
            cmdSale = new RelayCommand((param) => Sale(), (param) => !Items.IsNullOrEmpty() && !CustomerName.IsNullOrEmpty());
            cmdPlus = new RelayCommand((param)=>PlusItem(), (param)=> SelectedItem != null);
            cmdMinus = new RelayCommand((param) => MinusItem(), (param) => SelectedItem != null);
            cmdClearCart = new RelayCommand((param) => ClearCart(), (param) =>  !Items.IsNullOrEmpty());
            cmdDeleteFromCart= new RelayCommand((param)=>DeleteFromCart(), (param)=> SelectedItem != null);
            StartDate = DateTime.Now.AddMonths(-1);
            FinalDate = DateTime.Now;
            cmdCountMoney = new RelayCommand((param) => CountMoney());

            SelectedFindCriteriaCD = 0;
            OrderCart = new OrderCart { Items = new List<ItemForSale>() };
            windowService = new WindowService();
        }
        #region order

        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value;
                NotifyPropertyChanged("CustomerName");
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }
        private OrderCart orderCart;
        public OrderCart OrderCart
        {
            get { return orderCart; }
            set {
                orderCart = value;
                NotifyPropertyChanged("OrderCart");
            }
        }
        private ItemForSale selectedItem;
        public ItemForSale SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
               
                Quantity = value.Quantity;
            }
        }

        public List<ItemForSale> Items
        {
            get { return orderCart.Items; }
            set
            {
                orderCart.Items = value;
                NotifyPropertyChanged("Items");
            }
        }
        public ICommand cmdSaleComputerDetail { get; private set; }

        public void SaleComputerDetail()
        {
            if (Items.Where(cd => cd.Item == SelectedComputerDetail).Any())
            {
                ItemForSale item = Items.Where(cd => cd.Item.ID == SelectedComputerDetail.ID).First();
                if (item.Item.Quantity >= item.Quantity + 1)
                    item.Quantity++;
                else
                    MessageBox.Show("not enough computer details in store");
                
            }
            else
            {
                
                Items.Add(new ItemForSale { Item = SelectedComputerDetail, Quantity = 1 });
            }

            getItems();
        }

        public ICommand SalePeripheralCommand { get; private set; }

        public void SalePeripheral()
        {
            if (Items.Where(pr => pr.Item == SelectedPeripherals).Any())
            {
                ItemForSale item = Items.Where(pr => pr.Item.ID == SelectedPeripherals.ID).First();
                if (item.Item.Quantity >= item.Quantity + 1)
                    item.Quantity++;

                else
                    MessageBox.Show("Not enough computer details in store");
            }

            else
            {
                Items.Add(new ItemForSale { Item = SelectedPeripherals, Quantity = 1 });
            }
        }

        public ICommand cmdSaleComputer { get; private set; }

        public void SaleComputer()
        {
            if (Items.Where(cd => cd.Item == SelectedComputer).Any())
            {
                ItemForSale item = Items.Where(cd => cd.Item.ID == SelectedComputer.ID).First();
                if (item.Item.Quantity >= item.Quantity + 1)
                    item.Quantity++;
                else
                    MessageBox.Show("not enough computers in store");

            }
            else
            {

                Items.Add(new ItemForSale { Item = SelectedComputer, Quantity = 1 });
            }

            getItems();
        }
        public ICommand cmdPlus { get; private set; }

        public void PlusItem()
        {
               
                if (SelectedItem.Item.Quantity >= SelectedItem.Quantity + 1)
                SelectedItem.Quantity++;
                else
                    MessageBox.Show("not enough items in store");
            Quantity = SelectedItem.Quantity;
            getItems();
        }
        public ICommand cmdMinus { get; private set; }

        public void MinusItem()
        {
           
            if (SelectedItem.Quantity-1 > 0)
            {
                SelectedItem.Quantity--;

                Quantity = SelectedItem.Quantity;
                
            }
            else if(SelectedItem.Quantity - 1 == 0)
            {
                MessageBoxResult result= MessageBox.Show("Do you want to delete this item?", "Delete item", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    Items.Remove(SelectedItem);
                }
            }
            else
                MessageBox.Show("not enough items in store");
            Items = OrderCart.Items;
            getItems();


        }

        public void getItems()
        {
            List<ItemForSale> allItems = new List<ItemForSale>();
            foreach(ItemForSale i in Items)
            {
                allItems.Add(i);
            }
            Items = allItems;
            if (SelectedItem != null)
            {
                Quantity = SelectedItem.Quantity;
            }
            else
            {
                Quantity = 0;
            }
        }
        public ICommand cmdClearCart { get; private set; }

        public void ClearCart()
        {
           
                MessageBoxResult result = MessageBox.Show("Do you want to clear order cart?", "Clear cart", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                Items.Clear();
                }
            getItems();
        }

        public ICommand cmdDeleteFromCart { get; private set; }

        public void DeleteFromCart()
        {
           
            MessageBoxResult result = MessageBox.Show("Do you want to delete this item?", "Delete item", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Items.Remove(SelectedItem);
            }
            getItems();
        }

        public ICommand cmdSale { get; private set; }

        public void Sale()
        {
            try { 
                using(DBContext db = new DBContext())
                {
                    double sum = 0;
                    OrderCart.CustomerName = CustomerName;
                    OrderCart.Date = DateTime.Now;
                    string bill = "Customer Name: "+CustomerName+"\n";
                    bill += $"Date: {OrderCart.Date}\n";
                    foreach(ItemForSale item in Items)
                    {                 
                        db.Attach(item.Item);
                      
                        item.Item.Quantity -= item.Quantity;
                        sum+=item.Quantity*item.Item.Price;
                        bill += $"{item.Item.Name}\t{item.Quantity}x{item.Item.Price}={item.Item.Price * item.Quantity}\n";
                    }
                    db.Add(OrderCart);
                    db.SaveChanges();
                    bill += $"Total bill: {sum}";

                    MessageBoxResult res = MessageBox.Show(bill,"Do you want to send the bill on e-mail?", MessageBoxButton.YesNo);
                    if(res == MessageBoxResult.Yes) 
                    {
                        windowService.openSMTPWindow(new SMTPViewModel(bill));
                    }
                    OrderCart = new OrderCart { Items = new List<ItemForSale>() };
                    Items = OrderCart.Items;
                    getComputerDetails();
                    getComputers();
                    getPeripherals();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


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
                    if (string.IsNullOrWhiteSpace(CriteriaComputerDetail))
                    {
                        MessageBox.Show("Please enter a search criteria!");
                        return;
                    }

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
                    PeripheralsList = new ObservableCollection<Peripherals>(db.Peripheralss.ToList());
                    string res = "";
                    foreach (Peripherals pr in PeripheralsList)
                    {
                        res += pr.PeripheralsType.Name;

                    }
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
        public ICommand GetPeripheralsCommand { get; private set; }

        public void AddPeripheral()
        {
            windowService.openPeripheralWindow(new PeripheralViewModel());
            getPeripherals();
        }

        public void EditPeripheral()
        {
            windowService.openPeripheralWindow(new PeripheralViewModel(SelectedPeripherals));
            getPeripherals();
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

                    if (string.IsNullOrWhiteSpace(CriteriaPeripheral))
                    {
                        MessageBox.Show("Please enter a search criteria!");
                        return;
                    }

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

                    if (string.IsNullOrWhiteSpace(CriteriaComputer))
                    {
                        MessageBox.Show("Please enter a search criteria!");
                        return;
                    }

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

        #region statistics
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { 
                startDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }

        private DateTime finalDate;
        public DateTime FinalDate
        {
            get { return finalDate; }
            set
            {
                finalDate = value;
                NotifyPropertyChanged("FinalDate");
            }
        }

        private double money;
        public double Money
        {
            get { return money; }
            set
            {
                money = value;
                NotifyPropertyChanged("Money");
            }
        }

        public ICommand cmdCountMoney { get; private set; }

        void CountMoney()
        {
            if (StartDate > FinalDate)
            {
                MessageBox.Show("Final date should be later then start date");
                return;
            }
            try
            {
                using (DBContext db = new DBContext())
                {
                    List<OrderCart> carts = db.OrderCarts.Where(c => c.Date.Date <= FinalDate && c.Date.Date >= StartDate.Date).ToList();
                    double count = 0;
                    foreach (OrderCart cart in carts)
                    {
                        foreach (ItemForSale item in cart.Items)
                        {
                            count += item.Quantity * item.Item.Price;
                        }
                    }
                    Money = count;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }

}
