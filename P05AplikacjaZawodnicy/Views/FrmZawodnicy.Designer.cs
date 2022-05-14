
namespace P02AplikacjaZawodnicy.Views
{
    partial class FrmZawodnicy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDane = new System.Windows.Forms.ListBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.btnTrenerzy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbNieaktywni = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDane
            // 
            this.lbDane.FormattingEnabled = true;
            this.lbDane.Location = new System.Drawing.Point(22, 33);
            this.lbDane.Name = "lbDane";
            this.lbDane.Size = new System.Drawing.Size(208, 199);
            this.lbDane.TabIndex = 0;
            this.lbDane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDane_MouseDown);
            this.lbDane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbDane_MouseMove);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(6, 19);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.Location = new System.Drawing.Point(6, 48);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(75, 23);
            this.btnEdytuj.TabIndex = 2;
            this.btnEdytuj.Text = "Edytuj";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            this.btnEdytuj.Click += new System.EventHandler(this.btnEdytuj_Click);
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Location = new System.Drawing.Point(6, 19);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(75, 23);
            this.btnWczytaj.TabIndex = 3;
            this.btnWczytaj.Text = "Wczytaj";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // btnTrenerzy
            // 
            this.btnTrenerzy.Location = new System.Drawing.Point(6, 48);
            this.btnTrenerzy.Name = "btnTrenerzy";
            this.btnTrenerzy.Size = new System.Drawing.Size(75, 23);
            this.btnTrenerzy.TabIndex = 4;
            this.btnTrenerzy.Text = "Trenerzy";
            this.btnTrenerzy.UseVisualStyleBackColor = true;
            this.btnTrenerzy.Click += new System.EventHandler(this.btnTrenerzy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodaj);
            this.groupBox1.Controls.Add(this.btnEdytuj);
            this.groupBox1.Location = new System.Drawing.Point(250, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zawodnik";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWczytaj);
            this.groupBox2.Controls.Add(this.btnTrenerzy);
            this.groupBox2.Location = new System.Drawing.Point(256, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 79);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program";
            // 
            // lbNieaktywni
            // 
            this.lbNieaktywni.AllowDrop = true;
            this.lbNieaktywni.FormattingEnabled = true;
            this.lbNieaktywni.Location = new System.Drawing.Point(351, 39);
            this.lbNieaktywni.Name = "lbNieaktywni";
            this.lbNieaktywni.Size = new System.Drawing.Size(208, 199);
            this.lbNieaktywni.TabIndex = 7;
            this.lbNieaktywni.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbNieaktywni_DragDrop);
            this.lbNieaktywni.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbNieaktywni_DragEnter);
            // 
            // FrmZawodnicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 250);
            this.Controls.Add(this.lbNieaktywni);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbDane);
            this.Name = "FrmZawodnicy";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDane;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.Button btnTrenerzy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbNieaktywni;
    }
}

