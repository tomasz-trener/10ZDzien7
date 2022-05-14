
using P05AplikacjaZawodnicy.ViewModels;
using P07AplikacjaZawodnicy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Operations
{
    internal class ZawodnicyOperation
    {

        private Zawodnik MapujNaZawodnikDB(ZawodnikVM z)
        {
            return new Zawodnik()
            {
                Id = z.Id,
                Imie = z.Imie,
                Nazwisko = z.Nazwisko,
                Kraj = z.Kraj,
                DataUr = z.DataUr,
                IdTrenera = z.IdTrenera,
                Wzrost = z.Wzrost,
                Waga = z.Waga,
            };
        }
        public ZawodnikVM[] PodajZawodnikowZBazy()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zawodnicy = zr.WczytajZawodnikow();

            // rolą operacji jest (miedzy innymi)  zeby przetransformowac obiekt bazodanowy na obiekt ViewModel, który bedzie wyswietlany na widoku 
            
            //moze być tak, że niektore pola w bazie bedą trochę inne niz pola na interfejsie graficznym np: taka sytuacja jest w przypadku daty 
            // gdzie w bazie danych data moze byc pusta (null) ale nasz interfejs graficzny nie pozwala technicze na ustawienie pustej daty 
           return zawodnicy.Select(x => new ZawodnikVM()
            {
                Id = x.Id,
                Imie = x.Imie,
                Nazwisko = x.Nazwisko,
                Kraj = x.Kraj,
                DataUr = x.DataUr == null ? DateTime.Now : (DateTime)x.DataUr,
                Wzrost = x.Wzrost,
                Waga = x.Waga == null ? 0 : (int)x.Waga
            }).ToArray();
        }

        public void DodajZawodnikowDoBazy(ZawodnikVM z)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zDB = MapujNaZawodnikDB(z);
            zr.DodajZawodnika(zDB);
        }

        public void Edytuj(ZawodnikVM z)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zDB = MapujNaZawodnikDB(z);
            zr.Edytuj(zDB);
        }


        public void Usun(params ZawodnikVM[] zawodnicy)
        {

            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zawDB = zawodnicy.Select(x => MapujNaZawodnikDB(x)).ToArray();
            zr.Usun(zawDB);
        }



    }
}
