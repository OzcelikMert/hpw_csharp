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
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window {
        public MultiPlayer() {
            InitializeComponent();
        }
        bool CloseWindow = false;
        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void TwoPerson_Click(object sender, RoutedEventArgs e) {
            CloseWindow = true;
            ClassPage_1.TwoPorOneP = true;
            ClassPage_1.HassleValue = 0;
            ClassShowPage.PlayGame();
            Close();
        }

        private void Online_Click(object sender, RoutedEventArgs e) {
            if (ClassPage_1.GuestorSaveduser == ClassPage_1.valueP) {

                CloseWindow = true;
                ClassShowPage.InternetWindow();
                Close();

            } else {

                MessageBox.Show("\"İnternet\" modunu oynaya bilmeniz için \"Üye Girişi\" yapmalısınız.", "Lütfen Kayıt Olunuz", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            }

        }

        private void Network_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Yapım Aşamasında", "Yapılmamış Pencere", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (CloseWindow == false) {
                ClassShowPage.MainWindow();
            } else {
                ;
            }
        }
    }
}
