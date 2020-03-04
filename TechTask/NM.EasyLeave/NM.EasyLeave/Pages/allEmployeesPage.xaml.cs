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
    /// Логика взаимодействия для allEmployeesPage.xaml
    /// </summary>
    public partial class allEmployeesPage : Page
    {
        public allEmployeesPage()
        {
            InitializeComponent();

            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                lvUsers.ItemsSource = db.GetAll();
            }
        }

        private void TbxEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                lvUsers.ItemsSource = db.GetAll().Where(w => w.name.first.Contains(tbxEmpName.Text));
            }
        }

        private void TbxEmpLastname_KeyUp(object sender, KeyEventArgs e)
        {
            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                lvUsers.ItemsSource = db.GetAll().Where(w => w.name.last.Contains(tbxEmpLastname.Text));
            }
        }
    }
}
