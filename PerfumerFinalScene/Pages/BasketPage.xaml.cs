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
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        FigureContext db;
        double deliveryPrice;
        Basket curBasket;

        public BasketPage()
        {
            InitializeComponent();

            db = new();
            deliveryPrice = new Random().Next(100, 200) + new Random().NextDouble();
            tbDel.Text = deliveryPrice.ToString("0.00");

            InitList();
            InitCombos();
        }

        private void InitCombos()
        {
            cbPay.ItemsSource = db.paymentMethod.ToList();
            cbShop.ItemsSource = db.shop.ToList();
        }

        private void InitList()
        {
            curBasket = null;
            List<Product> basketList = new();
            double totalBasket = 0.0f;

            try
            {
                curBasket = CatalogPage.curBasket;
                var tempIdList = db.basketList.Where(x=>x.basketId==curBasket.id).Select(x=>x.productId).ToList();

                foreach (var item in tempIdList)
                {
                    var tempProduct = db.product.Where(x => x.id == item).FirstOrDefault();
                    totalBasket += tempProduct.price;
                    basketList.Add(tempProduct);
                }

                lbCatalog.ItemsSource = basketList;
                double totalBasketExactly = totalBasket + deliveryPrice;
                tbTotalMoney.Text = Math.Round(totalBasketExactly,2).ToString();

            }
            catch (Exception ex)
            {
                return;
            }

            btnEmptyBasket.Visibility = Visibility.Collapsed;
            lbCatalog.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var tempResult = MessageBox.Show("exit?", "exit?", MessageBoxButton.YesNo);
            if (tempResult == MessageBoxResult.Yes)
            {
                FrameClass.mainFrame.Navigate(new LoginPage());
            }
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new UserPage());
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.GoBack();
        }

        private void btnEmptyBasket_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new HomePage());
        }

        private void lbCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(((ListBox)sender).SelectedItem.ToString());
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if(cbPay.SelectedItem==null || cbShop.SelectedItem==null)
            {
                MessageBox.Show("Необходимо сделать выбор", "Ошибка");
                return;
            }

            try
            {
                curBasket.payId = ((PaymentMethod)(cbPay.SelectedItem)).id;
                curBasket.shopId = ((Shop)(cbShop.SelectedItem)).id;
                curBasket.statusId = 1;
                db.basket.Update(curBasket);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            MessageBox.Show("thank u for order. goodbye", "thank u");
            FrameClass.mainFrame.Navigate(new CatalogPage());
        }
    }
}
