using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using WpfAnimatedGif;

namespace Hunter_Planes_Of_War.Classes {
    class ClassPage_3 {

        public static MediaPlayer Sound;

        public static void PlayNukeBangSound(string Src) {
            var UriSrc = new Uri(Src, UriKind.Relative);
            Sound = new MediaPlayer() { ScrubbingEnabled = false };
            Sound.MediaFailed += Sound_MediaFailed;
            Sound.Open(UriSrc);
            Sound.Play();
        }

        public static void Sound_MediaFailed(object sender, ExceptionEventArgs e) {
            Sound.Play();

        }

        public static string RankName { get; set; }
        public static string FontType {get; set;}
        public static string Src { get; set; }

         public static void RankShow(byte NumberValue) {

            if (NumberValue == 0) {

                Src = "Images/RankIcons/Rank_1.png";
                FontType = "Bauhaus 93";
                RankName = "Acemi";

            } else if (NumberValue == 1) {

                Src = "Images/RankIcons/Rank_2.png";
                FontType = "Britannic Bold";
                RankName = "Savaş Görmüş";

            } else if (NumberValue == 2) {

                Src = "Images/RankIcons/Rank_3.png";
                FontType = "Cooper Black";
                RankName = "Usta Savaşcı";

            } else if (NumberValue == 3) {

                Src = "Images/RankIcons/Rank_4.png";
                FontType = "Cooper Black";
                RankName = "Büyük Lord";

            } else if (NumberValue == 4) {

                Src = "Images/RankIcons/Rank_5.png";
                FontType = "Blazed";
                RankName = "Kral";

            } else if (NumberValue == 5) {

                Src = "Images/RankIcons/Rank_6.png";
                FontType = "Ariosto";
                RankName = "Yenilmez Kral - I";

            } else if (NumberValue == 6) {

                Src = "Images/RankIcons/Rank_7.png";
                FontType = "Ariosto";
                RankName = "Yenilmez Kral - II";

            } else if (NumberValue == 7) {

                Src = "Images/RankIcons/Rank_8.png";
                FontType = "Ariosto";
                RankName = "Yenilmez Kral - III";

            } else {

                Src = null;
                RankName = "Yok";
                FontType = "Arial";

            }

        }
        
    }
}
