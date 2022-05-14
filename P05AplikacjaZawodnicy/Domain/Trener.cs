using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02AplikacjaZawodnicy.Domain
{
    public class Trener
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public DateTime? DataUr { get; set; }

        public string ImieNazwisko {  get { return Imie + " " + Nazwisko; } }

    }
}
