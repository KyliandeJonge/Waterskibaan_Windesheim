using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WaterskibaanWpf.classes
{
    class PaintMethods
    {
        public static void paintWaterskibaanCanvas(Canvas canvasWaterskibaan, WaterskibaanObj waterskibaan)
        {
            int padding = 12;

            canvasWaterskibaan.Children.Clear();

            foreach (Lijn lijn in waterskibaan.kabel.GeefLijnenOpKabel())
            {

                Rectangle r = new Rectangle()
                {
                    Width = 80,
                    Height = 50,
                    Fill = lijn.Sporter.KledingKleur
                };

                Canvas.SetTop(r, 12.5);
                Canvas.SetLeft(r, padding);

                TextBlock positie = new TextBlock
                {
                    Text = lijn.PositieOpKabel.ToString(),
                    FontSize = 20,
                    Margin = new Thickness((padding + 40), 100, 0, 0)
                };

                if (lijn.Sporter.huidigeMove != null)
                {
                    TextBlock move = new TextBlock
                    {
                        Text = $"{lijn.Sporter.huidigeMove.Naam()}",
                        FontSize = 10,
                        Margin = new Thickness((padding + 30), 120, 0, 0)
                    };

                    canvasWaterskibaan.Children.Add(move);
                }

                padding = padding + 87;

                canvasWaterskibaan.Children.Add(r);
                canvasWaterskibaan.Children.Add(positie);
            }
        }

        public static void paintWachtrij(Canvas canvas, List<Sporter> sporters)
        {
            int padding = 12;

            canvas.Children.Clear();

            for (int i = 0; i < sporters.Count; i++)
            {
                if (i > 8) { break; }

                Rectangle r = new Rectangle()
                {
                    Width = 80,
                    Height = 50,
                    Fill = sporters[i].KledingKleur
                };

                Canvas.SetTop(r, 40);
                Canvas.SetLeft(r, padding);

                padding += 90;

                canvas.Children.Add(r);
            }

            if (sporters.Count > 9)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = $" + {(sporters.Count - 9)} meer";
                textBlock.FontSize = 18;

                textBlock.Margin = new Thickness(800, 0, 0, 0);
                canvas.Children.Add(textBlock);
            }
        }
    }
}
