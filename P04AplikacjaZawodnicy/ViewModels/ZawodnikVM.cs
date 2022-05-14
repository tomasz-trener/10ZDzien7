using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04AplikacjaZawodnicy.ViewModels
{
    internal class ZawodnikVM
    {
        public int Id;
        public int? IdTrenera;
        public string Imie { get; set; } // klasy są nullable to znaczy , ze one juz odrazu moga pzryjmowac wartosci null
        public string Nazwisko;
        public string Kraj;
        public DateTime DataUr; // domysla wartosc Datetime rok 0 mieisc 0 dzien 1 , godz 0 min 0 sek 0 
        public int? Wzrost; // dodanie ? powoduje, ze wzrost moze byc null i jednoczesnie domyslna wartoscia wzrostu jest null
        public int Waga; // w tym monmencie gdy nie ma ? to waga nie moze byc null i domylsna wartosc to 0 

        public bool Plec; // domylsa wartosc to false 

        public string Wiersz
        {
            get
            {
                return Imie + " " + Nazwisko + " " + Kraj;
            }
        }

        public string ImieNazwisko { get { return Imie + " " + Nazwisko; } }
    }
}
