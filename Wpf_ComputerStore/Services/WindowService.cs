using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_ComputerStore.ViewModels;
using Wpf_ComputerStore.Views;

namespace Wpf_ComputerStore.Services
{
    public class WindowService : IWindowService
    {
       
        public void openComputerDetailWindow(BaseViewModel vm)
        {
            ComputerDetailWindow window = new ComputerDetailWindow(vm);
            window.ShowDialog();
        }

        public void openSellerWindow(BaseViewModel vm)
        {
            SellerWindow window = new SellerWindow(vm);
            window.ShowDialog();
        }
        public void openMainWindow(BaseViewModel vm)
        {
           // throw new NotImplementedException();
           MainWindow window = new MainWindow(vm);   
            window.Show();// щоб вікно яке було перед тим мало змогу закритись, а не чекало коли відпрацює MainWindow
        }
        
        public void openComputerWindow(BaseViewModel vm)
        {
            ComputerWindow window = new ComputerWindow(vm);
            window.ShowDialog();
        }

         public void openPasswordWindow(BaseViewModel vm)
        {
            Password window = new Password(vm);                   
            window.Show();// щоб вікно яке було перед тим мало змогу закритись, а не чекало коли відпрацює MainWindow
        }
        
        public void openPeripheralWindow(BaseViewModel vm)
        {
            PeripheralWindow window = new PeripheralWindow(vm);
            window.ShowDialog();          
        }

        public void openSMTPWindow(BaseViewModel vm)
        {
            SMTPWindow window = new SMTPWindow(vm);
            window.ShowDialog();
        }

        public void openCustomerWindow(BaseViewModel vm)
        {
            CustomerWindow window = new CustomerWindow(vm);
            window.ShowDialog();
        }
    }
}
