using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        public static void Main()
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("192.168.207.2");
                TcpListener myList = new TcpListener(ipAd, 8008);

                myList.Start();

                Console.WriteLine("The server is running at port 8888...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                while (true)
                {
                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                    byte[] b = new byte[100];
                    int k = s.Receive(b);
                    Console.WriteLine("Recieved...");

                    string file = "";
                    string html = "";
                    for (int i = 0; i < k; i++)
                        file += Convert.ToChar(b[i]);
                    Console.WriteLine(file);

                    ASCIIEncoding asen = new ASCIIEncoding();
                    if (file == "#123456.html")
                    {
                        using (StreamReader sr = new StreamReader(@"E:\Work\Startup\Hospital\Server\" + file))
                        {
                            html = sr.ReadToEnd();
                        }
                        s.Send(asen.GetBytes("true:" + html));
                    }
                    else
                    {
                        s.Send(asen.GetBytes("null"));
                    }
                    s.Close();
                }
                myList.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}
