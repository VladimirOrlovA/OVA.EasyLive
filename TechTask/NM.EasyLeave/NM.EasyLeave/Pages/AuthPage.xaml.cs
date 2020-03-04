using NM.EasyLeave.DAL;
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


namespace NM.EasyLeave.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private user _user = null;
        public AuthPage()
        {
            InitializeComponent();
            this._user = MainWindow.user;

            spAuthWrapper.DataContext = MainWindow.user;

        }

        private string message = "";
        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserSettings.AuthUser(ref _user, tbxLogin.Text, pbxPassword.Password, out message))
            {
                MainWindow._mainMenu.Visibility = Visibility.Visible;
                MainWindow._mainFrame.Navigate(new WelcomePage(_user));
            }
            else
                MessageBox.Show(message);
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
