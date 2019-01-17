using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace server
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }

        private void server_Load(object sender, EventArgs e)
        {
           labestado.Text = "Encendido";
            //instanciamos un thread que ejecute la función conex
           Thread hiloServ = new Thread(conex);
            // lo inicimaos con start
           hiloServ.Start();
        }

        private void conex()
        {
            //instancias
            TcpListener lisen = null;
            TcpClient cliente = null;
            int i = 0;


            while (true)
            {
                try
                {
                    int port = 1000;
                    IPAddress ip = IPAddress.Parse("127.0.0.1");
                    lisen = new TcpListener(ip, port);
                    lisen.Start();                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                while (true)
                {                    
                    if (lisen.Pending())
                    {                        
                        cliente = lisen.AcceptTcpClient();

                        if (labconec.InvokeRequired)
                        {
                            labconec.Invoke((MethodInvoker)delegate { labconec.Text = "Conectado al cliente\n"; });
                        }
                        else
                        {
                            labconec.Text = "Conectado al cliente\n";
                        }
                        Byte[] bytes = new Byte[256];

                        string mensaje = "";
                        NetworkStream stream = cliente.GetStream();

                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {                            
                            mensaje = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            if (labreci.InvokeRequired)
                            {
                                labreci.Invoke((MethodInvoker)delegate { labreci.Text = mensaje; });
                            }
                            else
                            {
                                labreci.Text = mensaje;
                            }

                            string respuesta = "Recibido";
                            byte[] by = System.Text.Encoding.ASCII.GetBytes(respuesta);

                            stream.Write(by, 0, by.Length);
                            if (labenvia.InvokeRequired)
                            {
                                labenvia.Invoke((MethodInvoker)delegate { labenvia.Text = respuesta; });
                            }
                            else
                            {
                                labenvia.Text = respuesta;
                            }

                            //archivo
                            byte[] byt = System.Text.Encoding.ASCII.GetBytes(larchivo());
                            stream.Write(byt, 0, byt.Length);

                            if (labarc.InvokeRequired)
                            {
                                labarc.Invoke((MethodInvoker)delegate { labarc.Text = larchivo(); });
                            }
                            else
                            {
                                labarc.Text = larchivo();
                            }
                        }
                            cliente.Close();
                    }                       
                }
            }
        }

        private string larchivo()
        {
            string linia;
            string archivo = null;
            StreamReader arch = new StreamReader(@"C:\Users\admin\Documents\GitHub\TCP-IP\conexion\dll\hola.txt");

            while ((linia = arch.ReadLine()) != null)
            {
                archivo = archivo + linia + "\n";
            }

            arch.Close();
            return archivo;
        }

        private void butzip_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form zip = new zip.zi();
            zip.Show();
        }
    }
}
