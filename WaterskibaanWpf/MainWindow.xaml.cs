using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WaterskibaanWpf.classes;
using Random = WaterskibaanWpf.classes.Random;

namespace WaterskibaanWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        private static System.Timers.Timer aTimer;

        // Nieuwe bezoeker
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        // Instructie afgelopen
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        // Lijnen verplaatsen
        public delegate void LijnenVerplaatstHandler(LijnenVerplaatstArgs args);
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        WaterskibaanObj waterskibaan = new WaterskibaanObj();

        // Wachtrijen
        WachtrijInstructie wachtrijInstructie = new WachtrijInstructie();
        InstructieGroep instructieGroep = new InstructieGroep();
        WachtrijStarten wachtrijStarten = new WachtrijStarten();

        public int loopCount;
        public MainWindow()
        {
            InitializeComponent();
            SetGameEvents();
            mainWindow = this;
        }

        public void SetGameEvents()
        {
            this.NieuweBezoeker += wachtrijInstructie.OnNieuweBezoeker;

            this.InstructieAfgelopen += wachtrijInstructie.OnInstructieAfgelopen;
            this.InstructieAfgelopen += instructieGroep.OnInstructieAfgelopen;
            this.InstructieAfgelopen += wachtrijStarten.OnInstructieAfgelopen;

            this.LijnenVerplaatst += waterskibaan.VerplaatsKabel;
            this.LijnenVerplaatst += this.StartSporter;
        }

        public void updateGameLoop(Object source, ElapsedEventArgs e)
        {
            if (loopCount % 3 == 0 && loopCount != 0)
            {
                this.NieuweBezoeker(new NieuweBezoekerArgs() { sporter = new Sporter() });
            }

            if (loopCount % 4 == 0 && loopCount != 0)
            {
                this.LijnenVerplaatst(new LijnenVerplaatstArgs());
            }
            if (loopCount % 5 == 0 && loopCount != 0)
            {
                StartSporter(new LijnenVerplaatstArgs());
            }

            if (loopCount % 20 == 0 && loopCount != 0)
            {
                this.InstructieAfgelopen(new InstructieAfgelopenArgs());
            }

            this.loopCount++;
        }

        public void updateValuesOnScreen(Object source, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { lblLijnenVoorraad.Content = waterskibaan.lijnenVoorraad.GetAantalLijnen(); });
        }

        public void StartSporter(LijnenVerplaatstArgs args)
        {
            if (waterskibaan.kabel.IsStartPositieLeeg() && !wachtrijStarten.IsWachtrijLeeg())
            {
                Console.WriteLine("\t Sporter added");
                Sporter sporter = wachtrijStarten.wachtrij.Dequeue();
             
                sporter.Skies = new Skies();
                sporter.Zwemvest = new Zwemvest();

                waterskibaan.SporterStart(sporter);

            }
            else
            {
                Console.WriteLine("\t Sported not added");
            }
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += updateGameLoop;
            aTimer.Elapsed += updateValuesOnScreen;
            aTimer.Elapsed += updateWaterskibaanCanvas;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void updateWaterskibaanCanvas(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { paintWaterskibaanCanvas(); });
        }

        public void paintWaterskibaanCanvas()
        {
            int padding = 12;

            canvasWaterskibaan.Children.Clear();
            
            foreach(Lijn lijn in waterskibaan.kabel.GeefLijnenOpKabel()) {

                Rectangle r = new Rectangle()
                {
                    Width = 80,
                    Height = 50,
                    Fill = lijn.Sporter.KledingKleur
                };
 
                Canvas.SetTop(r, 12.5);
                Canvas.SetLeft(r, padding);

                TextBlock textBlock = new TextBlock();
                textBlock.Text = lijn.PositieOpKabel.ToString();
                textBlock.FontSize = 25;
               
                textBlock.Margin = new Thickness((padding + 40), 100, 0, 0);

                padding = padding + 87;

                canvasWaterskibaan.Children.Add(r);
                canvasWaterskibaan.Children.Add(textBlock);
            }
        }

        public void paintWachtrij()
        {

        }
        private void BtnStartSkibaan_Click(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            aTimer.Stop();
        }
    }
}
