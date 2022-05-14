
using P05AplikacjaZawodnicy.Operations;
using P05AplikacjaZawodnicy.ViewModels;
using P07AplikacjaZawodnicy.Core.Domain;
using P07AplikacjaZawodnicy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P02AplikacjaZawodnicy.Views
{
    enum TrybOkienka
    {
        Dodawanie,
        Edycja,
        Inny
    }
    public partial class FrmSzczegoly : Form
    {
        FrmZawodnicy frmZawodnicy;
        ZawodnikVM edytowany;

        private TrybOkienka trybOkienka
        {
            get
            {
               return edytowany == null ? TrybOkienka.Dodawanie : TrybOkienka.Edycja;
            }
        }
        bool zakonczoneBindowanie = false;  
        public FrmSzczegoly(FrmZawodnicy frmZawodnicy)
        {
            this.frmZawodnicy = frmZawodnicy;
            InitializeComponent();
            Odswiez();
        }

        public void Odswiez(Trener zaznaczony = null)
        {
            TrenerzyRepository tr = new TrenerzyRepository();
            List<Trener> trenerzy = tr.WczytajTrenerow().ToList();
            trenerzy.Insert(0, new Trener());
            trenerzy.Insert(0, new Trener() { Imie = "(nowy)" });

            cbTrenerzy.DataSource = trenerzy.ToArray();
            cbTrenerzy.DisplayMember = "ImieNazwisko";
            zakonczoneBindowanie = true;

            // po załądowaniu danych 
            // wybieramy z trenerow tego trenera o takim samym id jak ten zaznaczony
            // i to on ma byc wyswietlany 
            if(zaznaczony != null)
                cbTrenerzy.SelectedItem = trenerzy.FirstOrDefault(x => x.Id == zaznaczony.Id);
        }

        public FrmSzczegoly(FrmZawodnicy frmZawodnicy, ZawodnikVM z) : this(frmZawodnicy)
        {
            edytowany = z;

            txtImie.Text = z.Imie;
            txtNazwisko.Text = z.Nazwisko;
            txtKraj.Text = z.Kraj;
            if (z.DataUr != null)
                dtpDataUrodzenia.Value = (DateTime)z.DataUr;
            if (z.Waga != null)
                numWaga.Value = (int) z.Waga;
            if(z.Wzrost != null)
                numWzrost.Value = (int)z.Wzrost;
            btnUsun.Visible = true;

            // sprawdzmy kto trenuje tego zawodnika 
            if(z.IdTrenera != null)
            {
                TrenerzyRepository tr = new TrenerzyRepository();
                Trener t= tr.PodajTrenera((int)z.IdTrenera);

                //cbTrenerzy.SelectedItem = t;
                // rozwiazanie na ten moment 
                foreach (Trener ityTren in (Trener[])cbTrenerzy.DataSource)
                    if (ityTren.Id == t.Id)
                    {
                        cbTrenerzy.SelectedItem = ityTren;
                        break;
                    }
                // inne rozwiaznaie z zastosowaniem LINQ 
                //cbTrenerzy.SelectedItem = ((Trener[])cbTrenerzy.DataSource).FirstOrDefault(x => x.Id == t.Id);



            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            ZawodnikVM z;
            if (trybOkienka == TrybOkienka.Dodawanie) // to jest sytuacja gdy jestesmy w trybie dodwania 
                z = new ZawodnikVM();
            else if (trybOkienka == TrybOkienka.Edycja)
                z = edytowany;
            else
                throw new NotImplementedException("Nieznany tyb");

            z.Imie = txtImie.Text;
            z.Nazwisko = txtNazwisko.Text;
            z.Kraj = txtKraj.Text;
            z.DataUr = dtpDataUrodzenia.Value;
            z.Waga = Convert.ToInt32(numWaga.Value);
            z.Wzrost = Convert.ToInt32(numWzrost.Value);
            z.IdTrenera = ((Trener)cbTrenerzy.SelectedItem).Id;

            ZawodnicyOperation zo = new ZawodnicyOperation();

            if (trybOkienka == TrybOkienka.Dodawanie)
                zo.DodajZawodnikowDoBazy(z);
            else if (trybOkienka == TrybOkienka.Edycja)
                zo.Edytuj(z);
            else
                throw new NotImplementedException("Nieznany tryb");
            
            frmZawodnicy.Odswiez();
            this.Close();

        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            DialogResult dr=
                MessageBox.Show($"Czy napewno chcesz usunać zawodnika {edytowany.Imie + " " + edytowany.Nazwisko} ? ",
                    "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                ZawodnicyOperation zo = new ZawodnicyOperation();
                zo.Usun(edytowany);
                frmZawodnicy.Odswiez();
                this.Close();
            }

            
        }

        private void cbTrenerzy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zakonczoneBindowanie && cbTrenerzy.SelectedIndex==0)
            {
                FrmTrenerzy ft = new FrmTrenerzy(this);
                ft.Show();
                zakonczoneBindowanie = false;
            }
        }
    }
}
