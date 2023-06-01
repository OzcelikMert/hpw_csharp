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
    /// Interaction logic for FindRooms.xaml
    /// </summary>
    public partial class FindRooms : Window {
        public FindRooms() {
            InitializeComponent();
        }
        // Odaya katılma yapılacak. Aynı zamanda odaya katılan kişi odadan da atılabiliecek (Oda sahibi tarafından) Oyuncu odaya girdiğinde hemen ucak resminin altında Tik işareti ve X işareti olacak Tik işaretine tıklarsa oyun başlayacak(Geri sayımdan sonra) X işaretine tıklarsa oyuncuyu odadan atacak.
        bool CloseWindow = false;
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            ShowList();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (CloseWindow==false) {
                ClassShowPage.InternetWindow();
            } else {
                ;
            }
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {

            var TittleRoom = ClassPage_DB.RoomsList[RoomList.SelectedIndex];
          MessageBoxResult  query_1 =  MessageBox.Show(string.Format("\"{0}\" isimli odaya katılmak istediğinize eminmisiniz?" ,TittleRoom.ToString()),"Odaya Katılma",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (MessageBoxResult.Yes == query_1) {
                CloseWindow = true;
                ClassPage_DB.RoomName_Public = TittleRoom.ToString();
                ClassPage_DB.UserSortInfo(TittleRoom.ToString());
                ClassPage_DB.UserAddtoRoom(ClassPage_DB.UserSortValue, TittleRoom.ToString());
                ClassShowPage.PlayGame_2();
                Close();

            } else {
                ;
            }



        }

        private void RestartList_Click(object sender, RoutedEventArgs e) {

            ShowList();

        }

        private void ShowList() {

            ClassPage_DB.FindRoom();
            RoomList.Items.Clear();
            int SortRoomNumber = 0;
            foreach (var item in ClassPage_DB.RoomsList) {
                SortRoomNumber++;
                RoomList.Items.Add(new RoomListName(item.ToString()));
            }
            if (SortRoomNumber>0) {
                FreeRoom.Visibility = Visibility.Hidden;
            } else {
                FreeRoom.Visibility = Visibility.Visible;
            }

        }

        public class RoomListName {

            public RoomListName(string RoomName) {
                this.RoomName = RoomName;
            }
            public string RoomName { get; set; }
        }

    }
}
