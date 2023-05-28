using MSNChat;

namespace MSNLD_Chat_Client
{
    internal class ChatFrame : AxHost
    {
        private Action<MSNChatFrame> Callback;

        /// <summary>
        ///  Creates a new instance of a control which wraps the MSN Chat Control.
        ///  Callback receives the MSNChatFrame object and is called when the control is ready to be used.
        /// </summary>
        public ChatFrame(Action<MSNChatFrame> callback) : base("F58E1CEF-A068-4c15-BA5E-587CAF3EE8C6", 0)
        {
            Callback = callback;
        }

        /// <summary>
        ///  AxHost will call this when it is ready to create the underlying ActiveX object.
        ///  getOcx() should not usually be called before this function.
        ///  Note: calling begin will result in a call to this function.
        /// </summary>
        protected override void AttachInterfaces()
        {
            base.AttachInterfaces();
            var MSNChatFrame = (MSNChatFrame)this.GetOcx();
            Callback(MSNChatFrame);
        }

        /// <summary>
        ///  This is the default size of the control.
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(426, 288); // Minimum size for the control.
            }
        }
    }
}