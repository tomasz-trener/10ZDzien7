using P04AplikacjaZawodnicy.Operations;
using P04AplikacjaZawodnicy.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P04AplikacjaZawodnicy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            ZawodnicyOperation zo = new ZawodnicyOperation();
            ZawodnikVM[] zawodnicyWidoku=  zo.PodajZawodnikowZBazy();

            lbDane.DataSource = zawodnicyWidoku;
            lbDane.DisplayMember = "Wiersz";

        }
    }
}
