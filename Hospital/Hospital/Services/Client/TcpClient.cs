using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Hospital.Services.Client
{
    public static class TcpClient
    {
        static int port = 8888;
        static string address = "192.168.11.2";

        public static string GetResponse(string code)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ipPoint);

                // Post message
                string message = code;
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // Get response
                data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                string res = builder.ToString();

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
