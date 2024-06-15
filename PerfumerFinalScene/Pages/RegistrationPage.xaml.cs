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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        FigureContext db;

        public RegistrationPage()
        {
            InitializeComponent();
            db = new();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.GoBack();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            //  database new user +profile (default role buyer)
            var tempList = db.user;

            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPass.Password) || string.IsNullOrWhiteSpace(tbPass2.Password))
            {
                MessageBox.Show("Пустые поля нельзя","error");
                return;
            }

            foreach (var item in tempList)
            {
                if (item.login == tbLogin.Text)
                {
                    MessageBox.Show("curUser eror");
                    return;
                }
            }
            if (tbPass.Password != tbPass2.Password)
            {
                MessageBox.Show("password eror");
                return;
            }
            User newUser = new() { login = tbLogin.Text, password = tbPass.Password, roleId = 2 };
            db.user.Add(newUser);
            db.userProfile.Add(new() { userId=tbLogin.Text, firstName="н/д", secondName = "н/д", thirdName = "н/д", age=0, photo="", totalMoney=0 });
            db.SaveChanges();

            MessageBox.Show("welcome");
            FrameClass.mainFrame.GoBack();
        }
    }
}
