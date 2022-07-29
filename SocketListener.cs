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
            Socket? socket;
            try
            {
                // Fake FINDS reply with minimal data.
                socket = sl._socket.EndAccept(ar);
                var payload = Encoding.Latin1.GetBytes($": 613 - :{sl._channelServer}\r\n");
                socket.Send(payload);
                socket.Close();
            }
            catch (Exception e) {
                socket = null;
            }
        }

        public int getPort()
        {
            var ep = _socket.LocalEndPoint;
            if (ep == null)
                return 0;
            return ((IPEndPoint) ep).Port;
        }

        internal void dispose()
        {
            _socket.Close();
            _socket.Dispose();
        }
    }
}
