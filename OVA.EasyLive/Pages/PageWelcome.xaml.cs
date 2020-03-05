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
    /// Логика взаимодействия для PageWellcome.xaml
    /// </summary>
    public partial class PageWelcome : Page
    {
        public PageWelcome(user user)
        {
            InitializeComponent();
            //tbWelcomeMess.Text = "Приветствую " + MainWindow._User.name;
            tbWelcomeMess.Text = "Приветствую " + user.name.first + "!";
        }
    }
}
