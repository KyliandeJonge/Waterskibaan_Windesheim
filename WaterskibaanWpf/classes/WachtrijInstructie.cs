using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterskibaanWpf.interfaces;

namespace WaterskibaanWpf.classes
{
    public class WachtrijInstructie : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 100;
        public int instructieGrootte;

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            if (wachtrij.Count < this.MAX_LENGTE_RIJ) {
                wachtrij.Enqueue(args.sporter);
            }
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            int addAmount = 5 - args.InstructieAantal;

            for (int i = 0; i < addAmount; i++) {
                
                args.instructiegroep.Add(wachtrij.Dequeue());
            }
        }
    }
}
