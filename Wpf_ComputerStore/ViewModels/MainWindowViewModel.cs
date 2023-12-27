using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_ComputerStore.Models;

namespace Wpf_ComputerStore.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private List<ComputerDetail> computerDetailsList = new List<ComputerDetail>();
        private List<Category> categoriesList = new List<Category>();
        private List<Computer> computersList = new List<Computer>();

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
            getComputerDetails();
            getCategoriesList();
        }

        public void getComputerDetails()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputerDetailsList = db.ComputerDetails.ToList();
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
    }
}
