﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes
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
            for(int i = 0; i < 15; i++)
            {
                lijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void VerplaatsKabel()
        {
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
