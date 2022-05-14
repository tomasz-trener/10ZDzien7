
namespace P02AplikacjaZawodnicy.Views
{
    partial class FrmTrenerzy
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
            this.dgvDane = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDane
            // 
            this.dgvDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDane.Location = new System.Drawing.Point(12, 12);
            this.dgvDane.Name = "dgvDane";
            this.dgvDane.Size = new System.Drawing.Size(552, 340);
            this.dgvDane.TabIndex = 0;
            this.dgvDane.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDane_CellEndEdit);
            this.dgvDane.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDane_RowsAdded);
            this.dgvDane.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDane_UserDeletingRow);
            // 
            // FrmTrenerzy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 364);
            this.Controls.Add(this.dgvDane);
            this.Name = "FrmTrenerzy";
            this.Text = "FrmTrenerzy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTrenerzy_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDane;
    }
}