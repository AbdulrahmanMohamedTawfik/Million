using System;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionLE
{
    public partial class EndForm : Form
    {
        private readonly string language;
        SoundPlayer player;
        readonly HelperClass helper;
        public EndForm(string lang,HelperClass helper)
        {
            InitializeComponent();
            language = lang;
            this.helper=helper;
            //sync sound with Result form
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.End);
                player.PlayLooping();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
            }
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            if (language == "arabic")
            {
                Written_text.RightToLeft= RightToLeft.Yes;
                string[] Arabic_texts = new string[] { "الاسئلة: عبدالرحمن محمد", "الشكل و التنسيق: عبدالرحمن محمد", "الكود: عبدالرحمن محمد", "شكر خاص للاستاذ: عبدالرحمن محمد" };
                Write_text(Arabic_texts);
            }
            else if (language == "english")
            {
                Written_text.RightToLeft = RightToLeft.No;
                string[] English_texts = new string[] { "Questions: Abdulrahman Mohamed", "UI: Abdulrahman Mohamed", "Code: Abdulrahman Mohamed", "Special Thanks To: Abdulrahman Mohamed" };
                Write_text(English_texts);
            }
        }

        private void Skip_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async void Write_text(string [] text)
        {
            Written_text.Text = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    await Task.Delay(200); // Wait for .2 seconds
                    Written_text.Text += text[i][j];
                }
                Written_text.AppendText(Environment.NewLine);
            }
            await Task.Delay(1000); // Wait for 1 second
            Application.Exit();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            //close ShowDataForm first if it is opened
            if (Application.OpenForms["ShowDataForm"] != null)
            {
                ShowDataForm dataForm = (ShowDataForm)Application.OpenForms["ShowDataForm"];
                dataForm.Close();
            }
            //handle language
            if (language == "arabic")
                result = MessageBox.Show("عايز تخرج من اللعبة اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            else if (language == "english")
                result = MessageBox.Show("Are you sure you want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //exit app if 'yes' choosed
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void Sound_btn_Click(object sender, EventArgs e)
        {
            // Toggle the state
            helper.IsSoundOn = !helper.IsSoundOn;

            // Set the button's background image based on the state
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.End);
                player.Play();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
                player.Stop();
            }
        }

        private void EndForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (helper.IsSoundOn)
                player.Stop();
        }
    }
}
