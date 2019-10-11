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
            Console.WriteLine(args.instructiegroep.Count);
            Console.WriteLine(args.InstructieAantal);
            Console.WriteLine(args.tempList.Count);
            Console.WriteLine("-----------");
            
                for (int i = 0; i < 5; i++)
                {
                    
                        if (args.InstructieAantal == 5) {
                        Console.WriteLine("ASDADASDASDSA");
                            wachtrij.Enqueue(args.tempList.Dequeue());
                        }
                    
                }
            
        }
    }
}
