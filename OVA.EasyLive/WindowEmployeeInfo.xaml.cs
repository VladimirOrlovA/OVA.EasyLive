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
using System.Windows.Shapes;
using OVA.EasyLive.DAL;

namespace OVA.EasyLive
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployeeInfo.xaml
    /// </summary>
    public partial class WindowEmployeeInfo : Window
    {
        public WindowEmployeeInfo(user user)
        {
            InitializeComponent();
            spUserInfo.DataContext = user;

            using (DataContext<Vacation> db = new DataContext<Vacation>(MainWindow.path))
            {
                lvVacations.ItemsSource = db.GetAll();
            }
        }
    }
}
