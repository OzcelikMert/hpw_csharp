using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Hunter_Planes_Of_War.Classes;

namespace Hunter_Planes_Of_War {
    /// <summary>
    /// Interaction logic for LoaderWindow.xaml
    /// </summary>
    public partial class LoaderWindow : Window {
        public LoaderWindow() {
            InitializeComponent();
        }

        public static bool CloseWindow = false;
        private void Login_Click(object sender, RoutedEventArgs e) {
            ClassShowPage.LoginPage();
            if (CloseWindow == true) {
            ClassPage_1.GuestorSaveduser = ClassPage_1.valueP;
                Hide();
            }
        }

        private void LoginGuest_Click(object sender, RoutedEventArgs e) {
            ClassPage_1.GuestorSaveduser = ClassPage_1.valueN;
            ClassShowPage.MainWindow();
            Hide();
        }

        private void GoWebSite_Click(object sender, RoutedEventArgs e) {
            Process.Start("https://ozceliksoftware.com/");
        }
    }
}
