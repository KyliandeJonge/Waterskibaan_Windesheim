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
        }

        public void SetGameEvents()
        {
            this.NieuweBezoeker += wachtrijInstructie.OnNieuweBezoeker;

            this.InstructieAfgelopen += wachtrijInstructie.OnInstructieAfgelopen;
            this.InstructieAfgelopen += wachtrijStarten.OnInstructieAfgelopen;
            this.InstructieAfgelopen += instructieGroep.OnInstructieAfgelopen;
           

            this.LijnenVerplaatst += waterskibaan.VerplaatsKabel;
            this.LijnenVerplaatst += this.StartSporter;
        }

        public void updateGameLoop(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"wachtrij instructie: {wachtrijInstructie.wachtrij.Count}");
            Console.WriteLine($"instructie: {instructieGroep.wachtrij.Count}");
            Console.WriteLine($"wachtrij starten: {wachtrijStarten.wachtrij.Count}");
            if(loopCheck(loopCount, 1))
            {
                this.NieuweBezoeker(new NieuweBezoekerArgs() { sporter = new Sporter() });
            }

            if (loopCheck(loopCount, 2))
            {
                this.LijnenVerplaatst(new LijnenVerplaatstArgs());
            }
            if (loopCheck(loopCount, 3))
            {
                StartSporter(new LijnenVerplaatstArgs());
            }

            if (loopCheck(loopCount, 5))
            {
                this.InstructieAfgelopen(new InstructieAfgelopenArgs()
                {
                    InstructieAantal = this.instructieGroep.wachtrij.Count,
                    tempList = this.instructieGroep.wachtrij
                });
            }

            if (loopCheck(loopCount, 10))
            {
                
            }

            this.loopCount++;
        }

        public static bool loopCheck(int x, int y)
        {
            return ( (x % y == 0) && (x != 0) );
        }

        public void updateValuesOnScreen(Object source, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { lblLijnenVoorraad.Content = waterskibaan.lijnenVoorraad.GetAantalLijnen(); });
        }

        public void StartSporter(LijnenVerplaatstArgs args)
        {
            if (waterskibaan.kabel.IsStartPositieLeeg() && !wachtrijStarten.IsWachtrijLeeg())
            {
                Sporter sporter = wachtrijStarten.wachtrij.Dequeue();
             
                sporter.Skies = new Skies();
                sporter.Zwemvest = new Zwemvest();

                waterskibaan.SporterStart(sporter);
            }
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += updateGameLoop;
            aTimer.Elapsed += updateValuesOnScreen;
            aTimer.Elapsed += updateWaterskibaanCanvas;
            aTimer.Elapsed += updateCanvasWachtrijen;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void updateWaterskibaanCanvas(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { PaintMethods.paintWaterskibaanCanvas(canvasWaterskibaan, waterskibaan); });
        }

        private void updateCanvasWachtrijen(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate {
                PaintMethods.paintWachtrij(canvasWachtrijInstructie, wachtrijInstructie.GetAlleSporters());
                PaintMethods.paintWachtrij(canvasInstructie, instructieGroep.GetAlleSporters());
                PaintMethods.paintWachtrij(canvasWachtrijStarten, wachtrijStarten.GetAlleSporters());
            });
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
