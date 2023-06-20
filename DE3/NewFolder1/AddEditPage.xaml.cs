using DE3.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {
        readonly Product curproduct;
        readonly bool editMode;
        readonly Entities entities = new Entities();
        public AddEditPage(Product product,bool editMode = false)
        {
            InitializeComponent();
            this.curproduct = product;
            this.editMode = editMode;
            DataContext = curproduct;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (editMode == true)
            {
                entities.Entry(curproduct).State = EntityState.Modified;
            }
            else
            {
                int idcount = entities.Product.OrderByDescending(o => o.idProduct).FirstOrDefault()?.idProduct ?? 0;
                int id = idcount + 1;
                curproduct.idProduct = id;
                entities.Entry(curproduct).State = curproduct.idProduct == id ? EntityState.Added : EntityState.Modified;
            }
            entities.SaveChanges();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Фото добавлено!","Фото",MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
