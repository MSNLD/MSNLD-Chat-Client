﻿namespace msnld_client {

    public class AxMSNChatFrame : AxHost
    {
        private RequestedSettings requestedSettings;

        public AxMSNChatFrame(RequestedSettings requestedSettings) : base("{F58E1CEF-A068-4c15-BA5E-587CAF3EE8C6}")
        {
            this.requestedSettings = requestedSettings;
        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the IChatFrame interface to the ActiveX control.
                var ocx = (MSNChat.MSNChatFrame)this.GetOcx();
                ocx.AuditMessage = "Note: MSN has detected that you are connected to this chat session from the IP address <B>%1</B>.";
                //BackColor
                //BackHighlightColor
                ocx.BaseURL = "http://msnld.com/"; // BaseURL (Required) is the URL that will determine the location of any redirects
                //ButtonBackColor
                //ButtonFrameColor
                //ButtonTextColor
                ocx.Category = "GN";
                ocx.ChannelLanguage = "EN-US"; // Not sure this format is correct.
                //ChatHome = "default.msnw"
                ocx.ChatMode = 1;
                //ocx.ChatMode = 3; // Smiley Face
                //CreateRoom
                ocx.CreationModes = "f";
                ocx.Feature = 2;
                //HexRoomName
                //InputBorderColor
                //InvitationCode
                ocx.Locale = "EN-US";
                ocx.Market = "EN-US";
                ocx.MessageOfTheDay = "Welcome to MSN Chat! MSN does not control or endorse the content, messages or information found in chat. MSN specifically disclaims any liability with regard to these areas. To review the MSN Chat guidelines, go to http://groups.msn.com/conduct NOTICE: To help protect you from spam, MSN Chat is now available by subscription only. Learn more at http://getchat.msn.com";
                ocx.MSNProfile = "";
                ocx.MSNREGCookie = "";
                ocx.NickName = requestedSettings.Nickname; // Nickname
                //NicknameToInvite
                ocx.PassportProfile = "";
                ocx.PassportTicket = "";
                //ResDLL
                ocx.RoomName = requestedSettings.RoomName; // RoomName (Required)
                ocx.Server = $"{requestedSettings.Server}:{requestedSettings.Port}"; // Server (Required), Format: <hostname>[:port]
                ocx.SubscriberInfo = "";
                //TopBackHighlightColor
                ocx.Topic = "";
                //UpsellURL = "subscribe.msnw"
                //URLBack = "default.msnw"
                ocx.UserRole = "";
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
