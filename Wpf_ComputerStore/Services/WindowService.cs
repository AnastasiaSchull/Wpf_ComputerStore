﻿using System;
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
        public void openComputerDetailWindow(BaseViewModel model)
        {
            ComputerDetailWindow window = new ComputerDetailWindow(model);
            window.ShowDialog();
        }

        public void openMainWindow(BaseViewModel model)
        {
            throw new NotImplementedException();
        }
        public void openComputerWindow(BaseViewModel model)
        {
            ComputerWindow window = new ComputerWindow(model);
            window.ShowDialog();
        }
    }
}
