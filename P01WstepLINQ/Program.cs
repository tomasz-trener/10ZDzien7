using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01WstepLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] napisy = { "ala", "ma", "kota" };

            List<string> dlugie = new List<string>();
            foreach (var e in napisy)
                if (e.Length > 2)
                    dlugie.Add(e);

            string[] wynik1 = dlugie.ToArray();

            string[] wynik2 = napisy.Where(e => e.Length > 2).ToArray();

            int[] liczby = { 3, 5, 6, 3, 8 };

            int[] wynik3= liczby.Where(x => x > 3).ToArray();

            string sciezka = "http://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";
            ManagerZawodnikow mz = new ManagerZawodnikow(sciezka, TypImportu.Zdalny);

            mz.WygenerujZawodnikow();
             
            Zawodnik[] zawodnicy= mz.PodajZawodnikow(); // loklany zbiór danych

            //    foreach (var z in zawodnicy)
            //        Console.WriteLine(z.ImieNazwisko);

            Zawodnik[] wynik4=  zawodnicy.Where(x => x.Kraj == "POL").ToArray();

            Zawodnik[] wynik5 = zawodnicy.Where(x => x.Kraj == "XXX").ToArray();

            Zawodnik[] wynik6 = zawodnicy.Where(x => x.Kraj == "POL" || x.Kraj == "GER").ToArray();

            Zawodnik[] wynik7= zawodnicy.Select(x => x).ToArray();

            string[] wynik8 = zawodnicy.Select(x => x.Nazwisko).ToArray();

            string[] wynik9 = zawodnicy.Select(x => x.Imie + " " + x.Nazwisko).ToArray();

            string[] wynik10 = zawodnicy.Select(x => x.ImieNazwisko).ToArray();

            ZawodnikMini[] wynik11 =zawodnicy.Select(x => new ZawodnikMini() { Imie = x.Imie, Nazwisko = x.Nazwisko }).ToArray();

            dynamic wynik12= zawodnicy.Select(x => new { MojeImie = x.Imie, MojKraj = x.Kraj }).ToArray();

            foreach (var w1 in wynik12)
                Console.WriteLine(w1.MojeImie + " " + w1.MojKraj);

            // Zadanie:  Wypisz imiona, nazwiska wszystkich zawodnikow , oprócz niemców , wraz z ich BMI ale tylko tych, których bmi jest wieksze od 20

            // BMI to waga[kg]/wzrost[m]^2

            var wynik13 = zawodnicy.Where(x => x.Kraj != "GER" && x.BMI > 20).Select(x => new { x.Imie, x.Nazwisko, x.BMI }).ToArray();

            foreach (var z in wynik13)
                Console.WriteLine(z.Imie + " " + z.Nazwisko + z.BMI);

            dynamic a = "ala ma kota";
            a = 3;

            var wynik14 = zawodnicy.Select(x => new { x.Imie, x.Nazwisko, x.BMI }).Where(x => x.BMI > 20).ToArray();
            var wynik15 = zawodnicy.Where(x => x.BMI > 20).Select(x => new { x.Imie, x.Nazwisko, x.BMI }).ToArray();


            var wynik16 = (from x in zawodnicy
                           where x.BMI > 20 && x.Kraj != "GER"
                           select new { x.Imie, x.Nazwisko, x.BMI }).ToArray();





            Console.ReadKey();


        }
    }
}
