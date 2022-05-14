using P04AplikacjaZawodnicy.Repositories;
using P04AplikacjaZawodnicy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04AplikacjaZawodnicy.Operations
{
    internal class ZawodnicyOperation
    {
        public ZawodnikVM[] PodajZawodnikowZBazy()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            var zawodnicy = zr.WczytajZawodnikow();

            // rolą operacji jest (miedzy innymi)  zeby przetransformowac obiekt bazodanowy na obiekt ViewModel, który bedzie wyswietlany na widoku 
            
            //moze być tak, że niektore pola w bazie bedą trochę inne niz pola na interfejsie graficznym np: taka sytuacja jest w przypadku daty 
            // gdzie w bazie danych data moze byc pusta (null) ale nasz interfejs graficzny nie pozwala technicze na ustawienie pustej daty 
           return zawodnicy.Select(x => new ZawodnikVM()
            {
                Id = x.Id_zawodnika,
                Imie = x.Imie,
                Nazwisko = x.Nazwisko,
                Kraj = x.Kraj,
                DataUr = x.Data_ur == null ? DateTime.Now : (DateTime)x.Data_ur,
                Wzrost = x.Wzrost,
                Waga = x.Waga == null ? 0 : (int)x.Waga
            }).ToArray();
        }
    }
}
