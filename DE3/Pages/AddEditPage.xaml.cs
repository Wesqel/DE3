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
using System.Data.Entity;
using Microsoft.Win32;
using System.IO;

namespace DE3.Pages
{
    /// <summary>
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {
        readonly Entities entities = new Entities();
        readonly  bool editMode;
        readonly Product curproduct;
        public AddEditPage(Product product, bool editMode = false)
        {
            InitializeComponent();
            this.curproduct = product;
            this.editMode = editMode;
            DataContext = curproduct;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (editMode)
            {
                entities.Entry(curproduct).State = curproduct.idProduct == 0 ? EntityState.Added : EntityState.Modified;
            }
            else
            {
                var idcount = entities.Product.OrderByDescending(o => o.idProduct).FirstOrDefault() ?.idProduct ?? 0;
                var count = idcount + 1;
                curproduct.idProduct = count;
                entities.Entry(curproduct).State = curproduct.idProduct == count ? EntityState.Added : EntityState.Modified;
            }
            entities.SaveChanges();
            this.Close();
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog()
            {
                Title = "Выберите фото",
                Filter = "Файл фотографий|*png;*jpg;*jfif",
                Multiselect = false,
            };
            filedialog.ShowDialog();
            if (filedialog.FileName == "")
            {
                return;
            }
            byte[] fileasbyte = File.ReadAllBytes(filedialog.FileName);
            curproduct.Photo = fileasbyte;
            Photo.Source = new BitmapImage(new Uri(filedialog.FileName));
        }
    }
}
