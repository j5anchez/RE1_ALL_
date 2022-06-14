/*


The task can return a result. There is no direct mechanism to return the result from a thread.
    
    
*/


using System;
using System.Threading; // Necesario para utilizar thread.sleep
using System.Net.Mail;
using System.Net;
using MailKit.Net;
using MimeKit;

namespace tareas
{
    public class Tareas1
    {
        public static void Main(string[] args)
        {
            EstanteriaRefrescos Refrescos = new EstanteriaRefrescos(50);

            Thread reponedor1 = new Thread(() =>
            {
                while (!Refrescos.almacenlleno)
                {
                    Thread.Sleep(3000);
                    Refrescos.RetirarProducto(20, "Naranja");
                    //Console.WriteLine("reponedor 1");


                }
            });

            Thread reponedor2 = new Thread(() =>
            {
                while (!Refrescos.almacenlleno)
                {
                    Thread.Sleep(2000);
                    Refrescos.RetirarProducto(1, "cola");
                    //Console.WriteLine("reponedor 2");

                }
            });

            Thread reponedor3 = new Thread(() =>
            {
                while (!Refrescos.almacenlleno)
                {
                    Thread.Sleep(1000);
                    Refrescos.RetirarProducto(12, "Limon");
                    // Console.WriteLine("reponedor 3");

                }
            });

            reponedor1.Start();
            reponedor2.Start();
            reponedor3.Start();
        }

        class EstanteriaRefrescos
        {
            double Stock { get; set; } // campo de clase para poder acceder a sus valores.
            private Object bloqueaAlmacen = new Object(); //Objeto creado y necesario para el bloqueo
            public bool almacenlleno = false;
            public EstanteriaRefrescos(double Stock) //Creamos el constructor de la clase en la que se establece un stock del almacén.
            {
                this.Stock = Stock;
            }

            public double RetirarProducto(double cantidad, string sabor) // método con el que el fendwich retirará el producto
            {
                Tareas1 tareas1 = new Tareas1();

                if (Stock - cantidad > 0)
                {
                    lock (bloqueaAlmacen)
                    {
                        Stock -= cantidad;

                        Console.WriteLine("se han sacado {0} de sabor {1}\nstock:{2}", cantidad, sabor, Stock);
                        tareas1.SendMail("t0k3r0@gmail.com", "aviso urgente, falta" + sabor, Task.CurrentId.ToString());
                        return Stock;
                    }
                }

                else if (Stock - cantidad < 0)
                {
                    lock (bloqueaAlmacen)
                    {
                        Console.WriteLine("No se puede retirar {0} de sabor {1}\n stock:{2}", cantidad, sabor, Stock);

                        return Stock;
                    }
                }
                else
                    lock (bloqueaAlmacen)
                    {
                        {
                            Console.WriteLine("el almacen se ha quedado sin productos\nstock{0}", Stock);
                            almacenlleno = true;
                            tareas1.SendMail("t0k3r0@gmail.com", "almacen sin refrescos" + sabor, "ningun reponedor");
                            Console.ReadKey();
                            return Stock;
                        }
                    }
            }

        }

        public async void SendMail(string toEmail, string mensaje, string reponedor)
        {
            /*
            //PRIMER METODO ENVIO CORREO
             
            try
             {
                 MailMessage msg = new MailMessage("phernandoamezketarra@gmail.com", toEmail, mensaje, reponedor);
                 //Attachment data = new Attachment(@"..\..\privatekeys\" + usuario + "_private.xml", MediaTypeNames.Application.Octet);
                 // msg.Attachments.Add(data);
                 SmtpClient smtp = new SmtpClient
                 {
                     Host = "smtp.gmail.com",
                     Port = 587,
                     Credentials = new NetworkCredential("phernandoamezketarra@gmail.com", "ytkeleiqbxdcbjry"),
                     EnableSsl = true,


                 };


                 smtp.Send(msg);

             }
             catch (Exception ex)
             {
                 Console.WriteLine("No se ha podido mandar el correo."); Console.WriteLine(ex.ToString());
             }
            */




            /*
            //SEGUNDO METODO ENVIO CORREO
            
            MailAddress origen = new MailAddress("phernandoamezketarra@gmail.com", "Pepito Piscinas Coop.");

            MailAddress destino = new MailAddress(toEmail, "");

            SmtpClient smtp = new SmtpClient
            {
             Host = "smtp.gmail.com",
             Port = 587,
             Credentials = new NetworkCredential(origen.Address, "ytkeleiqbxdcbjry"),
             EnableSsl = true
            };




            using (MailMessage msg = new MailMessage(origen, destino)
            {
             Subject = mensaje,
             Body = reponedor,
            })

             try
             {
                 smtp.Send(msg);

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.ToString());
             }
            */





            /*
            //TERCER METODO ENVIO EMAIL CON MAILKIT

       var message = new MimeMessage();
message.From.Add(new MailboxAddress("Sender Name", "sender@yourdomain.com"));
message.To.Add(new MailboxAddress("Recipient Name", "recipient@theirdomain.com"));
message.Subject = "MailKit Test";
message.Body    = new TextPart("plain") { Text = "Hi from MailKit!" };
 
using (var client = new SmtpClient())
{
    client.Connect("mail.yoursmtpservice.com", 587);
    client.Authenticate("your_username", "your_password");
    client.Send(message);
    client.Disconnect(true);
}
            */
        }

    }
}


/*      static Object obj = new Object();

public static void Main()
{
ThreadPool.QueueUserWorkItem(ShowThreadInformation);
var th1 = new Thread(ShowThreadInformation);
th1.Start();
var th2 = new Thread(ShowThreadInformation);
th2.IsBackground = true;
th2.Start();
Thread.Sleep(5000);
ShowThreadInformation(null);
Console.ReadKey();
}

private static void ShowThreadInformation(Object state)
{
lock (obj)
{
var th = Thread.CurrentThread;
Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
Console.WriteLine("   Background thread: {0}", th.IsBackground);
Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
Console.WriteLine("   Priority: {0}", th.Priority);
Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
Console.WriteLine();
}
}
}
}
// The example displays output like the following:
//       Managed thread #6:
//          Background thread: True
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//       
//       Managed thread #3:
//          Background thread: True
//          Thread pool thread: True
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//       
//       Managed thread #4:
//          Background thread: False
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US
//       
//       Managed thread #1:
//          Background thread: False
//          Thread pool thread: False
//          Priority: Normal
//          Culture: en-US
//          UI culture: en-US





internal sealed class Foo
{
private Object bar = null;

private void CreateBarOnNewThread()
{
var thread = new Thread(this.CreateBar);

thread.Start();

// Do other stuff while the new thread
// creates our bar.
Console.WriteLine("Doing crazy stuff.");

// Wait for the other thread to finish.
thread.Join();

// Use this.bar here...
}

private void CreateBar()
{
// Creating a bar takes a long time.
Thread.Sleep(1000);

this.bar = new Object();
}
}*/

