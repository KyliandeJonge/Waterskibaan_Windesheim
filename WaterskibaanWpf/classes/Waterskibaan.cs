using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterskibaanWpf.classes;

namespace WaterskibaanWpf.classes
{
    public class WaterskibaanObj
    {
        public LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
        public Kabel kabel = new Kabel();

        public WaterskibaanObj()
        {
            this.initLijnenVoorraad();
        }

        public void SporterStart(Sporter sporter)
        {
            if (sporter.Zwemvest == null || sporter.Skies == null)
                throw new Exception("Sporter mist een zwemvest of skies");

            if (kabel.IsStartPositieLeeg())
            {
                Lijn lijnVanSporter = lijnenVoorraad.VerwijderEersteLijn();
                lijnVanSporter.Sporter = sporter;
                kabel.NeemLijnInGebruik(lijnVanSporter);
            }
        }

        private void initLijnenVoorraad()
        {
            for (int i = 0; i < 15; i++)
            {
                lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void VerplaatsKabel(LijnenVerplaatstArgs args)
        {
            for (LinkedListNode<Lijn> current = kabel.GeefLijnenOpKabel()?.First; current != null; current = current.Next)
            {
                if (current.Value.Sporter.Moves.Count > 0 && Random.Next(0, 4) == 4)
                {
                    int moveCountId = (current.Value.Sporter.Moves.Count == 1) ? 0 : Random.Next(0, (current.Value.Sporter.Moves.Count - 1));
                    current.Value.Sporter.huidigeMove = current.Value.Sporter.Moves[moveCountId];
                }
                else
                {
                    current.Value.Sporter.huidigeMove = null;
                }
            }

            this.kabel.VerschuifLijnen();
            Lijn ontkoppeldeLijn = this.kabel.VerwijderLijnVanKabel();

            Console.WriteLine(ontkoppeldeLijn);
            if (ontkoppeldeLijn != null)
            {
                lijnenVoorraad.LijnToevoegenAanRij(ontkoppeldeLijn);
            }
        }


        public override string ToString()
        {
            string value = "";

            value += $"{this.kabel.ToString()} \n";
            value += $"{this.lijnenVoorraad.ToString()} \n";

            return value;
        }
    }
}
