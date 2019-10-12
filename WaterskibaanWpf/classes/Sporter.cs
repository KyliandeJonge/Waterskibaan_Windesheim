using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WaterskibaanWpf.interfaces;

namespace WaterskibaanWpf.classes
{
    public class Sporter
    {
        Brush[] brushes = new Brush[] {
          Brushes.Red,
          Brushes.Navy,
          Brushes.Chartreuse,
          Brushes.DarkMagenta,
          Brushes.DarkSeaGreen,
          Brushes.Orange,
          Brushes.Purple
        };

        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public int AantalRondenTeGaan { get; set; }
        public int AantalBehaaldePunten { get; set; } = 0;
        public Brush KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }

        public IMoves huidigeMove { get; set; }



        public Sporter()
        {
            this.Moves = MoveCollection.GetWillekeurigeMoves();
            this.KledingKleur = brushes[Random.Next(0, 6)];
            
            AantalRondenTeGaan = this.setAantalRondenTeGaan();
        }

        private int setAantalRondenTeGaan()
        {
            return Random.Next(1,2);
        }

        public string getNaamHuidigeMove()
        {
            return (huidigeMove != null) ? huidigeMove.Naam() : "geen move";
        }

        public void getBehaaldePunten()
        {
            if (this.Moves == null)
                return;

            foreach (IMoves move in this.Moves)
            {
                AantalBehaaldePunten += move.Move();
            }
        }

        public override string ToString()
        {
            return $"{AantalRondenTeGaan} rondes te gaan \n" +
                $"Punten behaald: {AantalBehaaldePunten} \n";
        }
    }
}
