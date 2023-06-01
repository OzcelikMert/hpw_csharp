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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;
using Hunter_Planes_Of_War.Classes;
using System.Threading;

namespace Hunter_Planes_Of_War {
    /// <summary>
    /// Interaction logic for PlayGamePage.xaml
    /// </summary>
    public partial class PlayGamePage : Window {
        public PlayGamePage() {
            InitializeComponent();
        }
        // Yavaşlık sorununu gidermek için 2. Bir Coord Classı aç birde öyle dene.
        private Coord LeftBanner_ = new Coord(0, 0);
        private Coord RightBanner_ = new Coord(45, 0);

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            RestartValues();
            TimerTick();
            this.Title = ClassPage_2.TittleText;
            Canvas.SetLeft(LeftBanner,LeftBanner_.CanvasX);
            Canvas.SetTop(LeftBanner, LeftBanner_.CanvasY);
            Canvas.SetLeft(RightBanner, RightBanner_.CanvasX);
            Canvas.SetTop(RightBanner, RightBanner_.CanvasY);
            StartTime.Foreground = Brushes.Green;
            StartTime.Text = ClassPage_1.StartTimeValue.ToString();
            StartTimer.Start(); // aynı zamanda energy için kullanılıyor.

        }

        bool WindowClosed = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

            if (WindowClosed==false) {
                StopAllTimers();
                ClassShowPage.MainWindow();
            }

        }

        DispatcherTimer StartTimer = new DispatcherTimer();
        private void StartTimer_Tick(object sender, EventArgs e) {
            // Başlangıç sayması ve enerji dolması
            if (ClassPage_1.StartTimeValue != -1) {
                ClassPage_1.StartTimeValue -= 1;
            }
            if (ClassPage_1.StartTimeValue > 0) {
                if (ClassPage_1.StartTimeValue == 2) {
                    StartTime.Foreground = Brushes.Orange;
                } else if (ClassPage_1.StartTimeValue == 1) {
                    StartTime.Foreground = Brushes.Red;
                }
                StartTime.Text = ClassPage_1.StartTimeValue.ToString();
            } else if (ClassPage_1.StartTimeValue == 0) {
                ClassPage_1.StartTimeValue -= 1;
                StartTime.Foreground = Brushes.Blue;
                StartTime.Text = "BAŞLA";
                ClassPage_1.PlayOrBreak = false;
            } else {
                StartTime.Visibility = Visibility.Hidden;
                if (EnergyBarOne.Value != EnergyBarOne.Maximum) {
                    EnergyBarOne.Value += 10;
                    if (EnergyBarOne.Value < (EnergyBarOne.Maximum / 2) ) {
                        EnergyBarOne.Foreground = Brushes.Orange;
                    } else if ((EnergyBarOne.Value >= (EnergyBarOne.Maximum / 2)) && (EnergyBarOne.Value != EnergyBarOne.Maximum) ) {
                        EnergyBarOne.Foreground = Brushes.Aqua;
                    } else {
                    EnergyBarOne.Foreground = Brushes.Red;
                    }
                }

                if (ClassPage_1.TwoPorOneP == false) {
                    ;
                } else {

                  if (EnergyBarTwo.Value != EnergyBarTwo.Maximum) {
                    EnergyBarTwo.Value += 10;
                        if (EnergyBarTwo.Value < (EnergyBarTwo.Maximum / 2)) {
                            EnergyBarTwo.Foreground = Brushes.Orange;
                        } else if ((EnergyBarTwo.Value >= (EnergyBarTwo.Maximum / 2)) && (EnergyBarTwo.Value != EnergyBarTwo.Maximum)) {
                            EnergyBarTwo.Foreground = Brushes.Aqua;
                        } else {
                            EnergyBarTwo.Foreground = Brushes.Red;
                        }
                    }

                }

            }

        }

        bool MoveNuke_1 = false;
        public void PlayerNuke1_Move() {

            // 1. oyuncu füze hareketi
            while (MoveNuke_1 == true) {

                Thread.Sleep(10);
                this.Dispatcher.BeginInvoke(new Action(() =>
               {

                    Player1Nuke.X++;
                    Canvas.SetLeft(FPNuke1, Player1Nuke.CanvasX);
                    if ((Player1Nuke.CanvasX == Player_2.CanvasX - 34) && (Player1Nuke.CanvasY == Player_2.CanvasY)) {
                        ClassPage_3.PlayNukeBangSound("Sounds/NukeBangSounds/NukeBang2.wav");
                        FPNuke1.Visibility = Visibility.Hidden;
                        HittedGif2.Visibility = Visibility.Visible;
                        ImageBehavior.SetRepeatBehavior(HittedGif2, new RepeatBehavior(2));
                        ImageBehavior.SetRepeatBehavior(HittedGif2, new RepeatBehavior(0.5));
                        ClassPage_1.SecondPlayerHealth -= ClassPage_1.FirstPlayerDamage;
                        HealthBarTwo.Value = ClassPage_1.SecondPlayerHealth;
                        ClassPage_1.FirstPlayerReturnNuke = false;
                        ClassPage_1.FirstPlayerNukeMoveBool = false;
                        if (ClassPage_1.SecondPlayerHealth <= 0) {
                            ClassPage_1.PlaneBang_2 = true;
                            LockScreenB1.Visibility = Visibility.Hidden;
                            StopAllTimers();
                            ClassPage_1.PlayOrBreak = true;
                            LockScreenTB1.Text = "1. Oyuncu Kazandı!!";
                            LockScreen.Visibility = Visibility.Visible;
                            ClassPage_3.PlayNukeBangSound("Sounds/Winner/WinToPlayer_1.wav");
                        }
                        MoveNuke_1 = false;
                        th1.Abort();
                    } else if (Player1Nuke.CanvasX == RightBanner_.CanvasX) {
                        FPNuke1.Visibility = Visibility.Hidden;
                        Player1Nuke_ReturnCoord();
                        ClassPage_1.FirstPlayerReturnNuke = false;
                        ClassPage_1.FirstPlayerNukeMoveBool = false;
                        MoveNuke_1 = false;
                        th1.Abort();
                    }

                }));
                
            }
           
        }

        bool MoveNuke_2 = false;
        public void PlayerNuke2_Move() {

            // 2. oyuncu füze hareketi
            while (MoveNuke_2 == true) {

                Thread.Sleep(10);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    Player2Nuke.X--;
                    Canvas.SetLeft(FPNuke2, Player2Nuke.CanvasX);
                    if ((Player2Nuke.CanvasX == Player_1.CanvasX + 34) && (Player2Nuke.CanvasY == Player_1.CanvasY)) {
                        ClassPage_3.PlayNukeBangSound("Sounds/NukeBangSounds/NukeBang2.wav");
                        FPNuke2.Visibility = Visibility.Hidden;
                        HittedGif.Visibility = Visibility.Visible;
                        ImageBehavior.SetRepeatBehavior(HittedGif, new RepeatBehavior(2));
                        ImageBehavior.SetRepeatBehavior(HittedGif, new RepeatBehavior(0.5));
                        ClassPage_1.FirstPlayerHealth -= ClassPage_1.SecondPlayerDamage;
                        HealthBarOne.Value = ClassPage_1.FirstPlayerHealth;
                        ClassPage_1.SecondPlayerReturnNuke = false;
                        ClassPage_1.SecondPlayerNukeMoveBool = false;
                        if (ClassPage_1.FirstPlayerHealth <= 0) {
                            ClassPage_1.PlaneBang_1 = true;
                            LockScreenB1.Visibility = Visibility.Hidden;
                            StopAllTimers();
                            ClassPage_1.PlayOrBreak = true;
                            LockScreenTB1.Text = "2. Oyuncu Kazandı";
                            LockScreen.Visibility = Visibility.Visible;
                            if (ClassPage_1.TwoPorOneP == true) {
                                ClassPage_3.PlayNukeBangSound("Sounds/Winner/WinToPlayer_2.wav");
                            } else if (ClassPage_1.TwoPorOneP == false) {
                                ClassPage_3.PlayNukeBangSound("Sounds/Lost/Lost.wav");
                            }
                        }
                        MoveNuke_2 = false;
                        th2.Abort();
                    } else if (Player2Nuke.CanvasX == LeftBanner_.CanvasX) {
                        FPNuke2.Visibility = Visibility.Hidden;
                        Player2Nuke_ReturnCoord();
                        ClassPage_1.SecondPlayerReturnNuke = false;
                        ClassPage_1.SecondPlayerNukeMoveBool = false;
                        MoveNuke_2 = false;
                        th2.Abort();
                    }

                }));
               
          }

        }

        bool MoveEnergyNuke_1 = false;
        public void PlayerEnergyNuke1_Move() {

           // 1. oyuncu özel güç olayları
            while (MoveEnergyNuke_1 == true) {

                Thread.Sleep(25);
                this.Dispatcher.BeginInvoke(new Action(() => {

                    Player1EnergyNuke.X++;
                    Canvas.SetLeft(FullEnergyNuke_Player1, Player1EnergyNuke.CanvasX);
                    if ((Player1EnergyNuke.CanvasX == Player_2.CanvasX + 34) && ((Player1EnergyNuke.CanvasY == Player_2.CanvasY) || (Player1EnergyNuke.CanvasY == Player_2.CanvasY + 30) || (Player1EnergyNuke.CanvasY == Player_2.CanvasY - 30))) {
                        ClassPage_3.PlayNukeBangSound("Sounds/NukeBangSounds/NukeBang2.wav");
                        FullEnergyNuke_Player1.Visibility = Visibility.Hidden;
                        HittedGif2.Visibility = Visibility.Visible;
                        ImageBehavior.SetRepeatBehavior(HittedGif2, new RepeatBehavior(2));
                        ImageBehavior.SetRepeatBehavior(HittedGif2, new RepeatBehavior(1));
                        ClassPage_1.FirstPlayerDamage = EventPowerClass.FPDamage;
                        ClassPage_1.SecondPlayerHealth -= ClassPage_1.FirstPlayerDamage;
                        HealthBarTwo.Value = ClassPage_1.SecondPlayerHealth;
                        ClassPage_1.FirstPlayerDamage = ClassPage_2.Player1NormalDamage;
                        ClassPage_1.FirstPlayerEnergyNukeMoveBool = false;
                        if (ClassPage_1.SecondPlayerHealth <= 0) {
                            ClassPage_1.PlaneBang_2 = true;
                            LockScreenB1.Visibility = Visibility.Hidden;
                            StopAllTimers();
                            ClassPage_1.PlayOrBreak = true;
                            LockScreenTB1.Text = "1. Oyuncu Kazandı";
                            LockScreen.Visibility = Visibility.Visible;
                            ClassPage_3.PlayNukeBangSound("Sounds/Winner/WinToPlayer_1.wav");
                        }

                        MoveEnergyNuke_1 = false;
                        th3.Abort();
                    } else if (Player1EnergyNuke.CanvasX == RightBanner_.CanvasX) {
                        FullEnergyNuke_Player1.Visibility = Visibility.Hidden;
                        ClassPage_1.FirstPlayerEnergyNukeMoveBool = false;
                        MoveEnergyNuke_1 = false;
                        th3.Abort();
                    }

                }));

            }

        }

        bool MoveEnergyNuke_2 = false;
        public void PlayerEnergyNuke2_Move() {

            // 2. oyuncu özel güç olayları
            while (MoveEnergyNuke_2 == true) {

                Thread.Sleep(25);
                this.Dispatcher.BeginInvoke(new Action(() => {

                    Player2EnergyNuke.X--;
                    Canvas.SetLeft(FullEnergyNuke_Player2, Player2EnergyNuke.CanvasX);
                    if ((Player2EnergyNuke.CanvasX == Player_1.CanvasX + 34) && ((Player2EnergyNuke.CanvasY == Player_1.CanvasY) || (Player2EnergyNuke.CanvasY == Player_1.CanvasY + 30) || (Player2EnergyNuke.CanvasY == Player_1.CanvasY - 30))) {
                        ClassPage_3.PlayNukeBangSound("Sounds/NukeBangSounds/NukeBang2.wav");
                        FullEnergyNuke_Player2.Visibility = Visibility.Hidden;
                        HittedGif.Visibility = Visibility.Visible;
                        ImageBehavior.SetRepeatBehavior(HittedGif, new RepeatBehavior(2));
                        ImageBehavior.SetRepeatBehavior(HittedGif, new RepeatBehavior(1));
                        ClassPage_1.SecondPlayerDamage = EventPowerClass.SPDamage;
                        ClassPage_1.FirstPlayerHealth -= ClassPage_1.SecondPlayerDamage;
                        HealthBarOne.Value = ClassPage_1.FirstPlayerHealth;
                        ClassPage_1.SecondPlayerDamage = ClassPage_2.Player2NormalDamage;
                        ClassPage_1.SecondPlayerEnergyNukeMoveBool = false;
                        if (ClassPage_1.FirstPlayerHealth <= 0) {
                            ClassPage_1.PlaneBang_1 = true;
                            LockScreenB1.Visibility = Visibility.Hidden;
                            StopAllTimers();
                            ClassPage_1.PlayOrBreak = true;
                            LockScreenTB1.Text = "2. Oyuncu Kazandı";
                            LockScreen.Visibility = Visibility.Visible;
                            ClassPage_3.PlayNukeBangSound("Sounds/Winner/WinToPlayer_2.wav");
                        }

                        MoveEnergyNuke_2 = false;
                        th4.Abort();
                    } else if (Player2EnergyNuke.CanvasX == LeftBanner_.CanvasX) {
                        FullEnergyNuke_Player2.Visibility = Visibility.Hidden;
                        ClassPage_1.SecondPlayerEnergyNukeMoveBool = false;
                        MoveEnergyNuke_2 = false;
                        th4.Abort();
                    }

                }));

            }

        }

        DispatcherTimer ArtificialIntelligenceMove = new DispatcherTimer();
        private void ArtificialIntelligenceMove_Tick(object sender, EventArgs e) {
            // Yapay Zeka Hareketi
            if (ClassPage_1.PlayOrBreak==false) {
            ArtificialIntelligenceMoveClass.Moving();
                if (ArtificialIntelligenceMoveClass.Down_Up_Value == ClassPage_2.XPlus) {

                    if (Player_2.Y > 0) {
                    Player_2.Y--;
                    Canvas.SetTop(SecondPlayer, Player_2.CanvasY);
                    } else {
                        ;
                    }

                } else if(ArtificialIntelligenceMoveClass.Down_Up_Value == ClassPage_2.XMinus) {

                    if (Player_2.Y < 11) {
                        Player_2.Y++;
                        Canvas.SetTop(SecondPlayer, Player_2.CanvasY);
                    } else {
                        ;
                    }

                }

                if (Player_2.CanvasY == Player_1.CanvasY) {
                    if (ClassPage_1.SecondPlayerReturnNuke==false) {
                        ClassPage_1.SecondPlayerNukeMoveBool = true;
                        ClassPage_1.SecondPlayerReturnNuke = true;
                        FPNuke2.Visibility = Visibility.Visible;
                        Player2Nuke_ReturnCoord();
                        MoveNuke_2 = true;
                        th2 = new Thread(PlayerNuke2_Move);
                        th2.Start();                        // Füze olayını hallet ve Yapay zekada enerji barı gösterme
                    }
                }

            } else {
                ;
            }

        }

        private void HittedGif_AnimationCompleted(object sender, RoutedEventArgs e) {
            if (ClassPage_1.PlaneBang_1==true) {
                PlaneOne.Visibility = Visibility.Hidden;
                ChangeGif(HittedGif,"Player_1_Dead",1);
            } else {
            HittedGif.Visibility = Visibility.Hidden;
            }
        }

        private void HittedGif2_AnimationCompleted(object sender, RoutedEventArgs e) {
            if (ClassPage_1.PlaneBang_2 == true) {
                PlaneTwo.Visibility = Visibility.Hidden;
                ChangeGif(HittedGif2, "Player_2_Dead", 1);
            } else {
            HittedGif2.Visibility = Visibility.Hidden;
            }
        }


        private void HealthGif_AnimationCompleted(object sender, RoutedEventArgs e) {

            HealthGif.Visibility = Visibility.Hidden;

        }

        private void HealthGif2_AnimationCompleted(object sender, RoutedEventArgs e) {

            HealthGif2.Visibility = Visibility.Hidden;

        }

        private void LockScreenB1_Click(object sender, RoutedEventArgs e) {

            StopAllTimers();
            LockScreen.Visibility = Visibility.Hidden;
            ClassPage_1.PlayOrBreak = false;
            StartTimer.Start();
            if (ClassPage_1.TwoPorOneP == false) {
                ArtificialIntelligenceMove.Start();
            }
            if (ClassPage_1.FirstPlayerNukeMoveBool==true) {
                th1.Abort();
                MoveNuke_1 = true;
                th1 = new Thread(PlayerNuke1_Move);
                th1.Start();
            }
            if (ClassPage_1.SecondPlayerNukeMoveBool==true) {
                th2.Abort();
                MoveNuke_2 = true;
                th2 = new Thread(PlayerNuke2_Move);
                th2.Start();
            }
            if (ClassPage_1.FirstPlayerEnergyNukeMoveBool==true) {
                th3.Abort();
                MoveEnergyNuke_1 = true;
                th3 = new Thread(PlayerEnergyNuke1_Move);
                th3.Start();
            }
            if (ClassPage_1.SecondPlayerEnergyNukeMoveBool == true) {
                th4.Abort();
                MoveEnergyNuke_2 = true;
                th4 = new Thread(PlayerEnergyNuke2_Move);
                th4.Start();
            }

        }

        private void LockScreenB2_Click(object sender, RoutedEventArgs e) {

            MessageBoxResult Message = MessageBox.Show("Oyunu yeniden başlatmak istediğinizi onaylıyormusunuz?","Yeniden Başlatma",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (MessageBoxResult.Yes==Message) {
                LockScreen.Visibility = Visibility.Hidden;
                RestartValues();
            } else {
                ;
            }

        }


        private void LockScreenB3_Click(object sender, RoutedEventArgs e) {

            WindowClosed = true;
            StopAllTimers();
            ClassShowPage.MainWindow();
            Close();

        }

        Thread th1;
        Thread th2;
        Thread th3;
        Thread th4;
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e) {
            // Kontrol Tuşları
          if (ClassPage_1.PlayOrBreak==false) {
             if (e.Key == Key.Escape) {
                StopAllTimers();
                LockScreen.Visibility = Visibility.Visible;
                ClassPage_1.PlayOrBreak = true;
             }
             // Player 1
            if (e.Key == Key.W) {

                if (Player_1.Y > 0) {
                Player_1.Y --;
                Canvas.SetTop(FirstPlayer,Player_1.CanvasY);
                } else {
                        ;
                }

            } else if (e.Key == Key.S) {

                    if (Player_1.Y < 11) {
                        Player_1.Y ++;
                        Canvas.SetTop(FirstPlayer, Player_1.CanvasY);
                    } else {
                        ;
                    }

            } else if (e.Key == Key.Space) {
                if (ClassPage_1.FirstPlayerReturnNuke==false) {
                    ClassPage_1.FirstPlayerNukeMoveBool = true;
                    ClassPage_1.FirstPlayerReturnNuke = true;
                    FPNuke1.Visibility = Visibility.Visible;
                    Player1Nuke_ReturnCoord();
                        MoveNuke_1 = true;
                        th1 = new Thread(PlayerNuke1_Move);
                        th1.Start();
                }
                } else if (e.Key == Key.R) {

                    if ((EnergyBarOne.Value >= (EnergyBarOne.Maximum / 2)) && (EnergyBarOne.Value != EnergyBarOne.Maximum)) {

                        EnergyBarOne.Value -= EnergyBarOne.Maximum / 2;
                        ClassPage_3.PlayNukeBangSound("Sounds/Health/GiveHealth.wav");
                        EventPowerClass.HealthGiveControl(HealthBarOne, EventPowerClass.FPHealth);
                        ClassPage_1.FirstPlayerHealth = Convert.ToInt16(HealthBarOne.Value);
                        HealthGif.Visibility = Visibility.Visible;
                        ImageBehavior.SetRepeatBehavior(HealthGif, new RepeatBehavior(2));
                        ImageBehavior.SetRepeatBehavior(HealthGif, new RepeatBehavior(1));

                    } else if (EnergyBarOne.Value == EnergyBarOne.Maximum) {
                        ClassPage_1.FirstPlayerEnergyNukeMoveBool = true;
                        EnergyBarOne.Value -= EnergyBarOne.Value;
                        Player1EnergyNuke_ReturnCoord();
                        FullEnergyNuke_Player1.Visibility = Visibility.Visible;
                        ClassPage_3.PlayNukeBangSound("Sounds/NukeBangSounds/EnergyNuke.wav");
                        MoveEnergyNuke_1 = true;
                        th3 = new Thread(PlayerEnergyNuke1_Move);
                        th3.Start();

                    } else {
                        ;
                    }

                }
            // Player 2
             if (ClassPage_1.TwoPorOneP == true) {
                 if (e.Key == Key.Up) {
                        if (Player_2.Y > 0) {
                            Player_2.Y -= 1;
                            Canvas.SetTop(SecondPlayer, Player_2.CanvasY);
                        } else {
                            ;
                        }
                } else if (e.Key == Key.Down) {
                        if (Player_2.Y < 11) {
                            Player_2.Y += 1;
                            Canvas.SetTop(SecondPlayer, Player_2.CanvasY);
                        } else {
                            ;
                        }
                } else if (e.Key == Key.P) {
                    if (ClassPage_1.SecondPlayerReturnNuke == false) {
                            ClassPage_1.SecondPlayerNukeMoveBool = true;
                            ClassPage_1.SecondPlayerReturnNuke = true;
                        FPNuke2.Visibility = Visibility.Visible;
                        Player2Nuke_ReturnCoord();
                            MoveNuke_2 = true;
                            th2 = new Thread(PlayerNuke2_Move);
                            th2.Start();

                        }      
                } else if (e.Key == Key.O) {
                        if ((EnergyBarTwo.Value >= (EnergyBarTwo.Maximum / 2)) && (EnergyBarTwo.Value != EnergyBarTwo.Maximum)) {

                            EnergyBarTwo.Value -= EnergyBarTwo.Maximum / 2;
                            ClassPage_3.PlayNukeBangSound("Sounds/Health/GiveHealth.wav");
                            EventPowerClass.HealthGiveControl(HealthBarTwo, EventPowerClass.SPHealth);
                            ClassPage_1.SecondPlayerHealth = Convert.ToInt16(HealthBarTwo.Value);
                            HealthGif2.Visibility = Visibility.Visible;
                            ImageBehavior.SetRepeatBehavior(HealthGif2, new RepeatBehavior(2));
                            ImageBehavior.SetRepeatBehavior(HealthGif2, new RepeatBehavior(1));

                        } else if (EnergyBarTwo.Value == EnergyBarTwo.Maximum) {
                            ClassPage_1.SecondPlayerEnergyNukeMoveBool = true;
                                EnergyBarTwo.Value -= EnergyBarTwo.Value;
                                Player2EnergyNuke_ReturnCoord();
                                FullEnergyNuke_Player2.Visibility = Visibility.Visible;
                                ClassPage_3.PlayNukeBangSound("Sounds/NukeBangSounds/EnergyNuke.wav");
                            MoveEnergyNuke_2 = true;
                            th4 = new Thread(PlayerEnergyNuke2_Move);
                            th4.Start();
                        } else {
                            ;
                        }
                    }
                }

          }

        }

        public void ReturnHealthAndEnergyBar(short FirstPHealth, byte FirstPEnergy, short SecondPHealth, byte SecondPEnergy) {

            HealthBarOne.Maximum = FirstPHealth;
            EnergyBarOne.Maximum = FirstPEnergy;
            HealthBarTwo.Maximum = SecondPHealth;
            EnergyBarTwo.Maximum = SecondPEnergy;

            HealthBarOne.Value = HealthBarOne.Maximum;
            EnergyBarOne.Value = 0;
            HealthBarTwo.Value = HealthBarTwo.Maximum;
            EnergyBarTwo.Value = 0;

        }

        private Coord Player_1 = new Coord(0, 0);
        private Coord Player_2 = new Coord(0, 0);
        public void ReturnCoord() {

            Player_1 = new Coord(2,6);
            Player_2 = new Coord(39,6); // füzzeler için yeni bir cordinat sistemi oluştur.
            Canvas.SetLeft(FirstPlayer, Player_1.CanvasX);
            Canvas.SetTop(FirstPlayer, Player_1.CanvasY);
            Canvas.SetLeft(SecondPlayer, Player_2.CanvasX);
            Canvas.SetTop(SecondPlayer, Player_2.CanvasY);

        }

        private Coord Player1Nuke = new Coord(0, 0);
        public void Player1Nuke_ReturnCoord() {

          byte Player1NukeX = Convert.ToByte(Player_1.X + 3);
            Player1Nuke = new Coord(Player1NukeX,Player_1.Y);
            Canvas.SetLeft(FPNuke1, Player1Nuke.CanvasX);
            Canvas.SetTop(FPNuke1, Player1Nuke.CanvasY);

        }

        private Coord Player1EnergyNuke = new Coord(0, 0);
        public void Player1EnergyNuke_ReturnCoord() {

            byte Player1NukeX = Convert.ToByte(Player_1.X + 3);
            Player1EnergyNuke = new Coord(Player1NukeX, Player_1.Y);
            Canvas.SetLeft(FullEnergyNuke_Player1, Player1EnergyNuke.CanvasX);
            Canvas.SetTop(FullEnergyNuke_Player1, Player1EnergyNuke.CanvasY);

        }

        private Coord Player2Nuke = new Coord(0, 0);
        public void Player2Nuke_ReturnCoord() {

            byte Player2NukeX = Convert.ToByte(Player_2.X - 1);
            Player2Nuke = new Coord(Player2NukeX, Player_2.Y);
            Canvas.SetLeft(FPNuke2, Player2Nuke.CanvasX);
            Canvas.SetTop(FPNuke2, Player2Nuke.CanvasY);

        }

        private Coord Player2EnergyNuke = new Coord(0, 0);
        public void Player2EnergyNuke_ReturnCoord() {

            byte Player2NukeX = Convert.ToByte(Player_2.X - 1);
            Player2EnergyNuke = new Coord(Player2NukeX, Player_2.Y);
            Canvas.SetLeft(FullEnergyNuke_Player2, Player2EnergyNuke.CanvasX);
            Canvas.SetTop(FullEnergyNuke_Player2, Player2EnergyNuke.CanvasY);

        }

        public void TimerTick() {

            StartTimer.Tick += new EventHandler(StartTimer_Tick);
            ArtificialIntelligenceMove.Tick += new EventHandler(ArtificialIntelligenceMove_Tick);

        }

       public void StopAllTimers() {
            StartTimer.Stop();
            MoveNuke_1 = false;
            MoveNuke_2 = false;
            MoveEnergyNuke_1 = false;
            MoveEnergyNuke_2 = false;
            if (ClassPage_1.TwoPorOneP==false) {
                ArtificialIntelligenceMove.Stop();
            }
       }

        public void RestartValues() {

            if (MoveNuke_1) {
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
            }
            StopAllTimers();
            HittedGif.Visibility = Visibility.Hidden;
            HittedGif2.Visibility = Visibility.Hidden;
            ImageBehavior.SetAnimatedSource(HittedGif, (ImageSource)FindResource("NukeBang"));
            ImageBehavior.SetAnimatedSource(HittedGif2, (ImageSource)FindResource("NukeBang"));
            PlaneOne.Visibility = Visibility.Visible;
            PlaneTwo.Visibility = Visibility.Visible;
            ClassPage_2.SelectedHassleAndChangesValue(ClassPage_1.HassleValue);
            ReturnHealthAndEnergyBar(ClassPage_1.FirstPlayerHealth, ClassPage_1.FirstPlayerEnergy, ClassPage_1.SecondPlayerHealth, ClassPage_1.SecondPlayerEnergy);
            ArtificialIntelligenceMove.Interval = new TimeSpan(0, 0, 0, 0 , ClassPage_2.MoveSpeed);
            ReturnCoord();
            Player1Nuke_ReturnCoord();
            Player1EnergyNuke_ReturnCoord();
            Player2EnergyNuke_ReturnCoord();
            Player2Nuke_ReturnCoord();
            FPNuke1.Visibility = Visibility.Hidden;
            FPNuke2.Visibility = Visibility.Hidden;
            FullEnergyNuke_Player1.Visibility = Visibility.Hidden;
            FullEnergyNuke_Player2.Visibility = Visibility.Hidden;
            LockScreenB1.Visibility = Visibility.Visible;
            LockScreen.Visibility = Visibility.Hidden;
            ClassPage_1.PlayOrBreak=true;
            ClassPage_1.FirstPlayerReturnNuke = false;
            ClassPage_1.SecondPlayerReturnNuke = false;
            ClassPage_1.PlaneBang_1 = false;
            ClassPage_1.PlaneBang_2 = false;
            StartTime.Visibility = Visibility.Visible;
            StartTime.Foreground = Brushes.Green;
            StartTime.Text = ClassPage_1.StartTimeValue.ToString();
            LockScreenTB1.Text = "Oyun Durduruldu";
            StartTimer.Interval = new TimeSpan(0, 0, 0, 1);
            StartTimer.Start();
            if (ClassPage_1.TwoPorOneP==false) {
                EnergyBarTwo.Visibility = Visibility.Hidden;
                ArtificialIntelligenceMove.Start();
            }

        }

        public void ChangeGif(Image img, string src, double returnvalue) {

            ImageBehavior.SetAnimatedSource(img, (ImageSource)FindResource(src));
            ImageBehavior.SetAutoStart(img, true);
            ImageBehavior.SetRepeatBehavior(img, new RepeatBehavior(2));
            ImageBehavior.SetRepeatBehavior(img, new RepeatBehavior(returnvalue));

        }

    }
}
// Özçelik Software ~ Mert ÖZÇELİK ~