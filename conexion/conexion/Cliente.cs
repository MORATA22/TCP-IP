using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace conexion
{
    public partial class Cliente : Form
    {
        public int port = 1000;
        public Cliente()
        {
            InitializeComponent();
        }
        
        public void conec(string server, string mess)
        {
            try
            {
                //Instanciamos TCPClient
                TcpClient client = new TcpClient(server, port);

                Byte[] dades = System.Text.Encoding.ASCII.GetBytes(mess);
                NetworkStream stream = client.GetStream();       
                
                stream.Write(dades, 0, dades.Length);

                if (labconver.InvokeRequired)
                {
                    labconver.Invoke((MethodInvoker)delegate { labconver.Text = txtenviar.Text; });
                }
                else
                {
                    labconver.Text = txtenviar.Text;
                }

                dades = new Byte[256];
                string mensaje = "";

                Int32 bytes = stream.Read(dades, 0, dades.Length);
                mensaje = System.Text.Encoding.ASCII.GetString(dades, 0, bytes);

                if (labresp.InvokeRequired)
                {
                    labresp.Invoke((MethodInvoker)delegate { labresp.Text = mensaje; });
                }
                else
                {
                    labresp.Text = mensaje;
                }

                dades = new Byte[1024];

                String responseData = String.Empty;
                Int32 byt = stream.Read(dades, 0, dades.Length);
                responseData = System.Text.Encoding.ASCII.GetString(dades, 0, byt);

                if (labarc.InvokeRequired)
                {
                    labarc.Invoke((MethodInvoker)delegate { labarc.Text = responseData; });
                }
                else
                {
                    labarc.Text = responseData;
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            if (txtenviar.Text != string.Empty)
            {
                conec("127.0.0.1", txtenviar.Text);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        
    }
}
