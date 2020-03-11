using System;
using System.IO;
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
using OfficeOpenXml;
using ERDOffline.Lib;

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

        private void MiCreateDoc_1_Click(object sender, RoutedEventArgs e)
        {
            Vacation vacation = lvVacations.SelectedItem as Vacation;

            var fileTemplate = new FileInfo(@"C:\Users\Vladimir\source\repos\OVA.EasyLive\OVA.EasyLive\Template\Template_01.xlsx");

            string fullPath = "";

            // For World
            Dictionary<string, string> values = new Dictionary<string, string>();
            

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var pakage = new ExcelPackage(fileTemplate))
            {
                // For Excel
                var sheet = pakage.Workbook.Worksheets["Лист1"];
                sheet.Cells[5, 6].Value = currentUser.name.last;
                sheet.Cells[11, 3].Value = string.Format("с  {0:dd MMMM yyyy} по с  {1:dd MMMM yyyy}", vacation.End, vacation.Start);
                sheet.Cells[12, 4].Value = vacation.Length;
                sheet.Cells[16, 7].Value = string.Format("{0:dd MMMM yyyy} г.", vacation.Start);
                sheet.Cells[18, 7].Value = this.currentUser.name;

                // For World
                values.Add("flmUser", currentUser.name.first.ToString());
                values.Add("startDate", vacation.Start.ToString());
                values.Add("endDate", vacation.Start.ToString());
                values.Add("currentDate", DateTime.Now.ToString()); 


                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Vladimir\source\repos\OVA.EasyLive\OVA.EasyLive\Files\" + currentUser.name.last);

                if (!dir.Exists)
                    dir.Create();

                dir = new DirectoryInfo(@"C:\Users\Vladimir\source\repos\OVA.EasyLive\OVA.EasyLive\Files\" + currentUser.name.last + @"\" + vacation.Type);
                if (!dir.Exists)
                    dir.Create();

                fullPath = string.Format(@"{0}\{1}_{2:ddmmyyyy}.xlsx",
                    dir.FullName,
                    Guid.NewGuid().ToString(),
                    DateTime.Now);

                pakage.SaveAs(File.Create(fullPath));
            }

            DocTools.SearchAndReplace(@"C:\Users\Vladimir\source\repos\OVA.EasyLive\OVA.EasyLive\Template\Template_01.docx",
                fullPath.Replace(".xlsx", ".docx"),
                values, "");

        }
    }
}
