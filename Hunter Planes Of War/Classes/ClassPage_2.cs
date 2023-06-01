using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using static System.Net.Mime.MediaTypeNames;

namespace Hunter_Planes_Of_War.Classes {
    class ClassPage_2 {

        public static string TittleText { get; set; }
        public static string XPlus = "XPlus";
        public static string XMinus = "XMinus";
        public static short MoveSpeed { get; set; }
        public static byte Player1NormalDamage = 20;
        public static byte Player2NormalDamage = 20;

        public static void SelectedHassleAndChangesValue(byte HassleValue) {

            if (HassleValue == 1) {

                TittleText = "\"Kolay\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = Player1NormalDamage;
                ClassPage_1.SecondPlayerHealth = 120;
                ClassPage_1.SecondPlayerDamage = 20;
                ClassPage_1.StartTimeValue = 3;
                MoveSpeed = 1000;
                ArtificialIntelligenceMoveClass.Down_Up.Clear();
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);

            } else if (HassleValue == 2) {

                TittleText = "\"Normal\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = Player1NormalDamage;
                ClassPage_1.SecondPlayerHealth = 140;
                ClassPage_1.SecondPlayerDamage = 25;
                ClassPage_1.StartTimeValue = 3;
                MoveSpeed = 500;
                ArtificialIntelligenceMoveClass.Down_Up.Clear();
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);

            } else if (HassleValue == 3) {

                TittleText = "\"Zor\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = Player1NormalDamage;
                ClassPage_1.SecondPlayerHealth = 200;
                ClassPage_1.SecondPlayerDamage = 20;
                ClassPage_1.StartTimeValue = 3;
                MoveSpeed = 250;
                ArtificialIntelligenceMoveClass.Down_Up.Clear();
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);

            } else if (HassleValue == 4) {

                TittleText = "\"Çok Zor\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = 10;
                ClassPage_1.SecondPlayerHealth = 200;
                ClassPage_1.SecondPlayerDamage = 20;
                ClassPage_1.StartTimeValue = 4;
                MoveSpeed = 80;
                ArtificialIntelligenceMoveClass.Down_Up.Clear();
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);

            } else if (HassleValue == 5) {

                TittleText = "\"Efsanevi\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = Player1NormalDamage;
                ClassPage_1.SecondPlayerHealth = 220;
                ClassPage_1.SecondPlayerDamage = 50;
                ClassPage_1.StartTimeValue = 4;
                MoveSpeed = 80;
                ArtificialIntelligenceMoveClass.Down_Up.Clear();
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);

            } else if (HassleValue == 6) {

                TittleText = "\"İmkansız\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = Player1NormalDamage;
                ClassPage_1.SecondPlayerHealth = 260;
                ClassPage_1.SecondPlayerDamage = 100;
                ClassPage_1.StartTimeValue = 5;
                MoveSpeed = 80;
                ArtificialIntelligenceMoveClass.Down_Up.Clear();
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XPlus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);
                ArtificialIntelligenceMoveClass.Down_Up.Add(XMinus);

            } else {

                TittleText = "\"İki Kişilik\" Oyun Modu";
                ClassPage_1.FirstPlayerHealth = 100;
                ClassPage_1.FirstPlayerEnergy = 100;
                ClassPage_1.FirstPlayerDamage = Player1NormalDamage;
                ClassPage_1.SecondPlayerHealth = 100;
                ClassPage_1.SecondPlayerEnergy = 100;
                ClassPage_1.SecondPlayerDamage = Player2NormalDamage;
                ClassPage_1.StartTimeValue = 3;

            }
        }

    }
}
