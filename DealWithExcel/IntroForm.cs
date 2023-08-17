using AxWMPLib;
using MillionLE.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MillionLE
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private void IntroForm_Load(object sender, EventArgs e)
        {
            wmp.URL = "Vid\\intro.mp4";
            wmp.uiMode = "none";
            wmp.settings.autoStart = true;
        }

        private void Skip_btn_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.stop();
            Close();
        }

        private void Wmp_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                Close();
            }
        }
    }
}
