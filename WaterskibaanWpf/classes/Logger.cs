using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace WaterskibaanWpf.classes
{
    public class Logger
    {
        public List<Sporter> alleSporters = new List<Sporter>();
        public List<int> alleScores = new List<int>();
        public List<Brush> alleKleuren = new List<Brush>();

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            alleSporters.Add(args.sporter);
            updateTotaalBezoekerCount(args.window);
            updateHoogsteScore(args.window);
            updateTotaalAantalRondjes(args);
            updateRodeKleding(args.window);
            updateUniekeMovesOpBaan(args);
            TienSportersGeordendOpLichtheid(args);
        }

        public void updateTotaalBezoekerCount(MainWindow window)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { window.lblTotaalAantalBezoekers.Content = (from n in alleSporters select n).Count(); });
        }

        public void updateHoogsteScore(MainWindow window)
        {
            int hoogsteScore = alleSporters.Max(x => x.AantalBehaaldePunten);
            App.Current.Dispatcher.Invoke((Action)delegate { window.lblHoogsteScore.Content = hoogsteScore; });
        }

        public void updateTotaalAantalRondjes(NieuweBezoekerArgs args)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { args.window.lblTotaalAantalRondjes.Content = args.kabel.totaalAantalRondjes; });
        }

        public void updateRodeKleding(MainWindow window)
        {
            int rodeKledingCount = (from n in alleSporters
                                    where n.KledingKleur == Brushes.Red
                                    select n).Count();

            App.Current.Dispatcher.Invoke((Action)delegate { window.lblAantalRodeKleding.Content = rodeKledingCount; });
        }

        public void TienSportersGeordendOpLichtheid(NieuweBezoekerArgs args)
        {
            if (alleSporters.Count() == 9)
            {
                var tienSporters = from n in alleSporters
                                   orderby n.getCombinedRGB()
                                   select n;

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    PaintMethods.paintWachtrij(args.window.canvasGesorteerdeSpelers, tienSporters.Reverse().ToList());
                });
                
            }
        }

        public void updateUniekeMovesOpBaan(NieuweBezoekerArgs args)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { args.window.listBoxHuidigeMoves.Items.Clear(); });

            List<string> MovesOpKabel = args.kabel.GeefMovesOpKabel();
            var distinctedMoves = MovesOpKabel.GroupBy(x => x).Select(y => y.First());

            MovesOpKabel = distinctedMoves.ToList();

            foreach (string s in MovesOpKabel)
            {
                App.Current.Dispatcher.Invoke((Action)delegate { args.window.listBoxHuidigeMoves.Items.Add(s); });
            }
        }

        private bool ColersAreClose(Brush a, Brush z, int threshold = 50)
        {


            Color myColorFromBrush = ((SolidColorBrush)a).Color; // :-)

            int r = myColorFromBrush.R,
                g = myColorFromBrush.G,
                b = myColorFromBrush.B;

            return (r * r + g * g + b * b) <= threshold * threshold;

        }

    }
}