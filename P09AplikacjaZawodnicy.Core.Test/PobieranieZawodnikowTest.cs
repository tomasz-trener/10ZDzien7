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
    internal class PobieranieZawodnikowTest
    {
        [TestMethod]
        public void PobierzZawodnikow_Scenariusz1()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zaw=  zr.WczytajZawodnikow();

            Assert.IsTrue(zaw.Length == 17);
            Assert.IsTrue(zaw[0].Imie == "MarcinX4");
        }

        [TestMethod]
        public void PobierzZawodnikow_Scenariusz2()
        {

        }

        [TestMethod]
        public void PobierzZawodnikow_Scenariusz3()
        {

        }

    }
}
