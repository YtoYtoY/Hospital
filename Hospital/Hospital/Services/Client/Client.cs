using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Hospital.Services.Client
{
    public class Client
    {
        public static StringBuilder GetResponse(string code)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect("192.168.207.2", 8008);

                Stream stream = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] output = asen.GetBytes(code + ".html");

                stream.Write(output, 0, output.Length);

                byte[] input = new byte[4096];
                int k = stream.Read(input, 0, 4096);

                StringBuilder result = new StringBuilder();
                string tmpres = "";
                for (int i = 0; i < k; i++)
                    tmpres += Convert.ToChar(input[i]);

                result.Append(tmpres);
                tcpclnt.Close();
                return result;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
