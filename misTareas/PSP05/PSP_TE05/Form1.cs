using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections.Generic;
//***************************************************************************************
// VIDEO DE AUTOEVALUACION EN YOUTUBE
// https://www.youtube.com/watch?v=VYZ5yCgpW04
//***************************************************************************************
namespace comparadorFicheros
{
public partial class Form1 : Form
{
    private byte[] bytextoCifrado = new byte[2048 * 2];
    private string pathPublicKey = "..\\..\\publickeys\\";
    private string pathPrivateKey = "..\\..\\privatekeys\\";
    private string pathBBDD = "..\\..\\bbdd\\";
    List<string> Passwords = new List<string>();
    public Form1()
    {
        InitializeComponent();
    }
    private void generarClaves(string pathPublicKey, string pathPrivateKey)
    {
        try
        {
            using (var rsa = new RSACryptoServiceProvider(2048 * 2))
            {
                rsa.PersistKeyInCsp = false;
                if (File.Exists(pathPublicKey))
                    File.Delete(pathPublicKey);
                if (File.Exists(pathPrivateKey))
                    File.Delete(pathPrivateKey);
                string publicKey = rsa.ToXmlString(false);
                File.WriteAllText(pathPublicKey, publicKey);
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(pathPrivateKey, privateKey);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se han podido generar las claves.");
            Console.WriteLine(ex.ToString());
        }
    }
    public static byte[] encriptar(string publicKF, byte[] textoPlano)
    {
        try
        {
            byte[] encriptado;
            using (var rsa = new RSACryptoServiceProvider(2048 * 2))
            {
                rsa.PersistKeyInCsp = false;
                string publicKey = File.ReadAllText(publicKF);
                rsa.FromXmlString(publicKey);
                encriptado = rsa.Encrypt(textoPlano, true);
            }
            return encriptado;
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido encriptar.");
            Console.WriteLine(ex.ToString());
            return Encoding.UTF8.GetBytes(ex.ToString());
        }
    }
    public static byte[] Desencriptar(string privateKF, byte[] textoEncriptado)
    {
        try
        {
            byte[] desencriptado;
            using (var rsa = new RSACryptoServiceProvider(2048 * 2))
            {
                rsa.PersistKeyInCsp = false;
                string privateKey = File.ReadAllText(privateKF);
                rsa.FromXmlString(privateKey);
                desencriptado = rsa.Decrypt(textoEncriptado, true);
            }
            return (desencriptado);
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se ha podido desencriptar.");
            Console.WriteLine(ex.ToString());
            return Encoding.UTF8.GetBytes(ex.ToString());
        }
    }
    private void boton_Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (tb_RegistrarDescripcion.Text.Length > 0 && tb_RegistrarPassword.Text.Length > 0)
            {
                char c;
                bool mayus = false;
                bool minus = false;
                bool numero = false;
                bool longitud = false;
                bool caracter = false;
                string caracteres = "!@#&()–[{}:',?/*~$^+=<>";
                if (tb_RegistrarPassword.Text.Length > 7 && tb_RegistrarPassword.Text.Length < 21)
                {
                    longitud = true;
                    for (int i = 0; i < tb_RegistrarPassword.Text.Length; ++i)
                    {
                        c = tb_RegistrarPassword.Text[i];
                        if (c >= 'A' && c <= 'Z')
                        {
                            mayus = true;
                        }
                        else if (c >= 'a' && c <= 'z')
                        {
                            minus = true;
                        }
                        else if (c >= '0' && c <= '9')
                        {
                            numero = true;
                        }
                        else if (caracteres.Contains(c.ToString()))
                        {
                            caracter = true;
                        }
                    }
                }
                if (!longitud || !mayus || !minus || !numero || !caracter)
                {
                    MessageBox.Show(
                        "La contraseña al menos tiene que contener\n1 mayúscula\n1 minúscula\n1 número\n8-10 caracteres de longitud\n1 caracter: !@#&()–[{}:',?/*~$^+=<>");
                }
                else
                {
                    byte[] textoAnteriorBytes = File.ReadAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt");
                    byte[] textoAnteriorBytesDesencriptado =
                        Desencriptar(pathPrivateKey + tb_UsuarioRegistrado.Text + "_private.xml", textoAnteriorBytes);
                    string textoPlanoString = tb_RegistrarDescripcion.Text + "." + tb_RegistrarPassword.Text + ";";
                    byte[] textoPlanoByte = Encoding.UTF8.GetBytes(textoPlanoString);
                    byte[] textoCombinado = Combine(textoAnteriorBytesDesencriptado, textoPlanoByte);
                    byte[] textoCombinadoEncriptado =
                        encriptar(pathPublicKey + tb_UsuarioRegistrado.Text + "_public.xml", textoCombinado);
                    File.WriteAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt", textoCombinadoEncriptado);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Contraseña no guardada.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void check_VisualizarPass_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (check_VisualizarPass.Checked)
            {
                gb_Visualizar.Enabled = true;
                cb_VisualizarDescripcion.Items.Clear();
                cb_VisualizarDescripcion.Text = "";
                byte[] textoDescifrar = File.ReadAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt");
                byte[] desencriptado =
                    Desencriptar(pathPrivateKey + tb_UsuarioRegistrado.Text + "_private.xml", textoDescifrar);
                string textoCompleto = Encoding.UTF8.GetString(desencriptado);
                string programa = string.Empty;
                string password = string.Empty;
                bool psw = false;
                for (int i = 0; i < textoCompleto.Length; ++i)
                {
                    if (textoCompleto[i] == '.')
                    {
                        psw = true;
                        cb_VisualizarDescripcion.Items.Add(programa);
                        programa = string.Empty;
                        continue;
                    }
                    else if (textoCompleto[i] == ';')
                    {
                        psw = false;
                        Passwords.Add(password);
                        password = string.Empty;
                        continue;
                    }
                    if (!psw)
                        programa += textoCompleto[i];
                    else
                        password += textoCompleto[i];
                }
            }
            else
            {
                gb_Visualizar.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void check_RegistrarPass_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (check_RegistrarPass.Checked)
            {
                gb_Registrar.Enabled = true;
            }
            else
            {
                gb_Registrar.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void check_BorrarPass_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (check_BorrarPass.Checked)
            {
                gb_Borrar.Enabled = true;
                cb_BorrarDescripcion.Items.Clear();
                cb_BorrarDescripcion.Text = "";
                byte[] textoDescifrar = File.ReadAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt");
                byte[] desencriptado =
                    Desencriptar(pathPrivateKey + tb_UsuarioRegistrado.Text + "_private.xml", textoDescifrar);
                string textoCompleto = Encoding.UTF8.GetString(desencriptado);
                string programa = string.Empty;
                string password = string.Empty;
                bool psw = false;
                for (int i = 0; i < textoCompleto.Length; ++i)
                {
                    if (textoCompleto[i] == '.')
                    {
                        psw = true;
                        cb_BorrarDescripcion.Items.Add(programa);
                        programa = string.Empty;
                        continue;
                    }
                    else if (textoCompleto[i] == ';')
                    {
                        psw = false;
                        Passwords.Add(password);
                        password = string.Empty;
                        continue;
                    }
                    if (!psw)
                        programa += textoCompleto[i];
                    else
                        password += textoCompleto[i];
                }
            }
            else
            {
                gb_Borrar.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void boton_RegistrarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            string nombreUsuario = tb_UsuarioRegistrado.Text;
            string curFile = @"..\..\bbdd\" + nombreUsuario + ".txt";
            if (File.Exists(curFile))
            {
                check_BorrarPass.Enabled = true;
                check_RegistrarPass.Enabled = true;
                check_VisualizarPass.Enabled = true;
            }
            else
            {
                MessageBox.Show("El usuario no existe, debes registrarlo.");
                gb_RegistroUsuario.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void boton_RegistroAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            bool emailCorrecto = false;
            char c;
            bool arroba = false;
            for (int i = 0; i < tb_Email.Text.Length; ++i)
            {
                if (i == tb_Email.Text.Length - 1 && arroba == true)
                    emailCorrecto = true;
                c = tb_Email.Text[i];
                if ((c > 44 && c < 58) || (c > 64 && c < 91) || (c > 96 && c < 123))
                    continue;
                else if (c == '@' && arroba == false)
                    arroba = true;
                else
                    break;
            }
            if (radio_RegistrarYes.Checked && emailCorrecto)
            {
                generarClaves(pathPublicKey + tb_UsuarioRegistrado.Text + "_public.xml",
                              pathPrivateKey + tb_UsuarioRegistrado.Text + "_private.xml");
                bytextoCifrado =
                    encriptar(pathPublicKey + tb_UsuarioRegistrado.Text + "_public.xml", Encoding.UTF8.GetBytes(""));
                File.WriteAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt", bytextoCifrado);
                gb_RegistroUsuario.Enabled = false;
                int tiempo = 0;
                while (!File.Exists(@"..\..\privatekeys\" + tb_UsuarioRegistrado.Text + "_private.xml"))
                {
                    Thread.Sleep(200);
                    tiempo++;
                    if (tiempo > 1500)
                    {
                        MessageBox.Show("Tiempo excesivo esperando a la creación del archivo, inténtalo otra vez");
                        return;
                    }
                }
                Correos.envioCorreos enviarCorreo = new Correos.envioCorreos();
                enviarCorreo.envioEmail(tb_UsuarioRegistrado.Text.ToString(), tb_Email.Text.ToString());
                MessageBox.Show("Registro Creado, puedes encontrar tu fichero en ..\\..\\privatekeys\\" +
                                tb_UsuarioRegistrado.Text + "_private.xml");
                    Application.Restart(); //Para que deje de utilizar el fichero y poder abrirlo otra vez

                }
            }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    public static byte[] Combine(byte[] first, byte[] second)
    {
        try
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
            return Encoding.UTF8.GetBytes(ex.ToString());
        }
    }
    private void boton_Fichero_Click(object sender, EventArgs e)
    {
        try
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label_UbicacionFichero.Text = openFileDialog.FileName.ToString();
                    comparadorFicheros cf = new comparadorFicheros();
                    if (cf.FileCompare(pathPrivateKey + tb_UsuarioRegistrado.Text + "_private.xml",
                                       openFileDialog.FileName) &&
                        cb_VisualizarDescripcion.SelectedIndex >= 0)
                    {
                        tb_VisualizarPassword.Text = Passwords[cb_VisualizarDescripcion.SelectedIndex];
                    }
                    else
                    {
                        MessageBox.Show("Archivo de claves incorrecto.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void cb_VisualizarDescripcion_DropDown(object sender, EventArgs e)
    {
        check_VisualizarPass_CheckedChanged(sender, e);
    }
    private void cb_BorrarDescripcion_DropDown(object sender, EventArgs e)
    {
        check_BorrarPass_CheckedChanged(sender, e);
    }
    private void boton_Borrar_Click(object sender, EventArgs e)
    {
        try
        {
            byte[] textoDescifrar = File.ReadAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt");
            byte[] desencriptado =
                Desencriptar(pathPrivateKey + tb_UsuarioRegistrado.Text + "_private.xml", textoDescifrar);
            string textoCompleto = Encoding.UTF8.GetString(desencriptado);
            int contador = 0;
            int seleccionado = cb_BorrarDescripcion.SelectedIndex;
            for (int i = 0; i < textoCompleto.Length; ++i)
            {
                if (contador == seleccionado)
                {
                    while (textoCompleto[i] != ';')
                    {
                        textoCompleto = textoCompleto.Remove(i, 1);
                        continue;
                    }
                    textoCompleto = textoCompleto.Remove(i, 1);
                    contador++;
                    if (contador > seleccionado || i > textoCompleto.Length)
                        break;
                }
                if (textoCompleto[i] == ';')
                {
                    contador++;
                    continue;
                }
            }
            byte[] textoCompletoByte = Encoding.UTF8.GetBytes(textoCompleto);
            byte[] textoCompletoEncriptado =
                encriptar(pathPublicKey + tb_UsuarioRegistrado.Text + "_public.xml", textoCompletoByte);
            File.WriteAllBytes(pathBBDD + tb_UsuarioRegistrado.Text + ".txt", textoCompletoEncriptado);
            cb_BorrarDescripcion.Text = string.Empty;
            cb_VisualizarDescripcion.Text = string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha habido un error.");
            Console.WriteLine(ex.ToString());
        }
    }
    private void boton_GuardaryCerrar_Click(object sender, EventArgs e)
    {
        Environment.Exit(0); // No falta nada por guardar, todo se va guardando según se ejecuta.
    }
}
}
