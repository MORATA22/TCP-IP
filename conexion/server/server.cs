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
                        cliente.Close();
                    }                       
                }
            }
        }
    }
}
