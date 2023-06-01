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
using MySql.Data.MySqlClient;

namespace Hunter_Planes_Of_War {
    /// <summary>
    /// Interaction logic for AddRoomTittle.xaml
    /// </summary>
    public partial class AddRoomTittle : Window {
        public AddRoomTittle() {
            InitializeComponent();
        }
        bool CloseWindow = false;
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            NewRoomName.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (CloseWindow == false) {
            ClassShowPage.InternetWindow();
            } else {
                ;
            }
        }

        private void SaveNewRoomName_Click(object sender, RoutedEventArgs e) {

            ClassPage_DB.AddRoom(NewRoomName.Text);
            ClassPage_DB.FindRoom();
            CloseWindow = true;
            ClassShowPage.PlayGame_2();
            Close();

        }
    }
}
