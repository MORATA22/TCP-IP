﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace conexion
{
    public partial class Cliente : Form
    {
        const string cod = @"archivo/01hola";
        const Int32 port = 1000;
        public Cliente()
        {
            InitializeComponent();
        }
        
        public void conec(string server, string mess)
        {
            try
            {
                //Instanciamos un cliente para conectarse al servidor
                TcpClient client = new TcpClient(server, port);
                
                //Pasamos la variable mess (mensaje) ha ASCII y lo metemos dentro de un array de byte
                Byte[] dades = System.Text.Encoding.ASCII.GetBytes(mess);

                //Con NetworkStream nos proporciona el acceso a la red (GetStream utilizado para enviar y recibir datos).
                NetworkStream stream = client.GetStream();

                //stream.Write escribimos en NetworkStream(flujo de red), en este caso ponemos nuestro array de bytes donde está todo nuestro mensaje(dades) y lo enviamos
                stream.Write(dades, 0, dades.Length);

                //Invocamos al control para poder acceder a el
                if (labconver.InvokeRequired)
                {
                    labconver.Invoke((MethodInvoker)delegate { labconver.Text = txtenviar.Text; });
                }
                else
                {
                    labconver.Text = txtenviar.Text;
                }

                //Generamos un nuevo array vacio
                dades = new Byte[256];
                string mensaje = "";

                // stream.Read leemos el flujo de red de nuestro NetworkStream
                Int32 bytes = stream.Read(dades, 0, dades.Length);
                //Pasamos a una cadena el array de bytes y lo guardamos en un string
                mensaje = System.Text.Encoding.ASCII.GetString(dades, 0, bytes);

                //invocamos a un control diferente al de antes y ponemos el mensaje que nos ha llegado
                if (labresp.InvokeRequired)
                {
                    labresp.Invoke((MethodInvoker)delegate { labresp.Text = mensaje; });
                }
                else
                {
                    labresp.Text = mensaje;
                }

                //Lo mismo de antes pero para un archivo
                dades = new Byte[1024];

                String responseData = String.Empty;
                //leemos array
                Int32 byt = stream.Read(dades, 0, dades.Length);
                //Generamos cadena
                responseData = System.Text.Encoding.ASCII.GetString(dades, 0, byt);

                if (labarc.InvokeRequired)
                {
                    labarc.Invoke((MethodInvoker)delegate { labarc.Text = responseData; });
                }
                else
                {
                    labarc.Text = responseData;
                }
                //Cerramos conexiones
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
                SendFiles("127.0.0.1", cod, port);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        public void SendFiles(string codi,string IPA, Int32 PortN)
        {
            byte[] SendingBuffer = null;
            NetworkStream _nStream;
            int _BufferSize = 1024;


            try
            {
                TcpClient _Client = new TcpClient(IPA, PortN);
               
                _nStream = _Client.GetStream();
                FileStream Fs = new FileStream(codi, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32
                    (Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(_BufferSize)));
                progressBar1.Maximum = NoOfPackets;
                int TotalLength = (int)Fs.Length, CurrentPacketLength, counter = 0;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > _BufferSize)
                    {
                        CurrentPacketLength = _BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                        CurrentPacketLength = TotalLength;

                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    _nStream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    if (progressBar1.Value >= progressBar1.Maximum)
                        progressBar1.Value = progressBar1.Minimum;

                    progressBar1.PerformStep();
                }
               
                Fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

    }    
}
