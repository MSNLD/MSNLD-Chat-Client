using MSNChat;
using System.Windows.Forms;

namespace MSNLD_Chat_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var x = new ChatFrame((MSNChatFrame MSNChatFrame) =>
            {
                MSNChatFrame.BaseURL = "http://msnld.com/"; // Without this, STATUS_FATAL_USER_CALLBACK_EXCEPTION is
                                                            // thrown when a Whisper Window is opened.
                MSNChatFrame.NickName = "JD";
                MSNChatFrame.RoomName = "The Lobby";
                MSNChatFrame.Server = "dir.irc7.com";
                //MSNChatFrame.TopBackHighlightColor = 0;
            });
            x.Dock = DockStyle.Fill;
            Controls.Add(x);
        }
    }
}