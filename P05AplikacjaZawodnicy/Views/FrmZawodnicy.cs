using P02AplikacjaZawodnicy.Domain;
using P02AplikacjaZawodnicy.Repositories;
using P02AplikacjaZawodnicy.Tools;
using P05AplikacjaZawodnicy.Repositories;
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
    public partial class FrmZawodnicy : Form
    {
        public FrmZawodnicy()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            Odswiez();
        }

        public void Odswiez()
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            Zawodnik[] zawodnicy = zr.WczytajZawodnikow();
            lbDane.DataSource = zawodnicy;
            lbDane.DisplayMember = "Wiersz"; // to musi być właściwość (a nie pole)
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmSzczegoly fs = new FrmSzczegoly(this);
            fs.Show();
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;
            FrmSzczegoly fs = new FrmSzczegoly(this,zaznaczony);
            fs.Show();
        }

        private void btnTrenerzy_Click(object sender, EventArgs e)
        {
            FrmTrenerzy ft = new FrmTrenerzy();
            ft.Show();
        }

        private Point mDownPos; 
        private void lbDane_MouseDown(object sender, MouseEventArgs e)
        {
            mDownPos = e.Location;
        }

        private void lbDane_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) 
                return;

            int index = lbDane.IndexFromPoint(e.Location);
            if (index < 0)
                return;

            if (Math.Abs(e.X - mDownPos.X) >= SystemInformation.DragSize.Width ||
               Math.Abs(e.Y - mDownPos.Y) >= SystemInformation.DragSize.Height)
                DoDragDrop(new DragObject(lbDane, lbDane.Items[index]), DragDropEffects.Move);
        }

        private void lbNieaktywni_DragEnter(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (obj != null && obj.source != lbNieaktywni) e.Effect = e.AllowedEffect;
        }

        private void lbNieaktywni_DragDrop(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;

            Zawodnik tenPrzeniesiony = (Zawodnik)obj.item;
            lbNieaktywni.Items.Add(tenPrzeniesiony);


            lbNieaktywni.DisplayMember = "Wiersz";


            List<Zawodnik> zawodnicy= ((Zawodnik[])lbDane.DataSource).ToList();
            zawodnicy.RemoveAll(x => x.Id == tenPrzeniesiony.Id);
            lbDane.DataSource = null;
            lbDane.DataSource = zawodnicy.ToArray();
            lbDane.DisplayMember = "Wiersz";


        }
    }
}
