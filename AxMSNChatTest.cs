namespace msnld_client
{
    public class AxMSNChatTest : AxHost
    {

        public AxMSNChatTest() : base("{F58E1CEF-A068-4c15-BA5E-587CAF3EE8C6}")
        {

        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the IChatFrame interface to the ActiveX control.
                var ocx = (MSNChat.MSNChatFrame)this.GetOcx();
                ocx.ChatMode = 3;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
