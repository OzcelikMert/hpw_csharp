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

namespace Hunter_Planes_Of_War
{
    /// <summary>
    /// Interaction logic for PlayGamePage_2.xaml
    /// </summary>
    public partial class PlayGamePage_2 : Window
    {
        public PlayGamePage_2()
        {
            InitializeComponent();
        } 

            private Coord LeftBanner_ = new Coord(0, 0);
            private Coord RightBanner_ = new Coord(45, 0);
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            //TimerTick();
           // RestartValues();
            this.Title = ClassPage_2.TittleText;
            Canvas.SetLeft(LeftBanner, LeftBanner_.CanvasX);
            Canvas.SetTop(LeftBanner, LeftBanner_.CanvasY);
            Canvas.SetLeft(RightBanner, RightBanner_.CanvasX);
            Canvas.SetTop(RightBanner, RightBanner_.CanvasY);
            ReturnCoord(false);



            // StartTime.Foreground = Brushes.Green;
            // StartTime.Text = ClassPage_DB_2.StartTimeValue.ToString();
            // StartTimer.Start(); // aynı zamanda energy için kullanılıyor.


        }

        //bool CloseWindow = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            
            ClassShowPage.InternetWindow();

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e) {

        }

        private void HittedGif_AnimationCompleted(object sender, RoutedEventArgs e) {

        }

        private void HittedGif2_AnimationCompleted(object sender, RoutedEventArgs e) {

        }

        private void HealthGif_AnimationCompleted(object sender, RoutedEventArgs e) {

        }

        private void HealthGif2_AnimationCompleted(object sender, RoutedEventArgs e) {

        }

        private Coord Player_1 = new Coord(0, 0);
        private Coord Player_2 = new Coord(0, 0);
        public void ReturnCoord(bool OnePlayerF_TwoPlayerT) {

            if (OnePlayerF_TwoPlayerT == false) {

            Player_1 = new Coord(ClassPage_DB.X_Sort, ClassPage_DB.Y_Sort);
            Canvas.SetTop(FirstPlayer, Player_1.CanvasY);
            Canvas.SetLeft(FirstPlayer, Player_1.CanvasX);

            } else if (OnePlayerF_TwoPlayerT) {

            Player_2 = new Coord(ClassPage_DB.X_2_Sort, ClassPage_DB.Y_2_Sort); // füzzeler için yeni bir cordinat sistemi oluştur.
            Canvas.SetTop(SecondPlayer, Player_2.CanvasY);
            Canvas.SetLeft(SecondPlayer, Player_2.CanvasX);

            }

        }

        public void RestartValues() {

           /* if (MoveNuke_1) {
                th1.Abort();
            }
            if (MoveNuke_2) {
                th2.Abort();
            }
            if (MoveEnergyNuke_1) {
                th3.Abort();
            }
            if (MoveEnergyNuke_2) {
                th4.Abort();
            }*/
           // StopAllTimers();
          /*  HittedGif.Visibility = Visibility.Hidden;
            HittedGif2.Visibility = Visibility.Hidden;
         //   ImageBehavior.SetAnimatedSource(HittedGif, (ImageSource)FindResource("NukeBang"));
         //   ImageBehavior.SetAnimatedSource(HittedGif2, (ImageSource)FindResource("NukeBang"));
            PlaneOne.Visibility = Visibility.Visible;
            PlaneTwo.Visibility = Visibility.Visible;
         //   ClassPage_2.SelectedHassleAndChangesValue(ClassPage_1.HassleValue);
       /*     ReturnHealthAndEnergyBar(ClassPage_1.FirstPlayerHealth, ClassPage_1.FirstPlayerEnergy, ClassPage_1.SecondPlayerHealth, ClassPage_1.SecondPlayerEnergy);
            ArtificialIntelligenceMove.Interval = new TimeSpan(0, 0, 0, 0, ClassPage_2.MoveSpeed);
            ReturnCoord();
            Player1Nuke_ReturnCoord();
            Player1EnergyNuke_ReturnCoord();
            Player2EnergyNuke_ReturnCoord();
            Player2Nuke_ReturnCoord();*/
          /*  FPNuke1.Visibility = Visibility.Hidden;
            FPNuke2.Visibility = Visibility.Hidden;
            FullEnergyNuke_Player1.Visibility = Visibility.Hidden;
            FullEnergyNuke_Player2.Visibility = Visibility.Hidden;
         /*   LockScreenB1.Visibility = Visibility.Visible;
            LockScreen.Visibility = Visibility.Hidden;*/
         /*   ClassPage_1.PlayOrBreak = true;
            ClassPage_1.FirstPlayerReturnNuke = false;
            ClassPage_1.SecondPlayerReturnNuke = false;
            ClassPage_1.PlaneBang_1 = false;
            ClassPage_1.PlaneBang_2 = false;
            StartTime.Visibility = Visibility.Visible;
            StartTime.Foreground = Brushes.Green;
            StartTime.Text = ClassPage_1.StartTimeValue.ToString();
      /*      LockScreenTB1.Text = "Oyun Durduruldu";
            StartTimer.Interval = new TimeSpan(0, 0, 0, 1);
            StartTimer.Start();
            if (ClassPage_1.TwoPorOneP == false) {
                EnergyBarTwo.Visibility = Visibility.Hidden;
                ArtificialIntelligenceMove.Start();
            }
            */
        }

    }
}
