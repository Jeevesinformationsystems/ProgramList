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

namespace ProgramList.TelerikPOC

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PlaceHolder.Child = new Views.ProgramListView(ViewModels.ProgramListViewModelHelper.GetRunTimeTypeSampleViewModel());
        }
        
        private void LoadGrid_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (PlaceHolder.Child as Views.ProgramListView).DataContext
                as Common.ViewModels.ProgramListViewModelBase;
            //Task.Run(() =>
            {

                ViewModels.ProgramListViewModelHelper.AssignData(viewModel);

            }
            //).ConfigureAwait(false);
        }
        
    }
}
