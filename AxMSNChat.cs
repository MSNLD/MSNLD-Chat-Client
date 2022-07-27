using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace msnld_client
{
    public class AxMSNChat : AxHost
    {
        private MSNChat.IChatFrame ocx;
        private string _hostname;
        private int _port;
        private string _channel;

        public AxMSNChat(string hostname, int port, string channel) : base("{F58E1CEF-A068-4c15-BA5E-587CAF3EE8C6}")
        {
            _hostname = hostname;
            _port = port;
            _channel = channel;
            this.SetAboutBoxDelegate(null);
        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the IChatFrame interface to the ActiveX control.
                this.ocx = ((MSNChat.IChatFrame)(this.GetOcx()));
                ocx.AuditMessage = "Note: MSN has detected that you are connected to this chat session from the IP address <B>%1</B>.";
                ocx.BaseURL = "http://msnld.com/"; // BaseURL (Required) is the URL that will determine the location of any redirects
                ocx.Category = "GN";
                ocx.ChannelLanguage = "EN-US"; // Not sure this format is correct.
                //ocx.Create = "1";
                ocx.ChatMode = 1;
                //ocx.ChatMode = 3; // Smiley Face
                ocx.CreationModes = "f";
                ocx.Feature = 2;
                ocx.Locale = "EN-US";
                ocx.Market = "EN-US";
                ocx.MessageOfTheDay = "Welcome to MSN Chat! MSN does not control or endorse the content, messages or information found in chat. MSN specifically disclaims any liability with regard to these areas. To review the MSN Chat guidelines, go to http://groups.msn.com/conduct NOTICE: To help protect you from spam, MSN Chat is now available by subscription only. Learn more at http://getchat.msn.com";
                ocx.MSNProfile = "";
                //ocx.MSNRegCookie = "";
                ocx.NickName = "JD"; // Nickname
                ocx.PassportProfile = "";
                ocx.PassportTicket = "";
                ocx.RoomName = _channel; // RoomName (Required)
                ocx.Server = $"{_hostname}:{_port}"; // Server (Required), Format: <hostname>[:port]
                ocx.SubscriberInfo = "";
                ocx.Topic = "";
                ocx.WelcomeMsg = "";
                ocx.WhisperContent = "http://g.msn.com/5chenus/31";
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }

}
