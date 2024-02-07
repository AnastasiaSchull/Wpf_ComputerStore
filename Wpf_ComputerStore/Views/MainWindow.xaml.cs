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
using Wpf_ComputerStore.ViewModels;

namespace Wpf_ComputerStore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow(BaseViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;//щоб розташувати вікно у центрi         
        }

        //public void CloseWindow(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //    MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
        //    mainWindowViewModel._dbContext.Dispose();
        //    mainWindowViewModel._dbContext.Database.CloseConnection();
        //}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)DataContext;
            mainWindowViewModel._dbContext.Dispose();
            mainWindowViewModel._dbContext.Database.CloseConnection();
        }
    }
}
