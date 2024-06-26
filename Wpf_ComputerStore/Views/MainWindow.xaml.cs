﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_ComputerStore.Models;
using Wpf_ComputerStore.ViewModels;

namespace Wpf_ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isLight;
        public MainWindow(BaseViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            isLight = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;//щоб розташувати вікно у центрi         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
           isLight=!isLight;
            if (isLight)
            {
                Properties.Settings.Default.ColorMode = "Light";
            }
            else
            {
                Properties.Settings.Default.ColorMode = "Dark";
            }
                Properties.Settings.Default.Save();

        }
    }
}
