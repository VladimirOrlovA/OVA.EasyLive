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
    /// Логика взаимодействия для WindowVacationForm.xaml
    /// </summary>
    public partial class WindowVacationForm : Window
    {
        static user user = null;
        public WindowVacationForm(user user)
        {
            InitializeComponent();

            dpStart.SelectedDate = DateTime.Now;
            dpEnd.SelectedDate = DateTime.Now;
            dpStart.DisplayDateStart = DateTime.Now;
            dpEnd.DisplayDateStart = DateTime.Now;

            WindowVacationForm.user = user;

            //cbType.ItemsSource = Vacation
        }

        private void DateStartEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? start = dpStart.SelectedDate;
            DateTime? end = dpEnd.SelectedDate;

            if (start != null && end != null)
            {
                double dif = ((DateTime)end - (DateTime)start).TotalDays;
                lbLength.Content = dif;

                if (dpStart.SelectedDate.Value.DayOfWeek == DayOfWeek.Saturday)
                {
                    dpStart.SelectedDate.Value.AddDays(2);
                }
                else if (dpStart.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    dpStart.SelectedDate.Value.AddDays(1);
                }

                if (dif > 0)
                {
                    lbLength.Foreground = Brushes.Green;
                    btnAdd.IsEnabled = true;
                }
                else
                {
                    lbLength.Foreground = Brushes.Red;
                    btnAdd.IsEnabled = false;
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Vacation vacation = new Vacation();
            vacation.Type = cbType.SelectedIndex;
            vacation.Start = (DateTime)dpStart.SelectedDate;
            vacation.End = (DateTime)dpEnd.SelectedDate;
            vacation.Length = Convert.ToDouble(lbLength.Content); 

            vacation.User = WindowVacationForm.user;

            using(DataContext<Vacation> db = new DataContext<Vacation>(MainWindow.path))
            {
                db.Create(vacation);
            }

            this.Close();
        }
    }
}
