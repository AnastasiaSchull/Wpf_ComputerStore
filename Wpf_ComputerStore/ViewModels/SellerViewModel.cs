using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Wpf_ComputerStore.Models;

namespace Wpf_ComputerStore.ViewModels
{
    public class SellerViewModel: BaseViewModel
    {
        private Seller seller;

        public SellerViewModel()
        {
           
            cmdSave = new RelayCommand((param) => Save(), (param) => CanExecute);

        }

        public SellerViewModel(Seller seller)
        {
            this.seller = seller;
           
            Name = seller.Name;
            Email = seller.Email;
            cmdSave = new RelayCommand((param) => Save(), (param) => CanExecute);
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
        public ICommand cmdSave { get; set; }

        public void Save()
        {

            try
            {
                using (DBContext db = new DBContext())
                {
                   
                    if (seller == null)
                    {

                        Seller seller = new Seller { Name = Name, Email=Email};
                        db.Sellers.Add(seller);

                    }
                    else
                    {
                        seller.Name = Name;
                        seller.Email = Email;
                       
                        db.Sellers.Update(seller);
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
            get { return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email); }
        }
    }
}
