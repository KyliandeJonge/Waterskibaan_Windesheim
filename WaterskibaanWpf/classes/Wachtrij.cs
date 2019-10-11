using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterskibaanWpf.interfaces;

namespace WaterskibaanWpf.classes
{
    abstract public class Wachtrij
    {
        public Queue<Sporter> wachtrij = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            List<Sporter> alleSporters = new List<Sporter>();

            foreach (Sporter s in wachtrij)
            {
                alleSporters.Add(s);
            }

            return alleSporters;
        }

        public void SporterNeemtPlaatsInRij(Sporter sporter)
        {
            wachtrij.Enqueue(sporter);
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> alleSporters = new List<Sporter>();

            for (int i = 0; i < aantal; i++)
            {
                alleSporters.Add(wachtrij.Dequeue());
            }

            return alleSporters;
        }

        public bool IsWachtrijLeeg()
        {
            return (wachtrij.Count == 0) ? true : false;
        }

        public override string ToString()
        {
            string value = "";

            foreach (var sporter in wachtrij)
            {
                value += $"{sporter.ToString()} \n\n";
            }

            return value;
        }
    }
}
