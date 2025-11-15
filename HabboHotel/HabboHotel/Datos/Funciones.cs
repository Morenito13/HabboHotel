using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabboHotel.Datos
{
    internal class Funciones
    {

        public static void AbrirFormInPanel(Form parentForm, object formHijo)
        {
            Panel panelContenedor = (Panel)parentForm.Controls["panelPadre"];
            if (panelContenedor.Controls.Count > 0)
                panelContenedor.Controls.RemoveAt(0);

            Form fh = formHijo as Form;
            if (fh != null)
            {
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                panelContenedor.Controls.Add(fh);
                panelContenedor.Tag = fh;
                fh.Show();
            }
        }
        public static void CerrarFormInPanel(Form parentForm)
        {
            Panel panelContenedor = (Panel)parentForm.Controls["panelPadre"];
            if (panelContenedor.Controls.Count > 0)
            {
                Form fh = panelContenedor.Controls[0] as Form;
                if (fh != null)
                {
                    fh.Close();
                }
                if (panelContenedor.Controls.Count > 0)
                {
                    panelContenedor.Controls.RemoveAt(0);
                }
                panelContenedor.Tag = null;
            }
        }
        public static void Logs(string nombre_archivo, string detalle)
        {
            try
            {
                string directorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                string nombreArchivoDiario = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                string rutaArchivo = Path.Combine(directorio, nombreArchivoDiario);

                string cabecera = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} | FUENTE: {nombre_archivo}";
                string separador = "-------------------------------------------------------------------";

                using (StreamWriter mi_archivo = new StreamWriter(rutaArchivo, true))
                {
                    mi_archivo.WriteLine(cabecera);
                    mi_archivo.WriteLine(detalle); 
                    mi_archivo.WriteLine(separador);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error CRITICO al escribir log (Fuente: {nombre_archivo}): {ex.Message}");
                Console.WriteLine($"Detalle original no guardado: {detalle}");
            }
        }
    }
}
