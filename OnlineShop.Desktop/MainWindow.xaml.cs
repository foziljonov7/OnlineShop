﻿using OnlineShop.Desktop.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShop.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
            => this.Close();

        private void AddUserControl(UserControl userControl)
        {
            MenuGrid.Children.Clear();
            MenuGrid.Children.Add(userControl);
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUserControl userControl = new MainUserControl();
            AddUserControl(userControl);
        }
    }
}