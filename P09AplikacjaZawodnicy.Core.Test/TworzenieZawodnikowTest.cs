using Microsoft.VisualStudio.TestTools.UnitTesting;
using P07AplikacjaZawodnicy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09AplikacjaZawodnicy.Core.Test
{
    [TestClass]
    internal class TworzenieZawodnikowTest
    {
        [TestMethod]
        public void StworzZawodnika_Scenariusz1()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zaw=  zr.WczytajZawodnikow();

            Assert.IsTrue(zaw.Length == 17);
            Assert.IsTrue(zaw[0].Imie == "MarcinX4");
        }

        [TestMethod]
        public void StworzZawodnika_Scenariusz2()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var z = new Zawodnik()
            {
                Imie = "ala",
                Nazwisko = "kowalska",
                Kraj = "pol"
            };
            zr.DodajZawodnika(z);
        }

        [TestMethod]
        public void StworzZawodnika_Scenariusz3()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var z = new Zawodnik();
            zr.DodajZawodnika(z);
        }

    }
}
