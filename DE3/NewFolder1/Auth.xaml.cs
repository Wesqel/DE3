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

namespace DE3.NewFolder1
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

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = new Main(0);
            ((MainWindow)Window.GetWindow(this)).Logut.Visibility = Visibility.Visible;
        }

        private void Moderator_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = new Main(1);
            ((MainWindow)Window.GetWindow(this)).Logut.Visibility = Visibility.Visible;
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).MainFrame.Content = new Main(2);
            ((MainWindow)Window.GetWindow(this)).Logut.Visibility = Visibility.Visible;
        }
    }
}
