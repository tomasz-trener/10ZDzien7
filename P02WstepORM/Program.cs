using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02WstepORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModelBazyDanychDataContext db = new ModelBazyDanychDataContext();
            Zawodnik[] zawodnicy = db.Zawodnik.Where(x => x.kraj == "pol").ToArray();

            foreach (var e in  zawodnicy)
                Console.WriteLine(e.imie + " " + e.nazwisko);

            Console.ReadKey();
        }
    }
}
