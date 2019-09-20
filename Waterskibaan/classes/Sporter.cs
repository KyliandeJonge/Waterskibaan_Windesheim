﻿using System;
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
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {
            this.Moves = moves;
        }
    }
}
