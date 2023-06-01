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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window {
        public MainPage() {
            InitializeComponent();
        }

        private void OnePerson_Click(object sender, RoutedEventArgs e) {
            ClassPage_1.TwoPorOneP = true;
            ClassShowPage.SelectHassle();
            if (ClassPage_1.CloseorNotClose==true) {
                ClassShowPage.PlayGame();
                Hide();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Environment.Exit(1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (ClassPage_DB_2.UserConnect == true) {

                UserInfo.Visibility = Visibility.Visible;

            } else {

                UserInfo.Visibility = Visibility.Hidden;

            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Yapım Aşamasında", "Yapılmamış Pencere", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void MultiPlayer_Click(object sender, RoutedEventArgs e) {
            ClassShowPage.MultiPlayer();
            Hide();
        }

        private void UserInfo_Click(object sender, RoutedEventArgs e) {

            ClassShowPage.InfoWindow();

        }

        private void InfoButton_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("1. oyuncu için kontroller:\n" +
                "********************************\n" +
                "W: Yukarı\nS: Aşağı\nSpace: Ateş\n(Enerji barı yarıdan fazla)R: Can\n(Enerji barı full)R: Güçlü Ateş\n" +
                "********************************\n" +
                "\n\n2. oyuncu için kontroller:\n" +
                "********************************\n" +
                "Up: Yukarı\nDown: Aşağı\nP: Ateş\n(Enerji barı yarıdan fazla)O: Can\n(Enerji barı full)O: Güçlü Ateş\n" +
                "********************************");

        }
    }
}