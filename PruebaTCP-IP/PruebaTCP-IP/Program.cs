using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTCP_IP
{
    class Program
    {
        #region Variables e Instancias Globales
        static int _PortN = 21;
        static string _Server = "hola";
        static TcpListener _Listener = new TcpListener(IPAddress.Any, _PortN);
        static TcpClient _Client = _Listener.AcceptTcpClient();
        static NetworkStream _NS = _Client.GetStream();
        static byte[] _buffer = new byte[1024];
        TcpClient tcpClient = new TcpClient(_Server, _PortN);
        #endregion
        static void Main(string[] args)
        {
            //int PortN = 21;
            //TcpListener Listener = new TcpListener(IPAddress.Any, PortN);
            //TcpClient Client = Listener.AcceptTcpClient();
            //NetworkStream NS = Client.GetStream();
            //byte[] buffer = new byte[1024];

            _Listener.Start();
            SendMessageReturntoSocketClient();
            Console.ReadKey();
        }
        private static void AccionesServer()
        {
            //_Listener.Start();

        }
        private static void SendMessageReturntoSocketClient()
        {
            byte[] nouBuffer = Encoding.ASCII.GetBytes("Hola s2AM!!");
            _NS.Write(nouBuffer, 0, nouBuffer.Length);
        }
        private static void PararTodo()
        {
            _NS.Close();
            _Client.Close();
            _Listener.Stop();
        }
    }
}
