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

        private void Cliente_Load(object sender, EventArgs e)
        {
            //Al Cargar el form utilizamos la función conec y le mandamos un valor (IP)
            conec("127.0.0.1");            
        }
        public void conec(string server)
        {
            try
            {
                //Instanciamos TCPClient
                TcpClient client = new TcpClient(server, port);

                //Cerrar Conexión
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
