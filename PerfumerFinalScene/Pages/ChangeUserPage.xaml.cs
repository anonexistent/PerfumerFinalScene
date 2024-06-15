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
    /// Логика взаимодействия для ChangeUserPage.xaml
    /// </summary>
    public partial class ChangeUserPage : Page
    {
        FigureContext db;
        User ourMostFavoriteUser;

        public ChangeUserPage(User u)
        {
            InitializeComponent();

            db = new();
            ourMostFavoriteUser = u;

            InitNote(ourMostFavoriteUser);
            cbRole.ItemsSource = db.role.ToList();
        }

        private void InitNote(User u)
        {
            Role tempRole = db.role.Where(x=>x.id==u.roleId).FirstOrDefault();

            tbLogin.Text = u.login;
            tbPass.Password = u.password;
            cbRole.SelectedItem = tempRole;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("sure? changes will not be saved!!", "sure?", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes) FrameClass.mainFrame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Role tempRole = (Role)cbRole.SelectedItem;

                if (tbPass.Password == tbPass2.Password)
                {
                    ourMostFavoriteUser.login = tbLogin.Text;
                    ourMostFavoriteUser.password = tbPass.Password;
                    ourMostFavoriteUser.roleId = tempRole.id;

                    db.user.Update(ourMostFavoriteUser);
                    db.SaveChanges();

                    MessageBox.Show("ok");

                    FrameClass.mainFrame.GoBack();
                }
                else MessageBox.Show("password error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
