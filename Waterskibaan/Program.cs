using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            WaterskibaanObj waterskibaan = new WaterskibaanObj();

            waterskibaan.kabel.NeemLijnInGebruik(new Lijn());
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            waterskibaan.VerplaatsKabel();
            


            Console.WriteLine(waterskibaan);
            

           
        }
    }
}
