using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterskibaanWpf.interfaces;

namespace WaterskibaanWpf.classes
{
    public class WachtrijStarten : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 20;

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (var sporter in args.sporters)
            {
                wachtrij.Enqueue(sporter);
            }
        }
    }
}
