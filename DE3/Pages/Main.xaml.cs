using DE3.Model;
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

namespace DE3.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        readonly Entities entities = new Entities();
        public Main(int role)
        {
            InitializeComponent();
            if (role ==2)
            {
                Add.Visibility = Visibility.Collapsed;
            }
           Items.ItemsSource = entities.Product.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage(new Product());
            addEditPage.Show();
            Items.ItemsSource = entities.Product.ToList();
        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage((Product)Items.SelectedItem,true);
            addEditPage.Show();
            Items.ItemsSource = entities.Product.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if ((Product)Items.SelectedItem != null)
            {
                Product product = (Product)Items.SelectedItem;
                MessageBoxResult qwe = MessageBox.Show($"Вы точно хотите удалить {product.ProductName}", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (qwe == MessageBoxResult.Yes)
                {
                    var tdl = entities.Product.Single(o => o.idProduct == product.idProduct);
                    entities.Product.Remove(tdl);
                    entities.SaveChanges();
                }
                Items.ItemsSource = entities.Product.ToList();
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите товар","Товар не выбран", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
