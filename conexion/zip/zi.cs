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
using System.Data.SqlClient;
using System.Configuration;

namespace zip
{
    public partial class zi : Form
    {
        //Vatiables para comprimir y descomprimir
        const string Compri = "archivo/01hola";
        const string CompressArchive = "archivo/pruebazip.zip";
        const string Decompri = "archivo";

        //Var para las letras aleatorias
        String[] alphabet = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        String[] numletfile = new String[1000000];
        String[] lett = new String[26];
        Random num = new Random();
        String conte = String.Empty;
        

        #region ZIPs
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
        #endregion


        private void butencrip_Click(object sender, EventArgs e)
        {
            //Ejecutamos la creación d elo ficheros a partir de un botón
            files();
            MessageBox.Show("Archivos generados correctamente");
        }

        private String[] crealetters(int number)
        {
            //StreamWrite para escribir en los archivos de la variable file
            //Ruta donde estarán los archivos
            //Bucle for para poner el billon de letras dentro de un fichero
            String file = "Crip/encrip" + number + ".txt";
            StreamWriter wfile = new StreamWriter(file);

            for (int i = 0; i < numletfile.Length; i++)
            {
                //randomnum recorreremos el array alphabet aleatoriamente por el objeto num
                //Con el StreamWrite wfile escribimos el contenido de la variable conte
                //Finalmente igualamos nuestro array numletfile[1000000] al conte y lo retornamos para utilizarlo mas adelante
                int randomnum = num.Next(0, 25);
                conte = alphabet[randomnum];
                wfile.Write(conte);
                numletfile[i] = conte;
            }
            wfile.Close();
            return numletfile;
        }
        private void files()
        {
            //En esta función creamos un array de 16 millones y lo igualamos a la función anterior crealetters
            //Esto ejecutará la función anterior 4 veces,crealetters (generará 4 archivos con un millón de letras cada uno)
            String[] random = new string[16000000];

            for (int i = 1; i <= 4; i++)
            {
                random = crealetters(i);
                XifrarLLetraNum(random, i);
            }
        }        

        public string[] CodiLletra()
        {
            SqlConnection connexxion = new SqlConnection();
            connexxion.ConnectionString = ConfigurationManager.ConnectionStrings["RepublicSystemConnectionString"].ConnectionString;
            connexxion.Open();

            DataSet dtsCli = new DataSet();

            string query = "SELECT Numbers from InnerEncryptionData where IdInnerEncryption = 24";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connexxion);
            adapter.Fill(dtsCli);

            string[] LletraCodi = new string[26];

            for (int i = 0; i < LletraCodi.Length; i++)
            {

                LletraCodi[i] = dtsCli.Tables[0].Rows[i][0].ToString();

            }

            return LletraCodi;
        }
        private void XifrarLLetraNum(string[] crearLletres, int num)
        {
            bool verifica;
            string rutaFitxer = "Crip/encrip" + num + ".txt";
            lett = CodiLletra();
            StreamWriter XifratNums = new StreamWriter(rutaFitxer);
            for (int i = 0; i < crearLletres.Length; i++)
            {
                verifica = false;
                for (int x = 0; x < alphabet.Length && verifica == false; x++)
                {
                    if (crearLletres[i].Equals(alphabet[x]))
                    {
                        XifratNums.Write(lett[x]);
                        verifica = true;
                    }
                }
            }
            XifratNums.Close();
        }
    }
}
