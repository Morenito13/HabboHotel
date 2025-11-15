namespace HabboHotel
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTodasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasActivasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huespedesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminsitrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeReservasPorHuespedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPadre = new System.Windows.Forms.Panel();
            this.consultarReservasPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.habitacionesToolStripMenuItem,
            this.reservasToolStripMenuItem1,
            this.huespedesToolStripMenuItem,
            this.baseDeDatosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // habitacionesToolStripMenuItem
            // 
            this.habitacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTodasToolStripMenuItem,
            this.administrarToolStripMenuItem});
            this.habitacionesToolStripMenuItem.Name = "habitacionesToolStripMenuItem";
            this.habitacionesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.habitacionesToolStripMenuItem.Text = "Habitaciones";
            // 
            // verTodasToolStripMenuItem
            // 
            this.verTodasToolStripMenuItem.Name = "verTodasToolStripMenuItem";
            this.verTodasToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.verTodasToolStripMenuItem.Text = "Ver todas";
            this.verTodasToolStripMenuItem.Click += new System.EventHandler(this.verTodasToolStripMenuItem_Click);
            // 
            // administrarToolStripMenuItem
            // 
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.administrarToolStripMenuItem.Text = "Administrar ";
            this.administrarToolStripMenuItem.Click += new System.EventHandler(this.administrarToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem1
            // 
            this.reservasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem1,
            this.reservasActivasToolStripMenuItem,
            this.consultarReservasPorFechaToolStripMenuItem});
            this.reservasToolStripMenuItem1.Name = "reservasToolStripMenuItem1";
            this.reservasToolStripMenuItem1.Size = new System.Drawing.Size(64, 20);
            this.reservasToolStripMenuItem1.Text = "Reservas";
            // 
            // administrarToolStripMenuItem1
            // 
            this.administrarToolStripMenuItem1.Name = "administrarToolStripMenuItem1";
            this.administrarToolStripMenuItem1.Size = new System.Drawing.Size(223, 22);
            this.administrarToolStripMenuItem1.Text = "Administrar";
            this.administrarToolStripMenuItem1.Click += new System.EventHandler(this.administrarToolStripMenuItem1_Click);
            // 
            // reservasActivasToolStripMenuItem
            // 
            this.reservasActivasToolStripMenuItem.Name = "reservasActivasToolStripMenuItem";
            this.reservasActivasToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.reservasActivasToolStripMenuItem.Text = "Reservas activas";
            this.reservasActivasToolStripMenuItem.Click += new System.EventHandler(this.reservasActivasToolStripMenuItem_Click);
            // 
            // huespedesToolStripMenuItem
            // 
            this.huespedesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminsitrarToolStripMenuItem,
            this.historialDeReservasPorHuespedToolStripMenuItem});
            this.huespedesToolStripMenuItem.Name = "huespedesToolStripMenuItem";
            this.huespedesToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.huespedesToolStripMenuItem.Text = "Huespedes";
            // 
            // adminsitrarToolStripMenuItem
            // 
            this.adminsitrarToolStripMenuItem.Name = "adminsitrarToolStripMenuItem";
            this.adminsitrarToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.adminsitrarToolStripMenuItem.Text = "Historial de reservas";
            this.adminsitrarToolStripMenuItem.Click += new System.EventHandler(this.adminsitrarToolStripMenuItem_Click);
            // 
            // historialDeReservasPorHuespedToolStripMenuItem
            // 
            this.historialDeReservasPorHuespedToolStripMenuItem.Name = "historialDeReservasPorHuespedToolStripMenuItem";
            this.historialDeReservasPorHuespedToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.historialDeReservasPorHuespedToolStripMenuItem.Text = "Historial de reservas por huesped";
            // 
            // baseDeDatosToolStripMenuItem
            // 
            this.baseDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexionToolStripMenuItem});
            this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.baseDeDatosToolStripMenuItem.Text = "Base de datos";
            // 
            // conexionToolStripMenuItem
            // 
            this.conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            this.conexionToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.conexionToolStripMenuItem.Text = "Conexion";
            this.conexionToolStripMenuItem.Click += new System.EventHandler(this.conexionToolStripMenuItem_Click);
            // 
            // panelPadre
            // 
            this.panelPadre.Location = new System.Drawing.Point(0, 27);
            this.panelPadre.Name = "panelPadre";
            this.panelPadre.Size = new System.Drawing.Size(800, 423);
            this.panelPadre.TabIndex = 1;
            // 
            // consultarReservasPorFechaToolStripMenuItem
            // 
            this.consultarReservasPorFechaToolStripMenuItem.Name = "consultarReservasPorFechaToolStripMenuItem";
            this.consultarReservasPorFechaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.consultarReservasPorFechaToolStripMenuItem.Text = "Consultar reservas por fecha";
            this.consultarReservasPorFechaToolStripMenuItem.Click += new System.EventHandler(this.consultarReservasPorFechaToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPadre);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Habbo Hotel";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huespedesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminsitrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeReservasPorHuespedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionToolStripMenuItem;
        private System.Windows.Forms.Panel panelPadre;
        private System.Windows.Forms.ToolStripMenuItem verTodasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reservasActivasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarReservasPorFechaToolStripMenuItem;
    }
}

