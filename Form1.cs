using MSNChat;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MSNLD_Chat_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ChatFrame? chatFrame = null;
            chatFrame = new ChatFrame((MSNChatFrame MSNChatFrame) =>
            {
                // Shows a line of text after the MOTD. The first occurance of "%1" is replaced with the bound IP
                // address of the user. TODO: We need to modify this to support IPv6 addresses.
                MSNChatFrame.AuditMessage = "Note: MSN has detected that you are connected to this chat session from the IP address <B>%1</B>.";
                // TODO: Setting the BackColor causes a runtime error, we might need to use the 'new' keyword.
                //MSNChatFrame.BackColor = (uint)ColorTranslator.ToOle(Color.Black);
                // Set the background color above and below the nicklist, as well as the background color for most
                // of the elements found in the whisper window.
                // This also is the background color for the icons in the nicklist (bug?) TODO: Can we fix it?
                //MSNChatFrame.BackHighlightColor = (uint)ColorTranslator.ToOle(Color.Blue);
                // If unset, STATUS_FATAL_USER_CALLBACK_EXCEPTION is thrown when a whisper window is opened.
                // TODO: Can we catch this? or set a default?
                MSNChatFrame.BaseURL = "http://msnld.com/";
                // This sets the background color of the "send", "act" and "away" buttons on the main chat window, as
                // well as the background color of the "whisper", "view prile" and "ignore" buttons in the whisper
                // window.
                //MSNChatFrame.ButtonBackColor = (uint)ColorTranslator.ToOle(Color.Red);
                // This sets the color of the border around the chat input area.
                //MSNChatFrame.ButtonFrameColor = (uint)ColorTranslator.ToOle(Color.Red);
                // This sets the color of the text on the "send" and "act" buttons on the main chat window. It also sets
                // the color of the text on the "whisper" and "view profile" buttons in the whisper window.
                //MSNChatFrame.ButtonTextColor = (uint)ColorTranslator.ToOle(Color.Green);
                // Default category, used in CREATE - Default: "UL" (unlisted)
                MSNChatFrame.Category = "GN";
                // Default language, used in CREATE (I think?) TODO: Verify
                MSNChatFrame.ChannelLanguage = "1";
                // This sets the homepage of the chat website.
                MSNChatFrame.ChatHome = "messenger.msnw";
                // Sets the mode of the Chat Control. Defaults to 0.
                //  0: Join - Joins an existing chatroom.
                //  1: Create - Creates a new chatroom, and joins it.
                //  2: Join? - Join a room, and create it if it does not already exist
                //  3: Smiley - Used for testing if the OCX is installed.
                //  5: Invite - Creates a channel, and invites the user set in NicknameToInvite to that channel.
                //  6: FINDU - Finds a user, and attempts to join the channel they are in.
                MSNChatFrame.ChatMode = 0;
                // Sets the location where channels can be created.
                MSNChatFrame.CreateRoom = "create.msnw?fMsgr=true&";
                // This sets the modes of the channel attempting to be createed, Valid modes are adefghimnprstuwWxS.
                MSNChatFrame.CreationModes = "f";
                // Feature is a bitmapped value
                //  To disable the Whisper Window, add 1
                //  To hide the Guest_ on nicknames, add 2
                //  To disable the View Profiles option, add 4
                //  To hide the Room Name, add 8
                // TODO: Any others?
                MSNChatFrame.Feature = 0;
                // This overrides RoomName, and sets the name of the room to join (in hex).
                // When set, if the HexRoomName is not prefixed with "2523" (ASCII "%#"), it will be automatically
                // prepended.
                MSNChatFrame.HexRoomName = "";
                // This sets the color of the area surrounding the chat input area, including the "send", "act", and
                // "whisper" buttons.
                //MSNChatFrame.InputBorderColor = (uint)ColorTranslator.ToOle(Color.Orange);
                MSNChatFrame.InvitationCode = "";
                // Sent as part of the CREATE command
                MSNChatFrame.Locale = "en-au";
                // Sent in the IRCVERS command to the channel server
                MSNChatFrame.Market = "en-us";
                // Sets the MOTD that is displayed in the client once connected.
                MSNChatFrame.MessageOfTheDay = "Welcome to MSN Chat! MSN does not control or endorse the content, mes" +
                  "sages or information found in chat. MSN specifically disclaims any liability with regard to these " +
                  "areas. To review the MSN Chat guidelines, go to http://groups.msn.com/conduct NOTICE: To help prot" +
                  "ect you from spam, MSN Chat is now available by subscription only. Learn more at http://getchat.ms" +
                  "n.com";
                // Sends "PROP $ MSNPROFILE :{value}\r\n" after receiving raw 001 on channel server.
                MSNChatFrame.MSNProfile = "0";
                // Sends "PROP $ COOKIE :{value}\r\n" instead of the NICK command after successful GateKeeperPassport
                // authentication on the channel server. If unset, and PassportTicket and PassportProfile are both set,
                // the MSN Chat Control will not connect.
                MSNChatFrame.MSNREGCookie = "";
                MSNChatFrame.NickName = "JD";
                MSNChatFrame.NicknameToInvite = "";
                MSNChatFrame.PassportProfile = "";
                MSNChatFrame.PassportTicket = "";
                MSNChatFrame.ResDLL = "http://localhost:9080/test";
                // Sets the plain text version of the channel name
                MSNChatFrame.RoomName = "The Lobby";
                // Sets the server hostname/IPv4 address and optionally, the port. Format: hostname[:port].
                MSNChatFrame.Server = "dir.irc7.com";
                MSNChatFrame.SubscriberInfo = "";
                // Sets the color of the background in the area above the nicklist.
                //MSNChatFrame.TopBackHighlightColor = (uint)ColorTranslator.ToOle(Color.Purple);
                MSNChatFrame.Topic = "Welcome to the Lobby!";
                MSNChatFrame.UpsellURL = "subscribe.msnw";
                MSNChatFrame.URLBack = "messenger.msnw";
                MSNChatFrame.UserRole = "";
                MSNChatFrame.WelcomeMsg = "Welcome to the Lobby!";
                MSNChatFrame.WhisperContent = "http://g.msn.com/5chenus/31"; // Displays an iframe like object on the 
                                                                             // left side of the whisper window.
            });
            chatFrame.Dock = DockStyle.Fill;
            Controls.Add(chatFrame);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Known .NET bug. If we don't hide(), the Window menu will try and get the icon after the form is disposed.
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}