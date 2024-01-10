using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Wpf_ComputerStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Wpf_ComputerStore.ViewModels
{
    public class ComputerViewModel: BaseViewModel
    {
        private Computer computer;
        public ComputerViewModel()
        {
           
            getRams();
            getPowerSupplys();
            getCPUs();
            getHardDrives();
            getMotherboards();
            getSDDs();
            getVideoCards();
            getComputerTypes();
            RAM = RAMs[0];
            PowerSupply= PowerSupplys[0];
            CPU = CPUs[0];
            HardDrive = HardDrives[0];
            SDD= SDDs[0];
            Motherboard = Motherboards[0];
            VideoCard = VideoCards[0];
            ComputerType = ComputerTypes[0];
            cmdAddComputer = new RelayCommand((param) => AddComputer(), (param) => CanExecute);//додали параметр param

        }
        public ComputerViewModel(Computer computer)
        {
            this.computer = computer;
            getComputerTypes(); // наповнюємо список типами і заодно заповнюємо комбобокс через binding
            getRams();
            getPowerSupplys();
            getCPUs();
            getHardDrives();
            getMotherboards();
            getSDDs();
            getVideoCards();
            ComputerType = computer.ComputerType;
            Name = computer.Name;
            RAM = RAMs.Find(r => r.ID == computer.RAM.ID); // щоб в комбобоксі був вибраний поточний RAM комп'ютера
            PowerSupply = PowerSupplys.Find(p => p.ID == computer.PowerSupply.ID);
            CPU = CPUs.Find(c => c.ID == computer.CPU.ID);
            HardDrive = HardDrives.Find(c => c.ID == computer.HardDrive.ID);
            SDD = SDDs.Find(s => s.ID == computer.SDD.ID);
            Motherboard = Motherboards.Find(m => m.ID == computer.Motherboard.ID);
            VideoCard = VideoCards.Find(c => c.ID == computer.VideoCard.ID);
            Quantity = computer.Quantity;
            Price = computer.Price;

            cmdAddComputer = new RelayCommand((param) => AddComputer(), (param) => CanExecute); //команда для додавання або редагування
        }
        private string name;
        public string Name { 
            get { return name; }
            set
            {
                name= value;
                NotifyPropertyChanged("Name");
            }
        }

        #region computertype
        public void getComputerTypes()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputerTypes = db.ComputerTypes.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ComputerType computerType;
        public virtual ComputerType ComputerType
        {
            get { return computerType; }
            set
            {
                computerType = value;
                NotifyPropertyChanged("ComputerType");
            }
        }

        private List<ComputerType> computerTypes;
        public List<ComputerType> ComputerTypes
        {
            get => computerTypes;
            set
            {
                computerTypes = value;
                NotifyPropertyChanged("ComputerTypes");
            }
        }
        #endregion

        private List<ComputerDetail> computerDetails;
        public List<ComputerDetail> ComputerDetails
        {
            get => computerDetails;
            set
            {
                computerDetails = value;
                NotifyPropertyChanged("ComputerDetails");
            }
        }

        #region ram
        public void getRams()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    RAMs = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("RAM")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ComputerDetail ram;
        public ComputerDetail RAM
        {
            get { return ram; }
            set
            {
                ram = value;
                NotifyPropertyChanged("RAM");
            }
        }

        private List<ComputerDetail> rams;
        public List<ComputerDetail> RAMs
        {
            get => rams;
            set
            {
                rams = value;
                NotifyPropertyChanged("RAMs");
            }
        }

        #endregion

        #region motherboard
        public void getMotherboards()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    Motherboards = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("Motherboard")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ComputerDetail motherboard;
        public ComputerDetail Motherboard
        {
            get { return motherboard; }
            set
            {
                motherboard = value;
                NotifyPropertyChanged("Motherboard");
            }
        }
        private List<ComputerDetail> motherboards;
        public List<ComputerDetail> Motherboards
        {
            get => motherboards;
            set
            {
                motherboards = value;
                NotifyPropertyChanged("Motherboards");
            }
        }

        #endregion

        #region cpu

        public void getCPUs()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    CPUs = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("CPU")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ComputerDetail cpu;
        public ComputerDetail CPU
        {
            get { return cpu; }
            set
            {
                cpu = value;
                NotifyPropertyChanged("CPU");
            }
        }
        private List<ComputerDetail> cpus;
        public List<ComputerDetail> CPUs
        {
            get => cpus;
            set
            {
                cpus = value;
                NotifyPropertyChanged("CPUs");
            }
        }
        #endregion

        #region harddrive
        public void getHardDrives()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    HardDrives = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("HardDrive")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ComputerDetail hardDrive;
        public ComputerDetail HardDrive
        {
            get { return hardDrive; }
            set
            {
                hardDrive = value;
                NotifyPropertyChanged("HardDrive");
            }
        }

        private List<ComputerDetail> harddrives;
        public List<ComputerDetail> HardDrives
        {
            get => harddrives;
            set
            {
                harddrives = value;
                NotifyPropertyChanged("HardDrives");
            }
        }

        #endregion


        #region sdd
        public void getSDDs()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    SDDs = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("SDD")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<ComputerDetail> sdds;
        public List<ComputerDetail> SDDs
        {
            get => sdds;
            set
            {
                sdds = value;
                NotifyPropertyChanged("SDDs");
            }
        }
        private ComputerDetail sdd;
        public ComputerDetail SDD
        {
            get { return sdd; }
            set
            {
                sdd = value;
                NotifyPropertyChanged("SDD");
            }
        }

        #endregion

        #region videocard
        public void getVideoCards()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    VideoCards = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("VideoCard")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<ComputerDetail> videoCards;
        public List<ComputerDetail> VideoCards
        {
            get => videoCards;
            set
            {
                videoCards = value;
                NotifyPropertyChanged("VideoCards");
            }
        }


        private ComputerDetail videoCard;
        public ComputerDetail VideoCard
        {
            get { return videoCard; }
            set
            {
                videoCard = value;
                NotifyPropertyChanged("VideoCard");
            }
        }
        #endregion

        #region powersupply
        public void getPowerSupplys()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    PowerSupplys = db.ComputerDetails.Where(cd => cd.Category.Name.Equals("PowerSupply")).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ComputerDetail powerSupply;
        public ComputerDetail PowerSupply
        {
            get { return powerSupply; }
            set
            {
                powerSupply = value;
                NotifyPropertyChanged("PowerSupply");
            }
        }

        private List<ComputerDetail> powerSupplys;
        public List<ComputerDetail> PowerSupplys
        {
            get => powerSupplys;
            set
            {
                powerSupplys = value;
                NotifyPropertyChanged("PowerSupplys");
            }
        }

        #endregion

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }

        public ICommand cmdAddComputer { get; set; }

        public void AddComputer()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.ComputerTypes.Attach(ComputerType);
                    db.ComputerDetails.Attach(RAM);
                    db.ComputerDetails.Attach(Motherboard);
                    db.ComputerDetails.Attach(CPU);
                    db.ComputerDetails.Attach(HardDrive);
                    db.ComputerDetails.Attach(SDD);
                    db.ComputerDetails.Attach(VideoCard);
                    db.ComputerDetails.Attach(PowerSupply);

                    if (computer == null) { 
                        Computer computer = new Computer
                        {
                            Name = Name,
                            ComputerType = ComputerType,
                            ComputerDetails = new List<ComputerDetail>() { RAM, Motherboard, CPU, HardDrive, SDD, VideoCard, PowerSupply },

                            Quantity = Quantity,
                            Price = Price
                        };
                    db.Computers.Add(computer);
                    }
                    else
                    {
                        computer.ComputerType = ComputerType;
                        computer.Name = Name;
                        computer.Quantity = Quantity;
                        computer.Price = Price;
                        //Зв'язок багато до багатьох видалення через команду 
                        db.Database.ExecuteSql($"Delete from [dbo].[ComputerComputerDetail] WHERE ComputersID={computer.ID}");
                        //Створюємо нові зв'язки багато до багатьох
                        computer.ComputerDetails=new List<ComputerDetail>() { RAM, Motherboard, CPU, HardDrive, SDD, VideoCard, PowerSupply };
                        db.Computers.Update(computer);
                    }
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool CanExecute //для команди (коли повертає false, то кнопка Save не клікабельна)
        {
            get { return !string.IsNullOrEmpty(Name)  && Quantity != 0 && Price != 0; }
        }

    }
}


  