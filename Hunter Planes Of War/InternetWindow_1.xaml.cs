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
using Hunter_Planes_Of_War.Classes;

namespace Hunter_Planes_Of_War {
    /// <summary>
    /// Interaction logic for InternetWindow_1.xaml
    /// </summary>
    public partial class InternetWindow_1 : Window {
        public InternetWindow_1() {
            InitializeComponent();
        }

        bool CloseWindow = false;
        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void AddRoom_Click(object sender, RoutedEventArgs e) {
            CloseWindow = true;
            ClassPage_DB.MaxUser = 2;
            ClassShowPage.AddRoomTittle();
            Close();
        }

        private void FindRoom_Click(object sender, RoutedEventArgs e) {
            CloseWindow = true;
            ClassPage_DB.MaxUser = 2;
            ClassShowPage.FindRoom();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (CloseWindow == false) {
                ClassShowPage.MultiPlayer();
            } else {
                ;
            }
        }

    }
}
