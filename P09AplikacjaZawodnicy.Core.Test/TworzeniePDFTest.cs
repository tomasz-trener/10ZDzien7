using Microsoft.VisualStudio.TestTools.UnitTesting;
using P07AplikacjaZawodnicy.Core.Tools;
using System;
using System.IO;

namespace P09AplikacjaZawodnicy.Core.Test
{
    [TestClass]
    public class TworzeniePDFTest
    {
        [TestMethod]
        public void StworzPDF_Scenariusz1()
        {
            PDFManager pDFManager = new PDFManager();
            pDFManager.StworzPDF();

            bool czyIstnieje = File.Exists("HelloWorld.pdf");

            Assert.IsTrue(czyIstnieje);

        }
    }
}
