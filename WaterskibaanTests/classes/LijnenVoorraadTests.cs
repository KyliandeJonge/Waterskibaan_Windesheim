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
    public class LijnenVoorraadTests : LijnenVoorraad
    {
        Queue<Lijn> _lijnen = new Queue<Lijn>();
        [TestMethod()]
        public void LijnToevoegenAanRijTest()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Lijn lijn1 = new Lijn();

            lijnenVoorraad.LijnToevoegenAanRij(lijn1);

            Queue<Lijn> lijnen = lijnenVoorraad.GetQueueLijnen();

            Assert.IsTrue(lijnen.Contains(lijn1));
        }

        [TestMethod()]
        public void VerwijderEersteLijnTest_WhenQueueEmpty()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();

            Assert.IsNull(lijnenVoorraad.VerwijderEersteLijn());
        }

        [TestMethod()]
        public void VerwijderEersteLijnTest_WhenQueueNotEmpty()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();

            lijnenVoorraad.LijnToevoegenAanRij(new Lijn());

            Assert.IsInstanceOfType(lijnenVoorraad.VerwijderEersteLijn(), typeof(Lijn));
        }

        [TestMethod()]
        public void GetAantalLijnenTest()
        {
            LijnenVoorraad lijnenVoorraad = new LijnenVoorraad();
            Lijn lijn1 = new Lijn();

            lijnenVoorraad.LijnToevoegenAanRij(lijn1);

            Queue<Lijn> lijnen = lijnenVoorraad.GetQueueLijnen();

            Assert.IsTrue(lijnen.Count == lijnenVoorraad.GetAantalLijnen());
        }
    }
}