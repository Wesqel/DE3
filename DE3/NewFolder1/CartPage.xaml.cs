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
using System.Windows.Shapes;

namespace DE3.NewFolder1
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Window
    {
        readonly Entities entities = new Entities();
        private List<Product> cartProducts = new List<Product>();

        public List<Product> CartProducts
        {
            get { return cartProducts; }
            set { cartProducts = value; }
        }

        public List<string> DeliveryPlaces { get; set; } = new List<string> { "Москва", "Санкт-Петербург", "Екатеринбург" };

        public string SelectedDeliveryPlace { get; set; } = "Москва";

        public DateTime OrderDate { get; set; } = DateTime.Today;

        public CartPage(List<Product> products)
        {
            InitializeComponent();
            CartProducts = products;
            CartView.ItemsSource = CartProducts;
        }

        private void DeleteFromCart_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)CartView.SelectedItem;
            if (selectedProduct != null)
            {
                CartProducts.Remove(selectedProduct);
                CartView.ItemsSource = CartProducts;
            }
        }

        private void GenerateCodeButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int code = random.Next(100, 1000);
            CodeLabel.Content = $"Код: {code}";
        }

        private void ExportToPdfButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Завершен", "Завершен вывод", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
