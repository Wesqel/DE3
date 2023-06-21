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

namespace DE3.NewFolder1
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        readonly int idUser;
        readonly Entities context = new Entities();
        private List<Product> cart;
        public Main(int idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
            if (idUser == 1 )
            {
                Add.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
            }
            else if (idUser == 2 )
            {
                Add.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Collapsed;
                Delete.Visibility = Visibility.Collapsed;
                AddCart.Visibility = Visibility.Collapsed;
                EditCart.Visibility = Visibility.Collapsed;
            }
            Items.ItemsSource = context.Product.ToList();
            cart = new List<Product>();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Не найдено","Не найдено",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            CartPage cartPage = new CartPage(cart);
            cartPage.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage(new Product());
            addEditPage.Show();
            Items.ItemsSource = context.Product.ToList();
        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
var selectedItem = (Product)View.SelectedItem;
    if (selectedItem != null)
    {
        // Создаем копию выбранного товара
        Product cartItem = new Product
        {
            ProductName = selectedItem.ProductName,
            ProductCost = selectedItem.ProductCost,
            ProductNumber = 1, // Устанавливаем количество равным 1
            ProductDiscount = selectedItem.ProductDiscount,
            TotalAmount = selectedItem.ProductCost // Устанавливаем итоговую стоимость равной стоимости товара
        };

        // Уменьшаем количество выбранного товара на 1
        selectedItem.ProductNumber--;

        // Если количество товара стало нулевым, удаляем его из списка
        if (selectedItem.ProductNumber <= 0)
        {
            products.Remove(selectedItem);
        }

        // Добавляем копию товара в корзину
        cartItems.Add(cartItem);

        MessageBox.Show("Товар успешно добавлен в корзину.", "Добавлено в корзину", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage((Product)Items.SelectedItem,true);
            addEditPage.Show();
            Items.ItemsSource = context.Product.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem = (Product)Items.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Точно удалить {selecteditem.ProductName} ?","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var tdl = context.Product.Single(o => o.idProduct == selecteditem.idProduct);
                context.Product.Remove(tdl);
                context.SaveChanges();
                Items.ItemsSource = context.Product.ToList();
            }
        }
    }
}
