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
using SportShop.Pages;

namespace SportShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new Pages.Page1());
        }

        private void sing_Click(object sender, RoutedEventArgs e)
        {
            string username = login.Text;
            string password = pass.Password;

            if (username == "Manager" && password == "12345")
            {
                FrmMain.Navigate(new Pages.Page1());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");

            }
        }
    }
}
