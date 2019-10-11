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
        public int MAX_LENGTE_RIJ = 5;

        public void OnWachtrijFired(object source, EventArgs e)
        {
            Console.WriteLine("Wachtrij Instructiegroep event fired.");
        }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            Console.WriteLine("hoeveel in args.sporters in instructiegoepw bestand" + args.sporters.Count);
        }
    }
}
