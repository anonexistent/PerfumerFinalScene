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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        FigureContext db;
        public static Basket curBasket;

        public CatalogPage()
        {
            InitializeComponent();

            db = new();
            //  fill catalogue
            lbCatalog.ItemsSource = db.product.ToList();

            //  creating a new shopping cart
            curBasket = new() { userId = FrameClass.curUser.login, date = DateTime.Now };
            db.basket.Add(curBasket);
            db.SaveChanges();
            curBasket = db.basket.Where(x => x.userId == FrameClass.curUser.login).OrderBy(x=>x.date).LastOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new HomePage());
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new UserPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var tempResult = MessageBox.Show("exit?", "exit?", MessageBoxButton.YesNo);
            if (tempResult == MessageBoxResult.Yes)
            {
                FrameClass.mainFrame.Navigate(new LoginPage());
            }
        }



        private void lbCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BasketList tempList = new() { basketId = curBasket.id, productId = ((Product)((ListBox)sender).SelectedItem).id };
                db.basketList.Add(tempList);
                db.SaveChanges();
                MessageBox.Show("producr has been added in ur basket", "ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить товар в корзину", "Ошибка");
                throw;
            }

        }

        private void Button_Click_Basket(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new BasketPage());
        }
    }
}
