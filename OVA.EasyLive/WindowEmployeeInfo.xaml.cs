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
        user currentUser = null;

        public WindowEmployeeInfo(user user)
        {
            InitializeComponent();
            currentUser = user;
            spUserInfo.DataContext = currentUser;

            using (DataContext<Vacation> db = new DataContext<Vacation>(MainWindow.path))
            {
                lvVacations.ItemsSource = db.GetAll().Where(f=>f.userId == currentUser.Id);
            }
        }

        private void MiDelete_Click(object sender, RoutedEventArgs e)
        {
            string message = "Удалить запись?";
            string caption = "Подтверждение удаления";
            var result =  MessageBox.Show(message, caption, MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
            {
                using(var db = new DataContext<Vacation>(MainWindow.path))
                {
                    var delRec = (Vacation)lvVacations.SelectedItem;
                    db.Delete(delRec.Id);
                    lvVacations.ItemsSource = db.GetAll().Where(f => f.userId == currentUser.Id);
                }
                //MessageBox.Show("Запись удалена");
            }
        }

        private void MiChange_Click(object sender, RoutedEventArgs e)
        {
            var currentRecordVacation = (Vacation)lvVacations.SelectedItem;

            WindowVacationForm windowVacationForm =new WindowVacationForm(currentRecordVacation, currentUser);
            windowVacationForm.Update(this);

        }
    }
}
