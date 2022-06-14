using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

namespace Servidor
{
    public class server
    {
        private static int port = 13000;
        private static IPAddress address = IPAddress.Parse("127.0.0.1");
        //private static Socket sender = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        private static IPEndPoint remoteEP = new IPEndPoint(address, port);

        public static void Main(string[] args)
        {
            Thread.Sleep(1000);
                    Console.WriteLine("-----CLIENTE------");
            Console.WriteLine("Esperando servidor.");
            Socket socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(remoteEP);
            Console.WriteLine("conectado a servidor.");

            byte[] msg = Encoding.ASCII.GetBytes("1");
            socket.Send(msg);
            Console.WriteLine("numero enviado.");


            byte[] recibido=new byte[1176];// = crearByteArray(2048);
            //byte[] key = crearByteArray(32);
            //byte[] iv = crearByteArray(16);
           socket.Receive(recibido);
            //socket.Receive(key);
            //socket.Receive(iv);

            Console.WriteLine("Archivos recibidos");

            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            //Console.WriteLine("Please enter a secret key for the symmetric algorithm.");  
            //var key = Console.ReadLine();  

        
        
            byte[] decryptedByte = DecryptString(key, recibido);
            Console.WriteLine(Encoding.Unicode.GetString(decryptedByte));

            Console.ReadKey();
            /*
            int Rfc2898KeygenIterations = 100;
            int AesKeySizeInBits = 128;
            String Password = "1234";
            byte[] Salt = new byte[16];
            Random rnd = new Random();
            //rnd.NextBytes(Salt);
            byte[] cipherText = new byte[2048];
            socket.Receive(cipherText);
            socket.Receive(Salt);
            string cipher= Encoding.Unicode.GetString(cipherText);
            string salt= Encoding.Unicode.GetString(Salt);
            Console.WriteLine(cipher);
            Console.WriteLine(salt);
            Console.ReadKey();

            
            byte[] plainText = null;
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
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                    }
                    plainText = ms.ToArray();
                }
            }
            string s = Encoding.Unicode.GetString(plainText);
            Console.WriteLine(s);
            Console.ReadKey();
            using (Aes myAes = Aes.Create())
            {

               string desencriptado = DecryptStringFromBytes_Aes(recibido, myAes.Key, myAes.IV);

           
                Console.WriteLine("imagen desencriptada. mostrando");
                Console.WriteLine(desencriptado);

            }
            */


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

        public static byte[] DecryptString(string key, byte[] buffer)
        {
            byte[] iv = new byte[16];

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
                            return Encoding.ASCII.GetBytes(streamReader.ReadLine());
                        }
                    }
                }
            }
        }
        /*
        public static byte[] crearByteArray(int length)
        {
            var arr = new byte[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0x20;
            }
            return arr;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            aesAlg.Padding = PaddingMode.PKCS7;
                                
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        */

    }


}