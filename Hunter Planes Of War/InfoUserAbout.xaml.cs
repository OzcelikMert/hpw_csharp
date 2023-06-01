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
    /// Interaction logic for InfoUserAbout.xaml
    /// </summary>
    public partial class InfoUserAbout : Window {
        public InfoUserAbout() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            RestartInfoRestart();

        }

        public void RestartInfoRestart() {

            ClassPage_DB_2.UserInfo(ClassPage_DB_2.Username, ClassPage_DB_2.Userpw);
            ClassPage_3.RankShow(ClassPage_DB_2.Ranks);
            NickName.Text = ClassPage_DB_2.NickName;
            RankImage.Source = new BitmapImage(new Uri(ClassPage_3.Src, UriKind.Relative));
            RankImageText.Text = ClassPage_3.RankName;
            RankImageText.FontFamily = new FontFamily(ClassPage_3.FontType);
            GCoin.Text = ClassPage_DB_2.Gold.ToString();
            PCoin.Text = ClassPage_DB_2.PC.ToString();
            MatchNumber.Text = ClassPage_DB_2.Matchs.ToString();
            WinMatchNumber.Text = ClassPage_DB_2.WinMatch.ToString();
            LostMatchNumber.Text = ClassPage_DB_2.LostMatch.ToString();

        }

    }
}
