using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msnld_client
{
    public class RequestedSettings
    {
        public string Server;
        public int Port;
        public bool InternalLookup;
        public string Nickname;
        internal string RoomName;

        public RequestedSettings()
        {
            this.Server = "irc.irc7.com";
            this.Port = 6667;
            this.InternalLookup = false;
            this.Nickname = new Random().Next(0, 9999).ToString("D4");
            this.RoomName = "The Lobby";
            //var x = new MSNChat.MSNChatFrame();
            //x.NickName
        }
    }
}

