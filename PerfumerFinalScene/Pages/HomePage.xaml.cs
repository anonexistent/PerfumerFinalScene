using PerfumerFinalScene.DataBaseCore;
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

namespace PerfumerFinalScene.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        FigureContext db;

        public HomePage()
        {
            InitializeComponent();

            db = new();

            var temp = (Window)FrameClass.mainFrame.Parent;
            temp.Height = 600;
            temp.Width = 950;

            if(FrameClass.curUser.roleId==2) btnAdd.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new UserPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var tempResult = MessageBox.Show("exit?", "exit?", MessageBoxButton.YesNo);
            if(tempResult == MessageBoxResult.Yes)
            {
                FrameClass.mainFrame.Navigate(new LoginPage());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new CatalogPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (FrameClass.curUser.roleId == 0) FrameClass.mainFrame.Navigate(new EditUserPage());
            else FrameClass.mainFrame.Navigate(new EditProductPage());
        }

        private void btnBasket_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new BasketPage());
        }
    }
}
