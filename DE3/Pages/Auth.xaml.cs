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

namespace DE3.Pages
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).View.Content = new Main(1);
            ((MainWindow)Window.GetWindow(this)).Exit.Visibility = Visibility.Visible;
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).View.Content = new Main(2);
            ((MainWindow)Window.GetWindow(this)).Exit.Visibility = Visibility.Visible;
        }
    }
}
