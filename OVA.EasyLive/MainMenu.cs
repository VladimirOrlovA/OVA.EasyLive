using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using OVA.EasyLive.Pages;

namespace OVA.EasyLive
{
    public class MainMenu
    {

        public static void GetMenu()
        {
            
            MenuItem administration = new MenuItem() { Header = "Administration" };
            MenuItem manageLeave = new MenuItem() { Header = "Manage Leave" };
            MenuItem manageEmployee = new MenuItem() { Header = "Manage Employee" };
            MenuItem manageLeaveSanction = new MenuItem() { Header = "Manage Leave Sanction" };
            MenuItem reports = new MenuItem() { Header = "Reports" };
            MenuItem logout = new MenuItem() { Header = "Logout" };

            #region menu events
            manageLeave.Click += ManageLeave_Click;
            #endregion

            #region  subMenu Administration
            MenuItem changePassword = new MenuItem() { Header = "Change Password" };
            MenuItem manageDepartment = new MenuItem() { Header = "Manage Department" };
            MenuItem manageCountry = new MenuItem() { Header = "Manage Country" };
            MenuItem manageState = new MenuItem() { Header = "Manage State" };
            MenuItem manageCity = new MenuItem() { Header = "Manage City" };
            MenuItem manageStatus = new MenuItem() { Header = "Manage Status" };

            administration.Items.Add(changePassword);
            administration.Items.Add(manageDepartment);
            administration.Items.Add(manageCountry);
            administration.Items.Add(manageState);
            administration.Items.Add(manageCity);
            administration.Items.Add(manageStatus);
            #endregion

            #region fill MainMenu
            MainWindow._MainMenu.Items.Add(administration);
            MainWindow._MainMenu.Items.Add(manageLeave);
            MainWindow._MainMenu.Items.Add(manageEmployee);
            MainWindow._MainMenu.Items.Add(manageLeaveSanction);
            MainWindow._MainMenu.Items.Add(reports);
            MainWindow._MainMenu.Items.Add(logout);
            #endregion

            MainWindow._MainMenu.Background = Brushes.LightCyan;
            MainWindow._MainMenu.Foreground = Brushes.DarkBlue;

        }

        private static void ManageLeave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new PageAllEmployees());
            //throw new NotImplementedException();
        }
    }
}
// https://colormania.ru.uptodown.com/windows