using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_ComputerStore.ViewModels;


namespace Wpf_ComputerStore.Services
{
    public interface IWindowService
    {
        void openComputerDetailWindow(BaseViewModel viewModel);      
        void openMainWindow(BaseViewModel viewModel);
        void openSellerWindow(BaseViewModel viewModel);
        void openComputerWindow(BaseViewModel viewModel);
        void openPasswordWindow(BaseViewModel viewModel);
        void openPeripheralWindow(BaseViewModel viewModel);
        void openSMTPWindow(BaseViewModel viewModel);
        void openCustomerWindow(BaseViewModel viewModel);
        void OpenDiscountWindow(BaseViewModel viewModel);
    }
}
