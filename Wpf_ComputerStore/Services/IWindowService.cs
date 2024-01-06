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
        void openComputerDetailWindow(BaseViewModel model);
       
        void openMainWindow(BaseViewModel model);
        void openComputerWindow(BaseViewModel model);
    }
}
