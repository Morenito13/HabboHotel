namespace HabboHotel.Vistas
{
    partial class HistorialReservaHuesped
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lbHuespedtext = new System.Windows.Forms.Label();
            this.lblNombreHuesped = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 24);
            this.label2.TabIndex = 22;
            this.label2.Text = "Historial de reservas";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(12, 132);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(776, 287);
            this.dgvHistorial.TabIndex = 21;
            // 
            // lbHuespedtext
            // 
            this.lbHuespedtext.AutoSize = true;
            this.lbHuespedtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHuespedtext.Location = new System.Drawing.Point(26, 42);
            this.lbHuespedtext.Name = "lbHuespedtext";
            this.lbHuespedtext.Size = new System.Drawing.Size(78, 20);
            this.lbHuespedtext.TabIndex = 24;
            this.lbHuespedtext.Text = "Huesped:";
            // 
            // lblNombreHuesped
            // 
            this.lblNombreHuesped.AutoSize = true;
            this.lblNombreHuesped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreHuesped.Location = new System.Drawing.Point(110, 42);
            this.lblNombreHuesped.Name = "lblNombreHuesped";
            this.lblNombreHuesped.Size = new System.Drawing.Size(25, 20);
            this.lblNombreHuesped.TabIndex = 25;
            this.lblNombreHuesped.Text = "....";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(26, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 30);
            this.button1.TabIndex = 26;
            this.button1.Text = "Buscar Huespued";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(763, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 27);
            this.button5.TabIndex = 27;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // HistorialReservaHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblNombreHuesped);
            this.Controls.Add(this.lbHuespedtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistorialReservaHuesped";
            this.Text = "HistorialReservaHuesped";
            this.Load += new System.EventHandler(this.HistorialReservaHuesped_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lbHuespedtext;
        private System.Windows.Forms.Label lblNombreHuesped;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
    }
}