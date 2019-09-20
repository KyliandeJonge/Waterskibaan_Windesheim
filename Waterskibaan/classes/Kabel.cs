using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes
{
    public class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            for (LinkedListNode<Lijn> it = _lijnen.First; it != null; it = it.Next) {
                if (it.Value.PositieOpKabel == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            int counter = 0;

            for (LinkedListNode<Lijn> it = _lijnen.First; counter < _lijnen.Count; it = it.Next)
            {
                if (it.Value.PositieOpKabel == 9)
                {
                    _lijnen.Remove(it);
                    _lijnen.AddFirst(it);
                    it.Value.PositieOpKabel = 0;

                }
                else {
                    it.Value.PositieOpKabel++;
                }

                counter++;
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            for (LinkedListNode<Lijn> it = _lijnen.First; it != null; it = it.Next)
            {
                if (it.Value.PositieOpKabel == 9)
                {
                    _lijnen.Remove(it);
                    return it.Value;
                }
            }

            return null;
        }

        public LinkedList<Lijn> GeefLijnenOpKabel()
        {
            return _lijnen;
        }


        public override string ToString()
        {
            string value = "";

            for (LinkedListNode<Lijn> it = _lijnen.First; it != null; it = it.Next)
            {
                value += it.Value.PositieOpKabel;
                if (it.Next != null)
                {
                    value += "|";
                }
            }

            return value;
        }
    }
}

