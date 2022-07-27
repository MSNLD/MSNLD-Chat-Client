using System.Net;
using System.Net.Sockets;
using System.Text;

namespace msnld_client
{
    internal class SocketListener
    {
        private Socket _socket;
        private string _channelServer;

        public SocketListener(string channelServer)
        {
            _channelServer = channelServer;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            _socket.Bind(ep);
            _socket.Listen();

            _socket.BeginAccept(new AsyncCallback(SocketListener.AcceptCallback), this);
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            var sl = (SocketListener)ar.AsyncState!;
            var socket = sl._socket;
            var connection = socket.EndAccept(ar);
            socket.Close(); // Close listening socket
            // Fake FINDS reply with minimal data.
            var payload = Encoding.Latin1.GetBytes($": 613 - :{sl._channelServer}\r\n");
            connection.Send(payload);
            connection.Close();
        }

        public int getPort()
        {
            var ep = _socket.LocalEndPoint;
            if (ep == null) return 0;
            return ((IPEndPoint) ep).Port;
        }
    }
}
