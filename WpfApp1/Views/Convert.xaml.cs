﻿using System;
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
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Convert.xaml
    /// </summary>
    public partial class Convert : UserControl
    {
        public Convert()
        {
            InitializeComponent();
            var homeViewModel = new HomeViewModel();
            DataContext = new ConvertViewModel(homeViewModel.Currencies);
        }
    }
}
