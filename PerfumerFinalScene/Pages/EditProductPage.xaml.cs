using Microsoft.Win32;
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
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        FigureContext db;

        public EditProductPage()
        {
            InitializeComponent();

            db = new();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float tempPrice = (float)Math.Round(float.Parse(tbPrice.Text), 2);

                if (tempPrice < 0)
                {
                    MessageBox.Show("Неправильная стоимость");
                    return;
                }
                int tempType = db.productType.Where(x => x.name == cbType.Text).Select(x => x.id).FirstOrDefault();
                db.product.Add(new Product() { name=tbFirst.Text, description = image.Source.ToString(), price=tempPrice, typeId = tempType });
                db.SaveChanges();
                MessageBox.Show("item has been added");
                tbPrice.Text = "";
                tbFirst.Text = "";
                cbType.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.mainFrame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.JPG, *.PNG, | *.jpg; *.png;";
            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                image.Source = new BitmapImage(new Uri(fileName));
            }
        }
    }
}
