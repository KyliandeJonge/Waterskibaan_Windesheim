using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes
{
    class WachtrijStarten : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 20;

        public void OnNieuweBezoeker(NieuweBezoekerArgs args) { 
            Console.WriteLine("Wachtrij Starten event fired." + args.sporter);
            wachtrij.Enqueue(args.sporter);
        }
    }
}
