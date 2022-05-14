using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P01WstepLINQ
{
    enum TypImportu
    {
        Loklany,
        Zdalny,
    }


    class ManagerZawodnikow
    {
        private const char separator = ';';
        private const string nowaLinia = "\r\n";
        public string sciezka;
        private Zawodnik[] zawodnicy;
        private string[] wierszeZleSformatowane;
        private TypImportu typImportu;
   
        public string[] WierszeZleSformatowane
        {
            get
            {
                return wierszeZleSformatowane;
            }
        }


        public ManagerZawodnikow(string sciezka, TypImportu typImportu)
        {
            this.sciezka = sciezka; // this odwołuje siędo ciała klasy i jest potzrebne tylko w styuacji gdy wystepuje konflikt nazw
            this.typImportu = typImportu;
        }

        public Zawodnik[] PodajZawodnikow()
        {
            return zawodnicy;
        }

        public void WygenerujZawodnikow()
        {
            string dane = null;
            if (typImportu == TypImportu.Loklany)
                dane = ImportLokalny(sciezka);
            else if (typImportu == TypImportu.Zdalny)
                dane = ImportZdalny(sciezka);
            else
                throw new Exception("Nieznany typ importu");

            string[] wiersze = dane.Split(new string[1] { nowaLinia }, StringSplitOptions.RemoveEmptyEntries);
            int liczbaWierszy = wiersze.Length;
            List<Zawodnik> zawodnicy = new List<Zawodnik>();
            List<string> wierszeZleSformatowane = new List<string>();
            for (int i = 1; i < liczbaWierszy; i++)
            {
                string[] komorki = wiersze[i].Split(separator);
                try
                {
                    Zawodnik z = new Zawodnik();
                    z.Id = Convert.ToInt32(komorki[0]);
                    z.IdTrenera = Convert.ToInt32(komorki[1]);
                    z.Imie = komorki[2];
                    z.Nazwisko = komorki[3];
                    z.Kraj = komorki[4];
                    z.DataUrodzenia = Convert.ToDateTime(komorki[5]);
                    z.Wzrost = Convert.ToInt32(komorki[6]);
                    z.Waga = Convert.ToInt32(komorki[7]);
                    zawodnicy.Add(z); 
                }
                catch (Exception)
                {
                    wierszeZleSformatowane.Add(wiersze[i]);
                }
            }
            this.zawodnicy= zawodnicy.ToArray();
            this.wierszeZleSformatowane = wierszeZleSformatowane.ToArray();
        }


        public double PodajSredniWzrost()
        {
            int[] wartosci = new int[zawodnicy.Length];
            for (int i = 0; i < zawodnicy.Length; i++)
                wartosci[i] = zawodnicy[i].Wzrost;

            return PoliczSrednia(wartosci);
        }
        public double PodajSredniWage()
        {
            int[] wartosci = new int[zawodnicy.Length];
            for (int i = 0; i < zawodnicy.Length; i++)
                wartosci[i] = zawodnicy[i].Waga;

            return PoliczSrednia(wartosci);
        }

        public GrupaKraj[] PodajSredniWzrostDlaKazdegoKraju()
        {
            string[] kraje = PodajKraje();

            List<GrupaKraj> gk = new List<GrupaKraj>();

            foreach (var k in kraje)
            {
                int[] w = PodajWzrost(k);
                double sredniWzrost = PoliczSrednia(w);

                GrupaKraj g = new GrupaKraj();
                g.NazwaKraju = k;
                g.SredniWzrost = sredniWzrost;

                gk.Add(g);
            }

            return gk.ToArray();
        }


        private double PoliczSrednia(int[] wartosci)
        {
            double a = 0;
            foreach (var e in wartosci)
                a += e;

            return a / wartosci.Length;
        }

        private string[] PodajKraje()
        {
            List<string> kraje = new List<string>();

            foreach (var z in zawodnicy)
                if (!kraje.Contains(z.Kraj))
                    kraje.Add(z.Kraj);

            return kraje.ToArray();
        }

        private int[] PodajWzrost(string kraj)
        {
            List<int> wzrosty = new List<int>();

            foreach (var z in zawodnicy)
                if (z.Kraj == kraj)
                    wzrosty.Add(z.Wzrost);

            return wzrosty.ToArray();
        }

        private string ImportLokalny(string sciezka)
        {
            return File.ReadAllText(sciezka);
        }

        private string ImportZdalny(string sciezka)
        {
            return new WebClient().DownloadString(sciezka);
        }
    }
}
