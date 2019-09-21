using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes
{
    class Sporter
    {
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public int AantalRondenTeGaan { get; set; }

        public int AantalBehaaldePunten { get; set; } = 0;
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {
            this.Moves = moves;
            this.getBehaaldePunten();
            
        }

        private void getBehaaldePunten()
        {
            foreach (IMoves move in this.Moves)
            {
                AantalBehaaldePunten += move.Move();
            }
        }
    }
}
