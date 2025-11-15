namespace HabboHotel.Vistas
{
    partial class BuscarHabitacion
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
            this.dgvHabitaciones2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHabitaciones2
            // 
            this.dgvHabitaciones2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitaciones2.Location = new System.Drawing.Point(16, 76);
            this.dgvHabitaciones2.Name = "dgvHabitaciones2";
            this.dgvHabitaciones2.Size = new System.Drawing.Size(771, 342);
            this.dgvHabitaciones2.TabIndex = 6;
            this.dgvHabitaciones2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHabitaciones2_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Visualizador de todas las habitaciones (Solo las disponibles)";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(16, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BuscarHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvHabitaciones2);
            this.Controls.Add(this.label1);
            this.Name = "BuscarHabitacion";
            this.Text = "BuscarHabitacion";
            this.Load += new System.EventHandler(this.BuscarHabitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitaciones2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHabitaciones2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}