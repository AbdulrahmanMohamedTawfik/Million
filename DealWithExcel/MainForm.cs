using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Media;
using ExcelDataReader;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;

namespace MillionLE
{
    public partial class MainForm : Form
    {
        private int Difficulty;
        public string language;
        SoundPlayer player;
        readonly HelperClass helper;
        private static readonly string EnglishfilePath = "Data\\EnglishData.xlsx", ArabicfilePath = "Data\\ArabicData.xlsx";
        Stream stream;
        IExcelDataReader reader;

        public MainForm()
        {
            InitializeComponent();
            progressBar1.Hide();
            helper = new HelperClass
            {
                IsSoundOn = true
            };
        }

        private async void Start_btn_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            for (int i = 0; i < 3; i++)//30
            {
                progressBar1.PerformStep();
                await Task.Delay(100);
            }
            bool isFormOpen = Application.OpenForms.OfType<GameForm>().Any();
            if (isFormOpen)
                Hide();
            if (language == "arabic")
            {
                stream = File.Open(ArabicfilePath, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < 3; i++)//60
                {
                    progressBar1.PerformStep();
                    await Task.Delay(100);
                }
                reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" });
                for (int i = 0; i < 3; i++)//90
                {
                    progressBar1.PerformStep();
                    await Task.Delay(100);
                }
            }
            else if (language == "english")
            {
                stream = File.Open(EnglishfilePath, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < 3; i++)//60
                {
                    progressBar1.PerformStep();
                    await Task.Delay(100);
                }
                reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" });
                for (int i = 0; i < 3; i++)//90
                {
                    progressBar1.PerformStep();
                    await Task.Delay(100);
                }
            }
            GameForm f = new GameForm(reader, language, helper, Difficulty);
            progressBar1.PerformStep();
            f.ShowDialog();
            //back to main again
            stream.Close();
            progressBar1.Value = 0;
            progressBar1.Hide();
            if (helper.IsSoundOn)
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
            else
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
            Show();
        }
        //75 Arabic question
        //60 English question
        private void Easy_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 20;
            Start_btn.FlatAppearance.MouseOverBackColor = Color.LightGreen;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Green;
        }

        private void Med_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 40;
            Start_btn.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Blue;
        }

        private void Hard_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 60;
            Start_btn.FlatAppearance.MouseOverBackColor = Color.LightCoral;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Red;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            easy_rad_btn.Checked = true;
            ar_radioButton.Checked = true;
            IntroForm introForm = new IntroForm();
            introForm.ShowDialog();
            player = new SoundPlayer(Properties.Resources.intro);
            player.Play();
        }

        private void En_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            language = "english";
            lang_groupBox.Text = "Coose Language:";
            Start_btn.Text = "Start";
            difficulty_groupBox.Text = "Choose Difficulty:";
            lang_groupBox.RightToLeft = RightToLeft.No;
            ar_radioButton.RightToLeft = RightToLeft.No;
            en_radioButton.RightToLeft = RightToLeft.No;
            ar_pictureBox.Location = new Point(100, 30);
            en_pictureBox.Location = new Point(120, 65);
            easy_rad_btn.Text = "Easy";
            med_rad_btn.Text = "Medium";
            hard_rad_btn.Text = "Hard";
            easy_rad_btn.RightToLeft = RightToLeft.No;
            med_rad_btn.RightToLeft = RightToLeft.No;
            hard_rad_btn.RightToLeft = RightToLeft.No;
            easy_rad_btn.Location = new Point(67, 50);
            med_rad_btn.Location = new Point(185, 50);
            hard_rad_btn.Location = new Point(344, 50);
            difficulty_groupBox.RightToLeft = RightToLeft.No;
        }

        private void Ar_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            language = "arabic";
            lang_groupBox.Text = "اختر اللغة:";
            lang_groupBox.RightToLeft = RightToLeft.Yes;
            ar_radioButton.RightToLeft = RightToLeft.Yes;
            en_radioButton.RightToLeft = RightToLeft.Yes;
            ar_pictureBox.Location = new Point(24, 30);
            en_pictureBox.Location = new Point(14, 65);
            Start_btn.Text = "ابدأ";
            difficulty_groupBox.Text = "اختر مستوى الصعوبة:";
            easy_rad_btn.Text = "سهل";
            med_rad_btn.Text = "متوسط";
            hard_rad_btn.Text = "صعب";
            easy_rad_btn.RightToLeft = RightToLeft.Yes;
            med_rad_btn.RightToLeft = RightToLeft.Yes;
            hard_rad_btn.RightToLeft = RightToLeft.Yes;
            easy_rad_btn.Location = new Point(344, 50);
            med_rad_btn.Location = new Point(185, 50);
            hard_rad_btn.Location = new Point(67, 50);
            difficulty_groupBox.RightToLeft = RightToLeft.Yes;
        }


        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (language == "arabic")
            {
                result = MessageBox.Show("عايز تخرج من اللعبة اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if (language == "english")
            {
                result = MessageBox.Show("Are you sure you want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Sound_btn_Click(object sender, EventArgs e)
        {
            // Toggle the state
            helper.IsSoundOn = !helper.IsSoundOn;

            // Set the button's background image based on the state
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                if (player != null && player.IsLoadCompleted)
                    player.Play();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
                if (player != null && player.IsLoadCompleted)
                    player.Stop();
            }
        }

        private void Intro_btn_Click(object sender, EventArgs e)
        {
            player.Stop();
            IntroForm introForm = new IntroForm();
            introForm.ShowDialog();
        }

    }
}
