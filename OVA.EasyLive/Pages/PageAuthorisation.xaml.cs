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
using OVA.EasyLive.DAL;

namespace OVA.EasyLive.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorisation.xaml
    /// </summary>
    public partial class PageAuthorisation : Page
    {
        public PageAuthorisation()
        {
            InitializeComponent();

            

        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                MainWindow._User.password = pbxPassword.Password;
                MainWindow._User = db.GetAll().FirstOrDefault(
                    f => f.email == MainWindow._User.email &&
                    f.password == MainWindow._User.password);

                if (MainWindow._User != null)
                {
                    MainWindow._MainFrame.Navigate(new PageWellcome());
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
