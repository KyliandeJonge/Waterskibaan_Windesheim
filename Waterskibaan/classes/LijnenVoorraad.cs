using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes
{
    public class LijnenVoorraad
    {
        Queue<Lijn> _lijnen = new Queue<Lijn>();

        public LijnenVoorraad()
        {

        }

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            return (_lijnen.Count > 0) ? _lijnen.Dequeue() : null;
        }

        public int GetAantalLijnen()
        {
            return _lijnen.Count;
        }

        public Queue<Lijn> GetQueueLijnen()
        {
            return _lijnen;
        }

        public override string ToString()
        {
            return $"{_lijnen.Count} lijnen op voorraad";
        }
    }
}
