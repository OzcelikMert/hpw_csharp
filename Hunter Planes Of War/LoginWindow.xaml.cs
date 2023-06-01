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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(SavedUserName.Text) || string.IsNullOrEmpty(SavedUserPassword.Password)) {

                MessageBox.Show("Lütfen boş yer bırakmayınız!", "HATA", MessageBoxButton.OK, MessageBoxImage.Information);

            } else {

                ClassPage_DB_2.LoginControl(SavedUserName.Text, SavedUserPassword.Password);
                if (ClassPage_DB_2.UserConnect == true) {
                    if (Remember.IsChecked == true) {
                        Properties.Settings.Default["RememberValue"] = SavedUserName.Text;
                        Properties.Settings.Default["ValueChecked"] = true;
                        Properties.Settings.Default.Save();
                    } else {
                        Properties.Settings.Default["ValueChecked"] = false;
                        Properties.Settings.Default.Save();
                    }
                    ClassShowPage.MainWindow();
                    LoaderWindow.CloseWindow = true;
                    Close();
                } else {
                    MessageBox.Show("Kullanıcı Adı veya Şifre yanlış!", "Hatalı Giriş", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void Remember_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Yapım aşamasında!","HATA",MessageBoxButton.OK,MessageBoxImage.Stop);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (Convert.ToBoolean(Properties.Settings.Default["ValueChecked"]) == true) {
                SavedUserName.Text = Properties.Settings.Default["RememberValue"].ToString();
                Remember.IsChecked = true;
            } else {
                SavedUserName.Text = "";
                Remember.IsChecked = false;
            }


        }
    }
}
