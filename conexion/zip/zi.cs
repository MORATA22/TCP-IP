using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace zip
{
    public partial class zi : Form
    {
        //Vatiables para comprimir y descomprimir
        const string Compri = @"archivo\01hola";
        const string CompressArchive = @"archivo\pruebazip.zip";
        const string Decompri = @"archivo";        

        public zi()
        {
            InitializeComponent();
        }
        
        private void Comprimir()
        {
            try
            {
                //ZipFile utilizado para trabjar con Zips
                //CreateFromDirectory creamos el archivo zip, la primera variable, compri, es nuestro archivo y la segunda, CompressArchive, el resultado(CompressArchive la variable que guarda  el zip creado)
                ZipFile.CreateFromDirectory(Compri, CompressArchive);
            }
            catch (IOException)
            {
                //Borra el archivo indicado
                File.Delete(CompressArchive);
                //Creamos completamente nuevo el zip
                ZipFile.CreateFromDirectory(Compri, CompressArchive);
            }
            catch (UnauthorizedAccessException)
            {
                //Mensaje de error si hay algún problema
                MessageBox.Show("Error al comprimir");
            }
        }
        
        private void Descomprimir()
        {
            try
            {
                //ExtractToDirectory estraemos los arhivos del zip, CompressArchive nuestro archivo(zip) Decompri resultado de la descomprsión
                ZipFile.ExtractToDirectory(CompressArchive, Decompri);
            }
            catch (IOException)
            {
                ////Directory nos permite trabajar con archivos entre directorios y subdirectorios
                ///Directory.GetFiles Devuelve los nombres de archivos
                ///Directory.GetDirectories Devuelve los nombres de subdirectorios
                ///Creamos dos arrays y después los recorremos con un foreach

                string[] FilePath = Directory.GetFiles(Decompri);
                string[] carpetas = Directory.GetDirectories(Decompri);
                foreach (string fp in FilePath) File.Delete(fp);
                foreach (string cp in carpetas) Directory.Delete(cp);
                // ExtractToDirectory Extraemos todos los archivos de un zip
                ZipFile.ExtractToDirectory(CompressArchive, Decompri);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Error al descomprimir");
            }
        }

        private void butcomp_Click(object sender, EventArgs e)
        {
            Comprimir();
        }

        private void butdesc_Click(object sender, EventArgs e)
        {
            Descomprimir();
        }
    }
}
