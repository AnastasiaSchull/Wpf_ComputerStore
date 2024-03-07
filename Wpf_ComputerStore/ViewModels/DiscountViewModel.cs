using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using Wpf_ComputerStore.Services;
using Wpf_ComputerStore.Models;
using System.Windows;
using System.Diagnostics;

namespace Wpf_ComputerStore.ViewModels
{
    public class DiscountViewModel :  BaseViewModel 
    {
        public DiscountViewModel(int tab)
        {
            
            cmdMakeDiscount = new RelayCommand((param) => MakeDiscount(), (param) => CanExecute);
            
            this.tab = tab;            
            Discount = "0";
        }

        private int tab;
        private string discount;

        public string Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                NotifyPropertyChanged("Discount");
            }
        }
      

        private int itemIndex;
        public int ItemIndex
        {
            get { return itemIndex; }
            set
            {
                itemIndex = value;
                NotifyPropertyChanged("ItemIndex");
            }
        }

        
        public ICommand cmdMakeDiscount
        {
            get;
            private set;
        }
   

        public void MakeDiscount()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    int days;
                    if (ItemIndex == 0)
                    {
                        days = 1;
                    }
                    else if (ItemIndex == 1)
                    {
                        days = 7;
                    }
                    else
                    {
                        days = 14;
                    }
                  
                    if (string.IsNullOrEmpty(Discount))
                        Discount = "0";
                    if(tab == 0)
                    {
                        var comps = db.Computers.ToList();
                        foreach (var c in comps)
                        {
                            c.ApplyDiscount(double.Parse(Discount), days);
                        }                       
                    }
                     else if (tab == 1)
                    {
                        var details = db.ComputerDetails.ToList();
                        foreach (var d in details)
                        {
                            d.ApplyDiscount(double.Parse(Discount), days);
                        }
                    }
                    else if (tab == 2)
                    {
                        var peripherals = db.Peripheralss.ToList();
                        foreach (var p in peripherals)
                        {
                            p.ApplyDiscount(double.Parse(Discount), days);
                        }
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
            get
            {
                try
                {
                    int d = Int32.Parse(Discount);
                    return d >= 0 && d < 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}

