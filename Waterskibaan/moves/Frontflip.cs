﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.moves
{
    class Frontflip : IMoves
    {
        int Score { get; set; } = 50;

        public bool Geland()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 30;
        }

        public int Move()
        {
            return this.Geland() ? Score : 0;
        }

        public string Naam()
        {
            return "Frontflip";
        }
    }
}
