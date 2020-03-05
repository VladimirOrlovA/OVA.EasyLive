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
        private user userAuth = null;
        private string message = "";

        public PageAuthorisation()
        {
            InitializeComponent();
            this.userAuth = MainWindow._User;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (UserSettings.AuthUser(ref userAuth, tbxLogin.Text, pbxPassword.Password, out message))
            {
                MainWindow._MainMenu.Visibility = Visibility.Visible;
                MainWindow._MainFrame.Navigate(new PageWelcome(userAuth));
                MainMenu.GetMenu();
            }
            else
                MessageBox.Show(message);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
