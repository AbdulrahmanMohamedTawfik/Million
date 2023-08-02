using AxWMPLib;
using MillionLE.Properties;
using SharpCompress.Archives.Rar;
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
using SharpCompress.Common;
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
            //string rarFilePath = "intro.rar";
            //string password = "iwonmillion";
            //string videoFileName = "intro.mp4"; // Update with the actual video file name inside the RAR archive

            //var reader = RarArchive.Open(rarFilePath, new SharpCompress.Readers.ReaderOptions { Password = password }))

            //    foreach (var entry in reader.Entries)
            //    {
            //        if (!entry.IsDirectory && entry.Key == videoFileName)
            //        {
            //            // Assuming you have a video player control named "videoPlayer" on your form
            //            Skip_btn.Text = entry.Key.ToString();
            //            wmp.URL = entry.Key;
            //            //wmp.uiMode = "none";
            //            //wmp.settings.autoStart = true;
            //            break;
            //        }
            //    }
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
