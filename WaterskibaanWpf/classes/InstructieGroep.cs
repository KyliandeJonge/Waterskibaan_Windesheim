using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterskibaanWpf.interfaces;

namespace WaterskibaanWpf.classes
{
    public class InstructieGroep : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 25;

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
           
            args.InstructieAantal = this.wachtrij.Count();
            
            foreach (Sporter s in args.instructiegroep)
            {
                wachtrij.Enqueue(s);
            }
        }
    }
}
