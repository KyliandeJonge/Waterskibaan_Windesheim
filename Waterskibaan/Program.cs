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
            Sporter sporter1 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Console.WriteLine(sporter1.AantalBehaaldePunten);
        }
    }
}
