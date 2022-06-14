using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using clienteFTP;
using FluentFTP;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace PSP04gui
{
    public partial class UI : Form
    {

        string user = string.Empty;
        string pwd = string.Empty;
        string url = string.Empty;
        string[] nombreFicheros;
        bool listarDetalles = false;
        bool listarDespegable = false;
        string pathDescarga = string.Empty;
        string seleccionSubida = string.Empty;
        string ficheroSubida = string.Empty;
        string nombreFicheroSubida = string.Empty;
        string seleccionDescarga = string.Empty;


        manipuladorCliente manipulador = new manipuladorCliente();


        public UI()
        {
            InitializeComponent();
        }
        public string[] GetListaFicheros()
        {
            string[] downloadFiles;

            StringBuilder result = new StringBuilder();
            bool extension = false;
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + url));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(user, pwd);
                if (listarDetalles == true)
                    reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                else
                    reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (true)
                {

                    if (line == null)
                    {
                        break;
                    }
                    if (listarDespegable)
                    {
                        if (line == "." || line == "..")
                        {
                            line = reader.ReadLine();
                            continue;
                        }
                    }


                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        if (line[i] == '.')
                        {
                            extension = true;
                            break;
                        }
                    }

                    if (extension || (!extension && !listarDespegable))
                    {
                        result.Append(line);
                        result.Append("\n");
                        extension = false;
                    }

                    line = reader.ReadLine();

                }

                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                nombreFicheros = result.ToString().Split('\n');
                return nombreFicheros;

            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                Console.WriteLine("Error at GetFileList :>" + ex.Message);
                return downloadFiles;
            }

        }

        private void campoUser_TextChanged(object sender, EventArgs e)
        {
            user = campoUser.Text;
        }

        private void campoPwd_TextChanged(object sender, EventArgs e)
        {
            pwd = campoPwd.Text;
        }

        private void campoURL_TextChanged(object sender, EventArgs e)
        {
            url = campoURL.Text;
        }

        private void botonConectar_Click(object sender, EventArgs e)
        {
            /*
            user = "asfasf392";
            pwd = "w23w4SHYl";
            url = "ftps4.us.freehostia.com";
            */
            listarDetalles = false;

            var conexion = new FtpClient(url, user, pwd);
            try
            {
                using (conexion)
                {
                    conexion.Connect();
                    GetListaFicheros();
                    string delim = "\r\n";
                    string nombreficheros = string.Empty;
                    nombreficheros = nombreFicheros.Aggregate((prev, current) => prev + delim + current);

                    listadoFicheros.Text = nombreficheros;
                    cajaDespegable.Items.Clear();
                    cajaDespegable.Items.AddRange(nombreFicheros);
                }
            }
            catch (Exception ex)
            {
                if (ex is FtpAuthenticationException || ex is SocketException)
                    listadoFicheros.Text = ex.Message;
            }
        }

        private void botonListarContenido_Click(object sender, EventArgs e)
        {
            listarDetalles = true;

            var conexion = new FtpClient(url, user, pwd);
            try
            {
                using (conexion)
                {
                    conexion.Connect();
                    GetListaFicheros();
                    string delim = "\r\n";
                    string nombreficheros = string.Empty;
                    nombreficheros = nombreFicheros.Aggregate((prev, current) => prev + delim + current);

                    listadoFicheros.Text = nombreficheros;
                    listarDetalles = false;
                    GetListaFicheros();
                    cajaDespegable.Items.Clear();
                    cajaDespegable.Items.AddRange(nombreFicheros);
                }
            }
            catch (Exception ex)
            {
                if (ex is FtpAuthenticationException || ex is SocketException)
                    listadoFicheros.Text = ex.Message;
            }
        }

        private void cajaDespegable_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionDescarga = cajaDespegable.SelectedItem.ToString();
        }

        private void cajaDespegable_abrirDespegable(object sender, EventArgs e)
        {
            var conexion = new FtpClient(url, user, pwd);
            try
            {
                using (conexion)
                {
                    conexion.Connect();
                    listarDetalles = false;
                    listarDespegable = true;
                    GetListaFicheros();
                    cajaDespegable.Items.Clear();
                    cajaDespegable.Items.AddRange(nombreFicheros);
                    listarDespegable = false;
                }
            }
            catch (Exception ex)
            {
                if (ex is FtpAuthenticationException || ex is SocketException)
                    listadoFicheros.Text = ex.Message;
            }

        }

        private void botonUbicacionDescarga_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathDescarga = dialog.FileName.ToString();
                ubicacionDescarga.Text = pathDescarga;
            }
        }

        private void botonDescargarFichero_Click(object sender, EventArgs e)
        {

            manipulador.descargaFicheros(user, pwd, url, seleccionDescarga, pathDescarga);

            if (textBoxEmailDescarga.Text != "" && checkBoxConfirmacionDescarga.Checked)
            {
                manipulador.enviarEmailDescarga(textBoxEmailDescarga.Text, seleccionDescarga, url);
                textBoxEmailDescarga.Text = string.Empty;
            }

            ubicacionDescarga.Text = string.Empty;
        }

        private void botonSeleccionarFicheroSubida_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                ficheroSubida = ofd.FileName;

                seleccionSubida = File.ReadAllText(ficheroSubida);
                ubicacionArchivoSubida.Text = ficheroSubida;

            }


        }

        private void botonEnviarFichero_Click(object sender, EventArgs e)
        {
            manipulador.subirFicheros(user, pwd, url, ficheroSubida, nombreFicheroSubida);
            if (textBoxEmailSubida.Text != "" && checkBoxConfirmacionSubida.Checked)
            {
                manipulador.enviarEmailSubida(textBoxEmailSubida.Text, seleccionSubida, url);
                textBoxEmailSubida.Text = string.Empty;

            }

            ubicacionArchivoSubida.Text = string.Empty;
            textBoxNombreFichero.Text = string.Empty;
        }

        private void ubicacionArchivoSubida_TextChanged(object sender, EventArgs e)
        {
            if (ubicacionArchivoSubida.Text.Length > 0)
                botonEnviarFichero.Enabled = true;
            else
                botonEnviarFichero.Enabled = false;
        }

        private void ubicacionDescarga_TextChanged(object sender, EventArgs e)
        {
            if (ubicacionDescarga.Text.Length > 0)
                botonDescargarFichero.Enabled = true;
            else
                botonDescargarFichero.Enabled = false;
        }

        private void checkBoxAsignarNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxNombreFichero.Visible)
                textBoxNombreFichero.Visible = false;
            else
                textBoxNombreFichero.Visible = true;
        }

        private void checkBoxConfirmarSubida_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxEmailSubida.Visible)
                textBoxEmailSubida.Visible = false;
            else
                textBoxEmailSubida.Visible = true;
        }

        private void checkBoxConfirmacionDescarga_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxEmailDescarga.Visible)
                textBoxEmailDescarga.Visible = false;
            else
                textBoxEmailDescarga.Visible = true;
        }

        private void textBoxNombreFichero_TextChanged(object sender, EventArgs e)
        {
            nombreFicheroSubida = textBoxNombreFichero.Text;
        }
    }
}