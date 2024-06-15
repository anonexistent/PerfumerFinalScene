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
using PerfumerFinalScene.DataBaseCore;

namespace PerfumerFinalScene.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        FigureContext db;
        UserProfile curUser;

        public UserPage()
        {
            InitializeComponent();

            db = new();
            curUser = db.userProfile.Where(x => x.userId == FrameClass.curUser.login).FirstOrDefault();

            Init();
        }

        private void Init()
        {
            tbFirst.Text = curUser.firstName;
            tbSecond.Text = curUser.secondName;
            tbThird.Text = curUser.thirdName;
            tbAge.Text = curUser.age.ToString();
            tbMoney.Text = curUser.totalMoney.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("save changes?", "save changes?", MessageBoxButton.YesNo);
            if(result==MessageBoxResult.No) FrameClass.mainFrame.GoBack();
            else
            {
                curUser.firstName = tbFirst.Text;
                curUser.secondName = tbSecond.Text;
                curUser.thirdName = tbThird.Text;

                try
                {
                    curUser.age = int.Parse(tbAge.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                db.userProfile.Update(curUser);
                db.SaveChanges();

                FrameClass.mainFrame.GoBack();
            }
        }
    }
}
