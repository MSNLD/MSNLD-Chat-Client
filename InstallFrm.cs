using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace msnld_client
{
    public partial class InstallFrm : Form
    {
        public AxMSNChat _ocx;
        public InstallFrm()
        {

        }

        private void InstallFrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var state = _ocx.OcxState;
            //((MSNChat.IChatFrame)_ocx).ChatMode = 3;
            //_ocx.OcxState = state;
        }
    }
}
