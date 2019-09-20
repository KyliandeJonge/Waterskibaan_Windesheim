using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waterskibaan.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes.Tests
{
    [TestClass()]
    public class KabelTests
    {
        [TestMethod()]
        public void IsStartPositieLeegTest()
        {
            Kabel kabel = new Kabel();
            Lijn lijn = new Lijn();

            if (kabel.IsStartPositieLeeg())
            {
                kabel.NeemLijnInGebruik(lijn);
                Assert.IsFalse(kabel.IsStartPositieLeeg());
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void VerschuifLijnenTest_GaatVan0Naar2()
        {
            Kabel kabel = new Kabel();

            Lijn lijn0 = new Lijn();
            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();

            kabel.NeemLijnInGebruik(lijn0);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn1);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn2);

            Assert.IsTrue(lijn0.PositieOpKabel == 2);
        }

        [TestMethod()]
        public void VerschuifLijnenTest_GaatVan9Naar0()
        {
            Kabel kabel = new Kabel();

            Lijn lijn0 = new Lijn();

            kabel.NeemLijnInGebruik(lijn0);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();


            Assert.IsTrue(lijn0.PositieOpKabel == 0);
        }

        [TestMethod()]
        public void VerwijderLijnVanKabelTest_WanneerLijnPositie9Is()
        {
            Kabel kabel = new Kabel();

            Lijn lijn0 = new Lijn();

            kabel.NeemLijnInGebruik(lijn0);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());

            kabel.VerwijderLijnVanKabel();
            Assert.IsFalse(kabel.GeefLijnenOpKabel().Contains(lijn0));
        }

        [TestMethod()]
        public void VerwijderLijnVanKabelTest_WanneerLijnPositieNiet9Is()
        {
            Kabel kabel = new Kabel();

            Lijn lijn0 = new Lijn();

            kabel.NeemLijnInGebruik(lijn0);
            kabel.VerwijderLijnVanKabel();

            Assert.IsTrue(kabel.GeefLijnenOpKabel().Contains(lijn0));
        }
    }
}