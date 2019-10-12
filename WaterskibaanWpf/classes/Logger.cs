using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace WaterskibaanWpf.classes
{
    class Logger
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
        }

        public void updateTotaalBezoekerCount(MainWindow window)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { window.lblTotaalAantalBezoekers.Content = (from n in alleSporters select n).Count(); });
        }

        public void updateHoogsteScore(MainWindow window)
        {
            int hoogsteScore = alleSporters.Max(x => x.AantalBehaaldePunten);
            App.Current.Dispatcher.Invoke((Action)delegate { window.lblHoogsteScore.Content = hoogsteScore });
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

    }
}