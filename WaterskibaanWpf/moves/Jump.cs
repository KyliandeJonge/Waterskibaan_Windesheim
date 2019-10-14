using System;
using WaterskibaanWpf.interfaces;

namespace WaterskibaanWpf.moves
{
    class Jump : IMoves
    {

        int Score { get; set; } = 10;
        public bool Geland()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 80;
        }

        public int Move()
        {
            return Score;
        }

        public string Naam()
        {
            return "Jump";
        }
    }
}
