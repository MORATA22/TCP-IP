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

        private void conectar_Click(object sender, EventArgs e)
        {
            if (txtenviar.Text != "")
            {
                conec("127.0.0.1");
            }
            else
            {
                
            }
        }
    }
}
