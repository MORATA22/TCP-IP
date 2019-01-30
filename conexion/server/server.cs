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
          
            Thread serverThread = new Thread(ReceiveFiles);
            // lo inicimaos con start
            serverThread.SetApartmentState(ApartmentState.STA);           
            serverThread.Start();

        }

        private void conex()
        {
            //instancias un cliente y un server tcp para verse
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
                    
                    //Pending determinamos si hay conexiones
                    if (lisen.Pending())
                    {
                        try
                        {
                            //Al ver que hay conexiones accepta las solicitudes de los clientes
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
                            //getstream enviar y recibir datos
                            NetworkStream stream = cliente.GetStream();

                            //Le ponemos al bucle que con Streamread mire si hay algo en el array de bytes mientras sea diferente ha 0 entrará en el bucle
                            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                //cadena recibida
                                mensaje = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                                if (labreci.InvokeRequired)
                                {
                                    labreci.Invoke((MethodInvoker)delegate { labreci.Text = mensaje; });
                                }
                                else
                                {
                                    labreci.Text = mensaje;
                                }

                                //Pasamos la variable respuesta Ha un array de bytes(by)
                                string respuesta = "Recibido";
                                byte[] by = System.Text.Encoding.ASCII.GetBytes(respuesta);
                                //escribimos en el flujo de red
                                stream.Write(by, 0, by.Length);

                                if (labenvia.InvokeRequired)
                                {
                                    labenvia.Invoke((MethodInvoker)delegate { labenvia.Text = respuesta; });
                                }
                                else
                                {
                                    labenvia.Text = respuesta;
                                }

                                //Lo mismo de antes pero para poner en el label el contenido del archivo y escribirlo en la red
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
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Error de conexion: {0}", e);
                        }
                            cliente.Close();                        
                    }                       
                }
            }
        }
       
        public void ReceiveFiles()
        {
            int port = 1000;
            IPAddress IPA = IPAddress.Parse("127.0.0.1");
            TcpListener _Listener = new TcpListener(IPA, port);
            NetworkStream _nStream;
            TcpClient _Client = new TcpClient();
            const int _BufferSize = 1024;
            try
            {              
                ///Instanciamos un nuevo TcpListener, que escuche a cualquier ip
                ///y por el puerto que usamos
               
                ///Iniciamos el listener
                _Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] RecData = new byte[_BufferSize];
            int RecBytes;

            for (; ; )
            {
                string _Status = string.Empty;
                try
                {
                    ///Sacamos un messagebox que pregunta si queremos recibir el fichero o no
                    string message = "Accept the Incoming File ";
                    string caption = "Incoming Connection";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    ///si hay solicitudes de conexion pendientes hace todo esto,
                    ///sino simplemente sigue escuchando
                    if (_Listener.Pending())
                    {
                        ///Indicamos al Listener que acepte las solicitudes de
                        ///conexion pendiente de el TCPClient
                        _Client = _Listener.AcceptTcpClient();
                        // Get a stream object for reading and writing
                        _nStream = _Client.GetStream();
                        _Status = "Connected to a client\n";
                        result = MessageBox.Show(message, caption, buttons);
                        ///Si la respuesta del messagebox ha sido que si que queremos recibir el fichero
                        ///hacemos esto y sino no hacemos nada
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            string SaveFileName = string.Empty;
                            ///pedimos una ubicacion para guardar el archivo que vamos a recibir
                            SaveFileDialog DialogSave = new SaveFileDialog();
                            ///filtramos que se muestren todos los archivos
                            DialogSave.Filter = "All files (*.*)|*.*";
                            ///restaura el cuadro de dialogo antes de cerrarse
                            DialogSave.RestoreDirectory = true;
                            ///definimos un titulo
                            DialogSave.Title = "Where do you want to save the file?";
                            ///directorio inicial
                            DialogSave.InitialDirectory = @"C:/";
                            ///indica que se ha guardado correctamente
                            if (DialogSave.ShowDialog() == DialogResult.OK)
                                SaveFileName = DialogSave.FileName;
                            ///si hemos puesto nombre al archivo
                            if (SaveFileName != string.Empty)
                            {
                                int totalrecbytes = 0;
                                ///definimos un nuevo filestream con los parametros: el archivo que estamos guardando, le decimos 
                                ///que lo abra o lo cree si no existe, le damos permisos de escritura
                                FileStream Fs = new FileStream(SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                                ///Mientras que el buffer sea mas grande a 0 sigue con el bucle
                                while ((RecBytes = _nStream.Read(RecData, 0, RecData.Length)) > 0)
                                {
                                    ///Escribe lo que hay en el buffer
                                    Fs.Write(RecData, 0, RecBytes);
                                    totalrecbytes += RecBytes;
                                }
                                ///Cerramos todo
                                Fs.Close();
                                _nStream.Close();
                                _Client.Close();
                            }                   
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //netstream.Close();
                }
            }
        }

        private string larchivo()
        {
            string linia;
            string archivo = null;
            //Leemos en el flujo de red el archivo hola.txt
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
