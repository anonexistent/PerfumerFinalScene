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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        FigureContext db;

        public EditUserPage()
        {
            InitializeComponent();
            
            db = new();
            dgMain.ItemsSource = db.user.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.Navigate(new AddNewUserPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                User curItem = (User)dgMain.SelectedItem;
                UserProfile curProfile = db.userProfile.Where(x => x.userId == curItem.login).FirstOrDefault();
                db.userProfile.Remove(curProfile);
                db.SaveChanges();
                db.user.Remove(curItem);
                db.SaveChanges(); 
                dgMain.ItemsSource = db.user.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                User selectedUser = (User)dgMain.SelectedItem;
                FrameClass.mainFrame.Navigate(new ChangeUserPage(selectedUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = db.user.ToList();
        }
    }
}
