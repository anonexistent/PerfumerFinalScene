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
    /// Логика взаимодействия для AddNewUserPage.xaml
    /// </summary>
    public partial class AddNewUserPage : Page
    {
        FigureContext db;

        public AddNewUserPage()
        {
            InitializeComponent();

            db = new();
            cbRole.ItemsSource = db.role.ToList();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("exactly cancel?", "exactly cancel?", MessageBoxButton.YesNo);
            if(result==MessageBoxResult.Yes) FrameClass.mainFrame.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Role tempRole = (Role)cbRole.SelectedItem;

                foreach (var item in db.user)
                {
                    if(item.login == tbLogin.Text)
                    {
                        MessageBox.Show("login error");
                        return;
                    }
                }

                if (tbPass.Password == tbPass2.Password)
                {
                    User newUser = new() { login = tbLogin.Text, password = tbPass.Password, roleId = tempRole.id };
                    db.user.Add(newUser);
                    db.SaveChanges();
                    db.userProfile.Add(new() { userId = tbLogin.Text, firstName = "н/д", secondName = "н/д", thirdName = "н/д", age = 0, photo = "", totalMoney = 0 });
                    db.SaveChanges();

                    MessageBox.Show("new user has been added");

                    ClearForm();
                }
                else MessageBox.Show("password error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            tbLogin.Text = "";
            tbPass.Password = "";
            tbPass2.Password = "";
            cbRole.SelectedItem = null;
        }
    }
}
