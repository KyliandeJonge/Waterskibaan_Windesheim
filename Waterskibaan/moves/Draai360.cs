using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.moves
{
    class Draai360 : IMoves
    {
        int Score { get; set; } = 30;

        public bool Geland()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 60;
        }

        public int Move()
        {
            return this.Geland() ? Score : 0;
        }

        public string Naam()
        {
            return "Draai 360";
        }
    }
}
