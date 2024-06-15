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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        FigureContext db;

        public LoginPage()
        {
            InitializeComponent();
            db = new();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            //  database dialog
            var checkUser = db.user.Where(x=>x.login==tbLogin.Text).FirstOrDefault();
            if (checkUser!=null)
            {
                if(checkUser.password==tbPass.Password)
                {
                    FrameClass.curUser = checkUser;
                    FrameClass.mainFrame.Navigate(new HomePage());
                }
                else
                {
                    MessageBox.Show("password error");
                }
            }
            else
            {
                MessageBox.Show("user was not found", "error");
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            //  registration
            FrameClass.mainFrame.Navigate(new RegistrationPage());
        }
    }
}
