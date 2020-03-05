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
using OVA.EasyLive.Pages;
using System.Configuration;
using OVA.EasyLive.DAL;

namespace OVA.EasyLive
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string path = ConfigurationManager.AppSettings["ConnectionString"];
        public static Frame _MainFrame;
        public static Menu _MainMenu;
        public static user _User = new user();

        public MainWindow()
        {
            InitializeComponent();
            _MainFrame = MainFrame;
            _MainMenu = menuMainMenu;
            _MainFrame.Navigate(new PageAuthorisation());
        }
    }
}
