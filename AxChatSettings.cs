namespace msnld_client
{
    public class AxChatSettings : AxHost
    {
        public AxChatSettings() : base("{FA980E7E-9E44-4d2f-B3C2-9A5BE42525F8}")
        {
            this.SetAboutBoxDelegate(null);
        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the ChatSettings interface to the ActiveX control.
                var ocx = (MSNChat.IChatSettings)this.GetOcx();
                //ocx.BackColor = ToUint(Color.White);
                //ocx.ForeColor = ToUint(Color.White);
                //ocx.RedirectURL = "";
                //ocx.ResDLL = "";
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

/*        private static uint ToUint(Color c)
        {
            return (uint)(((c.A << 24) | (c.R << 16) | (c.G << 8) | c.B) & 0xffffffffL);
        }*/
    }
}
