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
    /// Interaction logic for SelectHasslePage.xaml
    /// </summary>
    public partial class SelectHasslePage : Window {
        public SelectHasslePage() {
            InitializeComponent();
        }

        private void EasySelect_Checked(object sender, RoutedEventArgs e) {
            MessageBoxResult Cevap = MessageBox.Show("\"Kolay\" modu seçtiniz. Devam Edilsin mi ?", "Zorluk", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Cevap == MessageBoxResult.Yes) {
                ClassPage_1.HassleValue = 1;
                ClassPage_1.TwoPorOneP = false;
                ClassPage_1.CloseorNotClose = true;
                Close();
            } else {
                EasySelect.IsChecked = false;
            }
        }

        private void NormalSelect_Checked(object sender, RoutedEventArgs e) {
            MessageBoxResult Cevap = MessageBox.Show("\"Normal\" modu seçtiniz. Devam Edilsin mi ?", "Zorluk", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Cevap == MessageBoxResult.Yes) {
                ClassPage_1.HassleValue = 2;
                ClassPage_1.TwoPorOneP = false;
                ClassPage_1.CloseorNotClose = true;
                Close();
            } else {
                NormalSelect.IsChecked = false;
            }
        }

        private void HardSelect_Checked(object sender, RoutedEventArgs e) {
            MessageBoxResult Cevap = MessageBox.Show("\"Zor\" modu seçtiniz. Devam Edilsin mi ?", "Zorluk", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Cevap == MessageBoxResult.Yes) {
                ClassPage_1.HassleValue = 3;
                ClassPage_1.TwoPorOneP = false;
                ClassPage_1.CloseorNotClose = true;
                Close();
            } else {
                HardSelect.IsChecked = false;
            }
        }

        private void Hard2Select_Checked(object sender, RoutedEventArgs e) {
            MessageBoxResult Cevap = MessageBox.Show("\"Çok Zor\" modu seçtiniz. Devam Edilsin mi ?", "Zorluk", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Cevap == MessageBoxResult.Yes) {
                ClassPage_1.HassleValue = 4;
                ClassPage_1.TwoPorOneP = false;
                ClassPage_1.CloseorNotClose = true;
                Close();
            } else {
                Hard2Select.IsChecked = false;
            }
        }

        private void LegendarySelect_Checked(object sender, RoutedEventArgs e) {
            MessageBoxResult Cevap = MessageBox.Show("\"Efsanevi\" modu seçtiniz. Devam Edilsin mi ?", "Zorluk", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Cevap == MessageBoxResult.Yes) {
                ClassPage_1.HassleValue = 5;
                ClassPage_1.TwoPorOneP = false;
                ClassPage_1.CloseorNotClose = true;
                Close();
            } else {
                LegendarySelect.IsChecked = false;
            }
        }

        private void ImpossibleSelect_Checked(object sender, RoutedEventArgs e) {
            MessageBoxResult Cevap = MessageBox.Show("\"İmkansız\" modu seçtiniz. Devam Edilsin mi ?", "Zorluk", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Cevap == MessageBoxResult.Yes) {
                ClassPage_1.HassleValue = 6;
                ClassPage_1.TwoPorOneP = false;
                ClassPage_1.CloseorNotClose = true;
                Close();
            } else {
                ImpossibleSelect.IsChecked = false;
            }
        }

        private void CloseIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            ClassPage_1.CloseorNotClose = false;
            Close();
        }

    }
}
