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
    /// Interaction logic for PageAllEmployees.xaml
    /// </summary>
    public partial class PageAllEmployees : Page
    {
        public PageAllEmployees()
        {
            InitializeComponent();

            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                lvUsers.ItemsSource = db.GetAll();
            }
        }

        private void TbxEmpFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                // формируем список согласно маске ввода
                lvUsers.ItemsSource = db.GetAll().Where(f => f.name.first.Contains(tbxEmpFirstName.Text));
            }
        }

        private void TbxEmpLastname_KeyUp(object sender, KeyEventArgs e)
        {
            using (DataContext<user> db = new DataContext<user>(MainWindow.path))
            {
                // формируем список согласно маске ввода
                lvUsers.ItemsSource = db.GetAll().Where(f => f.name.last.Contains(tbxEmpLastname.Text));
            }
        }
    }
}

