using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Wpf_ComputerStore.Models;
using Castle.Core.Resource;

namespace Wpf_ComputerStore.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public Customer customer;                        
        public CustomerViewModel()
        {           
            getCustomers();
            AddCommand = new RelayCommand((param) => AddCustomer(), (param) => CanExecute);
        }

        public CustomerViewModel(Customer customer)
        {
            
            getCustomers();
            this.customer = customer;
            Name = customer.Name;
            Email = customer.Email;
            AddCommand = new RelayCommand((param) => AddCustomer(), (param) => CanExecute);
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                NotifyPropertyChanged(nameof(Customer));
            }
        }

        private List<Customer> customers;
        public List<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
                NotifyPropertyChanged(nameof(Customers));
            }
        }

    
        void getCustomers()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    Customers = db.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ICommand AddCommand { get; set; }

        public void AddCustomer()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    if (customer == null)
                    {
                        Customer сustomer = new Customer { Name = Name, Email = Email, Points = 100 };
                        db.Customers.Add(сustomer);
                    }
                    else
                    {
                        customer.Name = Name;
                        customer.Email = Email;
                        db.Customers.Update(customer);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CanExecute
        {
            get { return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email); }
        }
    }
}
