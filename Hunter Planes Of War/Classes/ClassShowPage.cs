using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_Planes_Of_War.Classes {
    class ClassShowPage {

        public static void SelectHassle() {
            SelectHasslePage SHP = new SelectHasslePage();
            SHP.ShowDialog();
        }

        public static void PlayGame() {
            PlayGamePage PGP = new PlayGamePage();
            PGP.Show();
        }

        public static void MultiPlayer() {
            MultiPlayer MP = new MultiPlayer();
            MP.Show();
        }

        public static void MainWindow() {
            MainPage MP = new MainPage();
            MP.Show();
        }

        public static void InternetWindow() {
            InternetWindow_1 IW = new InternetWindow_1();
            IW.Show();
        }

        public static void AddRoomTittle() {
            AddRoomTittle ART = new AddRoomTittle();
            ART.Show();
        }

        public static void FindRoom() {
            FindRooms FR = new FindRooms();
            FR.Show();
        }

        public static void PlayGame_2() {

            PlayGamePage_2 PGP_2 = new PlayGamePage_2();
            PGP_2.Show();

        }

        public static void LoginPage() {

            LoginWindow LW = new LoginWindow();
            LW.ShowDialog();

        }

        public static void InfoWindow() {

            InfoUserAbout IUA = new InfoUserAbout();
            IUA.ShowDialog();

        }

    }
}
