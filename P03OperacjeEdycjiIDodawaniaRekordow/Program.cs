using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03OperacjeEdycjiIDodawaniaRekordow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();

            // edycja 

            // najpierw musimy pobirac te elementy, które chcemy edytować 
            var polacy= db.Zawodnik.Where(x => x.kraj == "pol").ToArray();
            polacy[0].imie += "X";

            db.SubmitChanges();


            Zawodnik z= db.Zawodnik.Where(x => x.id_zawodnika==2).ToArray().FirstOrDefault();
            z.imie += "Y";
            db.SubmitChanges();

            Zawodnik z2= db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == 2);

            Zawodnik z3 = db.Zawodnik.First(x => x.id_zawodnika == 2);

            // edycja: krok 1: pobranie z bazy, potem edycja lokalnie, potem submit do bazy

            // Tworzenie nowych rekordow 

            Zawodnik nowy = new Zawodnik();
            nowy.kraj = "POL";
            nowy.imie = "Jan";
            nowy.nazwisko = "KOWALSKI";

            db.Zawodnik.InsertOnSubmit(nowy); // na tabelce MUSI byc nalozony klucz glowny 
            db.SubmitChanges();

            // usuwanie danych 

            // podobnie jak edycja 

            Zawodnik doUsuniecia = db.Zawodnik.FirstOrDefault(x => x.id_zawodnika == 25);
            db.Zawodnik.DeleteOnSubmit(doUsuniecia);
            db.SubmitChanges();

        }
    }
}
