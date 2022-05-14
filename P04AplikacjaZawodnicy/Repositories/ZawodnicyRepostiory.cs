using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04AplikacjaZawodnicy.Repositories

{
    class ZawodnicyRepository
    {

        public ZawodnikDB[] WczytajZawodnikow()
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            return db.ZawodnikDB.ToArray();
        }


        public void DodajZawodnika(ZawodnikDB z)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            db.ZawodnikDB.InsertOnSubmit(z);
            db.SubmitChanges();
        }

        public void Edytuj(ZawodnikDB z)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            ZawodnikDB doEdycji = db.ZawodnikDB.FirstOrDefault(x => x.Id_zawodnika == z.Id_zawodnika);
            doEdycji.Imie = z.Imie;
            doEdycji.Nazwisko = z.Nazwisko;
            doEdycji.Kraj = z.Kraj;
            doEdycji.Data_ur = z.Data_ur;
            doEdycji.Wzrost = z.Wzrost;
            doEdycji.Waga = z.Waga;
            db.SubmitChanges();

        }

        //params - mogę podać jednego lub wielu po przecinku, lub po prostu całą kolekcję 
        public void Usun(params ZawodnikDB[] zawodnicy)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            int[] szukaneIdiki = zawodnicy.Select(y => y.Id_zawodnika).ToArray();
            ZawodnikDB[] doUsuniecia = db.ZawodnikDB.Where(x => szukaneIdiki.Contains(x.Id_zawodnika)).ToArray();
            db.ZawodnikDB.DeleteAllOnSubmit(doUsuniecia);
            db.SubmitChanges();
        }
    }
}
