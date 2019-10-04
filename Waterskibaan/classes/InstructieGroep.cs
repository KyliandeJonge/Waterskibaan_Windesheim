using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes
{
    class InstructieGroep : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 5;

        public void OnWachtrijFired(object source, EventArgs e)
        {
            Console.WriteLine("Wachtrij Instructiegroep event fired.");
        }
    }
}
