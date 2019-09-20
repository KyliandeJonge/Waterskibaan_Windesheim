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
            Kabel kabel = new Kabel();

            Lijn lijn0 = new Lijn();
            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();
            Lijn lijn3 = new Lijn();
            Lijn lijn4 = new Lijn();
            Lijn lijn5 = new Lijn();
            Lijn lijn6 = new Lijn();
            Lijn lijn7 = new Lijn();
            Lijn lijn8 = new Lijn();
            Lijn lijn9 = new Lijn();

            kabel.NeemLijnInGebruik(lijn0);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn1);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn2);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn3);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn4);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();

            Console.WriteLine(kabel);
        }
    }
}
