using P02AplikacjaZawodnicy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Repositories
{
    class ZawodnicyRepository
    {

        public Zawodnik[] WczytajZawodnikow()
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            return db.Zawodnik.ToArray();
        }


        public void DodajZawodnika(Zawodnik z)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            z.IdTrenera = z.IdTrenera == 0 ? null : z.IdTrenera;
            db.Zawodnik.InsertOnSubmit(z);
            db.SubmitChanges();
        }

        public void Edytuj(Zawodnik z)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            Zawodnik doEdycji = db.Zawodnik.FirstOrDefault(x => x.Id == z.Id);
            doEdycji.Imie = z.Imie;
            doEdycji.Nazwisko = z.Nazwisko;
            doEdycji.Kraj = z.Kraj;
            doEdycji.DataUr = z.DataUr;
            doEdycji.Wzrost = z.Wzrost;
            doEdycji.Waga = z.Waga;
            doEdycji.IdTrenera = z.IdTrenera == 0 ? null : z.IdTrenera;
            db.SubmitChanges();

        }

        //params - mogę podać jednego lub wielu po przecinku, lub po prostu całą kolekcję 
        public void Usun(params Zawodnik[] zawodnicy)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            int[] szukaneIdiki = zawodnicy.Select(y => y.Id).ToArray();
            Zawodnik[] doUsuniecia = db.Zawodnik.Where(x => szukaneIdiki.Contains(x.Id)).ToArray();
            db.Zawodnik.DeleteAllOnSubmit(doUsuniecia);
            db.SubmitChanges();
        }
    }
}
