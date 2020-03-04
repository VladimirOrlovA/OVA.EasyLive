using NM.EasyLeave.Pages;
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
using NM.EasyLeave.DAL;
using System.Configuration;

namespace NM.EasyLeave
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static user user = new user();
        public static string path = 
            ConfigurationManager.AppSettings["ConnectionString"];

        public static Frame _mainFrame = null;

        public static Menu _mainMenu = null;
        public MainWindow()
        {
            InitializeComponent();
            _mainFrame = MainFrame;
            _mainMenu = mainMenu;
            MainFrame.Navigate(new AuthPage());
        }
    }
}
