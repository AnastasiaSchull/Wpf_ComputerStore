using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;
using Wpf_ComputerStore.Models;
using Wpf_ComputerStore.Commands;

namespace Wpf_ComputerStore.ViewModels
{
    public class ComputerViewModel: BaseViewModel
    {
        public List <Computer> Computers;
        public ComputerViewModel()
        {
            getComputers();
           
            cmdAddComputer = new RelayCommand((param) => AddComputer(), (param) => CanExecute);//додали параметр param

        }
        public void getComputers()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    Computers = db.Computers.ToList();
                }
            }
            catch (Exception e) { }
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
                NotifyPropertyChanged("RAM");
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
                NotifyPropertyChanged("CPU");
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
        private List<ComputerDetail> sdds;
        public List<ComputerDetail> SDDs
        {
            get => sdds;
            set
            {
                sdds = value;
                NotifyPropertyChanged("SDD");
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
        private List<ComputerDetail> videoCards;
        public List<ComputerDetail> VideoCards
        {
            get => videoCards;
            set
            {
                videoCards = value;
                NotifyPropertyChanged("VideoCard");
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
                NotifyPropertyChanged("PowerSupply");
            }
        }
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
                    db.Attach(ComputerType);
                    db.Attach(RAM);
                    db.Attach(Motherboard);
                    db.Attach(CPU);
                    db.Attach(HardDrive);
                    db.Attach(SDD);
                    db.Attach(VideoCard);
                    db.Attach(PowerSupply);

                    Computer computer = new Computer
                    {
                        Name = Name,
                        ComputerType = ComputerType,
                        RAM = RAM,
                        Motherboard = Motherboard,
                        CPU = CPU,
                        HardDrive = HardDrive,
                        SDD = SDD,
                        VideoCard = VideoCard,
                        PowerSupply = PowerSupply,
                        Quantity = Quantity,
                        Price = Price
                    };
                    db.Computers.Add(computer);
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
            get { return !string.IsNullOrEmpty(Name)  && Quantity != 0 && Price != 0; }
        }

    }
}


  