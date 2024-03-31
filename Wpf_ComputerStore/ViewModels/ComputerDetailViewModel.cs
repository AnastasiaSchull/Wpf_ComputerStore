using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_ComputerStore.Models;

namespace Wpf_ComputerStore.ViewModels
{
    public class ComputerDetailViewModel : BaseViewModel
    {
        private ComputerDetail computerDetail;

        public ComputerDetailViewModel()
        {
            getCategories();
            Category = Categories[0];
            cmdAddComputerDetail = new RelayCommand((param) => AddComputerDetail(), (param) => CanExecute);
        }

        public ComputerDetailViewModel(ComputerDetail computerDetail)
        {
            this.computerDetail = computerDetail;
            getCategories();
            Category = Categories.Find(c => c.ID == computerDetail.Category.ID);
            Name = computerDetail.Name;
            Quantity = computerDetail.Quantity;
            Description = computerDetail.Description;
            Price = computerDetail.Price;
            cmdAddComputerDetail = new RelayCommand((param) => AddComputerDetail(), (param) => CanExecute);
        }

        void getCategories()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    Categories = db.Categories.ToList();
                }
            }
            catch (Exception e) { }
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
        private Category category;
        public Category Category
        {
            get => category;
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                NotifyPropertyChanged("Categories");
            }
        }
        #endregion

        public ICommand cmdAddComputerDetail { get; set; }

        public void AddComputerDetail()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Attach(Category);
                    if (computerDetail == null)
                    {
                        ComputerDetail computerDetail = new ComputerDetail { Name = Name, Quantity = Quantity, Category = Category, Description = Description, Price = Price };
                        db.ComputerDetails.Add(computerDetail);
                    }
                    else
                    {
                        computerDetail.Name = Name;
                        computerDetail.Quantity = Quantity;
                        computerDetail.Category = Category;
                        computerDetail.Price = Price;
                        computerDetail.Description = Description;
                        db.ComputerDetails.Update(computerDetail);
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
