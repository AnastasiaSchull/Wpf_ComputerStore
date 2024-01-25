using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_ComputerStore.Services;

namespace Wpf_ComputerStore.ViewModels
{
   public class PasswordViewModel: BaseViewModel
    {
        public PasswordViewModel() 
        {
            Pass = "";
            windowService = new WindowService();
            cmdLogIn = new RelayCommand((param) => clickLogIn()) ;      
        }
        public ICommand cmdLogIn { get; private set; }
       
        public void clickLogIn()
        {
            if(Pass.Equals("1234"))
            {
                windowService.openMainWindow(new MainWindowViewModel(true));
            }
            else
            {
                MessageBox.Show("Incorrect password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set
            {
                pass = value;
                NotifyPropertyChanged(nameof(Pass));
            }
        }
      
    }
}
