using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes
{
    class WaterskibaanObj
    {
        public LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
        public Kabel kabel = new Kabel();

        public WaterskibaanObj()
        {
            this.initLijnenVoorraad();
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
