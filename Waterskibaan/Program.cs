using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes;
using Waterskibaan.interfaces;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            /*WaterskibaanObj waterskibaan = new WaterskibaanObj();*/
            Sporter sporter1 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter sporter2 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter sporter3 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter sporter4 = new Sporter(MoveCollection.GetWillekeurigeMoves());

            /*waterskibaan.SporterStart(sporter1);*/

/*            Console.WriteLine($"Waterskibaan: \n {waterskibaan} \n\n Sporter: \n {sporter1}");*/            Console.WriteLine(sporter2);
            Console.WriteLine(sporter1);
            Console.WriteLine(sporter2);
            Console.WriteLine(sporter3);
            Console.WriteLine(sporter4);

            

        }
    }
}
