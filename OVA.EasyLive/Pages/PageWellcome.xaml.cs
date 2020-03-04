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

namespace OVA.EasyLive.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageWellcome.xaml
    /// </summary>
    public partial class PageWellcome : Page
    {
        public PageWellcome()
        {
            InitializeComponent();
            tbWelcomeMess.Text = "Приветствую " + MainWindow._User.name;
        }
    }
}
