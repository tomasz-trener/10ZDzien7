namespace P02AplikacjaZawodnicy.Repositories
{
    partial class ModelBazyDanychDataContext
    {
    }

    public partial class Zawodnik
    {
        public string Wiersz { get { return Imie + " " + Nazwisko; } }
    }
}