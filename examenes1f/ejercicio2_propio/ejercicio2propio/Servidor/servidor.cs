using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

namespace Servidor
{
    public class server
    {


        public static void Main(string[] args)
        {
            Console.WriteLine("-----SERVIDOR------");
            int port = 13000;
            IPAddress address = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(address, port);
            string imagen = string.Empty;
            int byteCount;
            listener.Start();
            TcpClient cliente = listener.AcceptTcpClient();

            using (cliente)
            {
                using (NetworkStream networkStream = cliente.GetStream())
                {
                    Console.WriteLine("Conexion con cliente establecida.");
                    byte[] buffer = new byte[1176];
                    byteCount = networkStream.Read(buffer, 0, buffer.Length);
                    string request = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    Console.WriteLine("Peticion recibida, procesando imagen");
                    int numero = Convert.ToInt32(request);
                    char asterisco = '*';
                    for (int i = 0; i < numero; i++)
                    {
                        for (int j = 0; j < numero; j++)
                        {
                            imagen += asterisco;
                        }
                        imagen += '\n';
                    }
                    var key = "b14ca5898a4e4133bbce2ea2315a1916";

                    //Console.WriteLine("Please enter a secret key for the symmetric algorithm.");  
                    //var key = Console.ReadLine();  

                    byte[] encryptedString = Encoding.UTF8.GetBytes(EncryptString(key, imagen));
                    networkStream.Write(encryptedString, 0, encryptedString.Length);
                    Console.ReadKey();

                    /*
                    int Rfc2898KeygenIterations = 100;
                    int AesKeySizeInBits = 128;
                    String Password = "1234";
                    byte[] Salt = new byte[16];
                    Random rnd = new Random();
                    rnd.NextBytes(Salt);
                    byte[] rawPlaintext = Encoding.Unicode.GetBytes(imagen);
                    byte[] cipherText = new byte[2048];

                    using (Aes aes = new AesManaged())
                    {
                        aes.Padding = PaddingMode.PKCS7;
                        aes.KeySize = AesKeySizeInBits;
                        int KeyStrengthInBytes = aes.KeySize / 8;
                        Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
                        aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
                        aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(rawPlaintext, 0, rawPlaintext.Length);
                            }
                            cipherText = ms.ToArray();
                        }

                       
                    }
               




                    
                    using (Aes myAes = Aes.Create())
                    {

                        // Encrypt the string to an array of bytes.
                        byte[] encrypted = EncryptStringToBytes_Aes(imagen, myAes.Key, myAes.IV);
                        byte[] key = new byte[32];
                        key=myAes.Key;
                        byte[] iv = new byte[16];
                        iv=myAes.IV;
                        myAes.Padding = PaddingMode.PKCS7;
                       // string strencrypted= Encoding.ASCII.GetString(encrypted);
                        //string strkey= Encoding.ASCII.GetString(key);
                        //string striv= Encoding.ASCII.GetString(iv);
                        networkStream.Write(encrypted, 0, encrypted.Length);
                        networkStream.Write(key, 0, key.Length);
                        networkStream.Write(iv, 0, iv.Length);
                        // networkStream.Write(myAes.Key, 0, myAes.Key.Length);
                        Console.WriteLine("imagen encriptada y clave enviados");

                    }*/
                }

            }
            listener.Stop();
            Console.ReadKey();
        }
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        /*
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }*/


    }
}