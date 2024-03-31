using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_ComputerStore.Services;
using Wpf_ComputerStore.Models;
namespace Wpf_ComputerStore.ViewModels
{
    public class SMTPViewModel: BaseViewModel
    {
        public SMTPViewModel(string mes, Customer c, Seller s)
        {
            Message = mes;
            cmdSend = new RelayCommand((param) => Send());
            ManagerEmail = s.Email;
            ClientEmail = c.Email;
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
        public ICommand cmdSend { get; private set; }
        public void Send()
        {
            SMTPService service = new SMTPService();
            service.Send(ClientEmail, Message, "Bill", Password, ManagerEmail);
        }    

    }
}
