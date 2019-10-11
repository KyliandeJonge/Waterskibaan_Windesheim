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

        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            Console.WriteLine("Wachtrij Starten event fired." + args.sporter);
            wachtrij.Enqueue(args.sporter);
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            Console.WriteLine("instrctie afgelopen in wachtrijintrscutei bestand");
            
            int count = (wachtrij.Count() <= 20) ? wachtrij.Count : 20;
            Console.WriteLine($"{count} aantal in wachtrij");

            for (int i = 0; i < count; i++)
            {
                args.sporters.Add(wachtrij.Dequeue());
            }
        }
    }
}
