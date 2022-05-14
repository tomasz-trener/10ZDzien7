using P07AplikacjaZawodnicy.Core.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08TestowanieBiblioteki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PDFManager pDFManager = new PDFManager();
            pDFManager.StworzPDF();
            Process.Start("HelloWorld.pdf");
        }
    }
}
