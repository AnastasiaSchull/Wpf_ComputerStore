using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_ComputerStore.Services;

namespace Wpf_ComputerStore.ViewModels
{
    public class SMTPViewModel: BaseViewModel
    {
        public SMTPViewModel(string mes)
        {
            Message = mes;
            cmdSend = new RelayCommand((param) => Send());
          
        }

        private string password;
        public string Password
        { 
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        private string managerEmail;
        public string ManagerEmail
        {
            get { return managerEmail; }
            set
            {
                managerEmail = value;
                NotifyPropertyChanged("ManagerEmail");
            }
        }

        private string clientEmail;
        public string ClientEmail
        {
            get { return clientEmail; }
            set
            {
                clientEmail = value;
                NotifyPropertyChanged("ClientEmail");
            }
        }
        public string Message { get; set; }

      
        public void Send()
        {
            SMTPService service = new SMTPService();
            service.Send(ClientEmail, Message, "Bill", Password, ManagerEmail);
        }

        public ICommand cmdSend { get; private set; }

    }
}
