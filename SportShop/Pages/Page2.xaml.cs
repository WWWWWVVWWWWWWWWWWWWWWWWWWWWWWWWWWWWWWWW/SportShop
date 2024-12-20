using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SportShop.ApplicationData;

namespace SportShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public ObservableCollection<Product> Products { get; set; }

        public Page2(ObservableCollection<Product> products)
        {
            InitializeComponent();
            Products = products;
            ProductList.ItemsSource = Products;
        }

        private void ProductList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductList.SelectedItem is Product selectedProduct)
            {
                NameBox.Text = selectedProduct.Name;
                PriceBox.Text = selectedProduct.Price.ToString();
                DescriptionBox.Text = selectedProduct.Description;
            }
        }
        public Page2()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                Name = NameBox.Text,
                Price = decimal.Parse(PriceBox.Text),
                Description = DescriptionBox.Text,
            };
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem is Product selectedProduct)
            {
                selectedProduct.Name = NameBox.Text;
                selectedProduct.Price = decimal.Parse(PriceBox.Text);
                selectedProduct.Description = DescriptionBox.Text;

                ProductList.Items.Refresh();
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            NameBox.Clear();
            PriceBox.Clear();
            DescriptionBox.Clear();
            ProductList.SelectedItem = null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
