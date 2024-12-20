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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<OrderItem> Order { get; set; } = new();
        public Page1()
        {
            InitializeComponent();
            LoadTestData();
        }
        private void LoadTestData()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Футбольный мяч", Price = 1500, Description = "Мяч для игры на улице", ImagePath = "Images/ball.jpg" },
                new Product { Name = "Теннисная ракетка", Price = 12000, Description = "Профессиональная ракетка", ImagePath = "Images/racket.jpg" },
                new Product { Name = "Спортивная бутылка", Price = 500, Description = "Бутылка для воды", ImagePath = "Images/bottle.jpg" }
            };

            ProductList.ItemsSource = Products;
        }

        private void ProductList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductList.SelectedItem is Product selectedProduct)
            {
                var orderItem = Order.FirstOrDefault(o => o.Product.Name == selectedProduct.Name);

                if (orderItem != null)
                    orderItem.Quantity++;
                else
                    Order.Add(new OrderItem { Product = selectedProduct, Quantity = 1 });

                UpdateOrderSummary();
            }
        }

        private void UpdateOrderSummary()
        {
            OrderList.ItemsSource = null;
            OrderList.ItemsSource = Order;

            TotalPriceText.Text = $"Итого: {Order.Sum(o => o.TotalPrice):C}";
            ViewOrder.IsEnabled = Order.Count > 0;
        }

        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
