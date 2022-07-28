namespace msnld_client
{
    public class AxChatSettings : AxHost
    {
        Form parentFrm;
        public AxChatSettings(Form parentFrm) : base("{FA980E7E-9E44-4d2f-B3C2-9A5BE42525F8}")
        {
            this.parentFrm = parentFrm;
        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the ChatSettings interface to the ActiveX control.
                var ocx = (MSNChat.ChatSettings)this.GetOcx();
                // Background Color
                ocx.BackColor = AxHost.GetOleColorFromColor(this.parentFrm.BackColor);
                // Section Titles
                ocx.ForeColor = AxHost.GetOleColorFromColor(this.parentFrm.ForeColor);
                //ocx.RedirectURL = "";
                //ocx.ResDLL = "";
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
