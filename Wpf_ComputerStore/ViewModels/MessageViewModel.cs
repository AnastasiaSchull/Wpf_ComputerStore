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
    public class MessageViewModel: BaseViewModel
    {
        public Action CloseAction { get; set; }//дiя для закриття вiкна
        public MessageViewModel() 
        {
            windowService = new WindowService();
            cmdYes = new RelayCommand((param) => clickYes());
            cmdNo = new RelayCommand((param) => clickNo());
        }
        public ICommand cmdYes { get; private set; }

        public void clickYes()
        {
            windowService.openPasswordWindow(new PasswordViewModel());
            CloseAction();
        }

        public ICommand cmdNo {get; private set; }

        public void clickNo()
        {
            windowService.openMainWindow(new MainWindowViewModel(false));
            CloseAction();
        }
    }
}
