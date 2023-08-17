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
        SoundPlayer player;
        readonly HelperClass helper;
        private static readonly string EnglishfilePath = "Data\\EnglishData.xlsx", ArabicfilePath = "Data\\ArabicData.xlsx";
        Stream stream;
        IExcelDataReader reader;

        public MainForm()
        {
            InitializeComponent();
            progressBar.Hide();
            helper = new HelperClass
            {
                Difficulty = "Easy",
                Language = "arabic",
                IsSoundOn = true,
                IsCorrect = false,
                IsHelp50Used = false,
            };
        }

        private async void Start_btn_Click(object sender, EventArgs e)
        {
            Start_btn.Enabled = false;
            progressBar.Show();
            for (int i = 0; i < 3; i++)//30
            {
                progressBar.PerformStep();
                await Task.Delay(100);
            }
            bool isFormOpen = Application.OpenForms.OfType<GameForm>().Any();
            if (isFormOpen)
                Hide();
            if (helper.Language == "arabic")
            {
                try
                {
                    stream = File.Open(ArabicfilePath, FileMode.Open, FileAccess.Read);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message+"\nاقفل ملفات الداتا لو مفتوحة");
                    Application.Exit();
                }
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.hello_and_question1);
                    player.Play();
                }
                for (int i = 0; i < 3; i++)//60
                {
                    progressBar.PerformStep();
                    await Task.Delay(50);
                }
                reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" });
                for (int i = 0; i < 3; i++)//90
                {
                    progressBar.PerformStep();
                    await Task.Delay(50);
                }
            }
            else if (helper.Language == "english")
            {
                try
                {
                    stream = File.Open(EnglishfilePath, FileMode.Open, FileAccess.Read);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message + "\nclose data files if it's already opened");
                    Application.Exit();
                }
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.hello_and_question1);
                    player.Play();
                }
                for (int i = 0; i < 3; i++)//60
                {
                    progressBar.PerformStep();
                    await Task.Delay(50);
                }
                reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" });
                for (int i = 0; i < 3; i++)//90
                {
                    progressBar.PerformStep();
                    await Task.Delay(50);
                }
            }
            GameForm f = new GameForm(reader, helper);
            progressBar.PerformStep();
            f.ShowDialog();
            //back to main again
            stream.Close();
            progressBar.Value = 0;
            progressBar.Hide();
            if (helper.IsSoundOn)
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
            else
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
            Show();
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.start_music);
                player.PlayLooping();
            }
            Start_btn.Enabled = true;
        }

        private void Easy_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            helper.Difficulty = "Easy";
            Start_btn.FlatAppearance.MouseOverBackColor = Color.LightGreen;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Green;
        }

        private void Med_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            helper.Difficulty = "Medium";
            Start_btn.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Blue;
        }

        private void Hard_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            helper.Difficulty = "Hard";
            Start_btn.FlatAppearance.MouseOverBackColor = Color.LightCoral;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Red;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            easy_rad_btn.Checked = true;
            ar_radioButton.Checked = true;
            //show intro
            //IntroForm introForm = new IntroForm();
            //introForm.ShowDialog();
            player = new SoundPlayer(Properties.Resources.start_music);
            player.PlayLooping();
        }

        private void En_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            helper.Language = "english";
            lang_groupBox.Text = "Choose Language:";
            Start_btn.Text = "Start";
            difficulty_groupBox.Text = "Choose Difficulty:";
            lang_groupBox.RightToLeft = RightToLeft.No;
            ar_radioButton.RightToLeft = RightToLeft.No;
            en_radioButton.RightToLeft = RightToLeft.No;
            ar_pictureBox.Location = new Point(115, 40);
            en_pictureBox.Location = new Point(128, 90);
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
            helper.Language = "arabic";
            lang_groupBox.Text = "اختر اللغة:";
            lang_groupBox.RightToLeft = RightToLeft.Yes;
            ar_radioButton.RightToLeft = RightToLeft.Yes;
            en_radioButton.RightToLeft = RightToLeft.Yes;
            ar_pictureBox.Location = new Point(30, 40);
            en_pictureBox.Location = new Point(22, 90);
            Start_btn.Text = "ابدأ";
            difficulty_groupBox.Text = "اختر مستوى الصعوبة:";
            easy_rad_btn.Text = "سهل";
            med_rad_btn.Text = "متوسط";
            hard_rad_btn.Text = "صعب";
            easy_rad_btn.RightToLeft = RightToLeft.Yes;
            med_rad_btn.RightToLeft = RightToLeft.Yes;
            hard_rad_btn.RightToLeft = RightToLeft.Yes;
            easy_rad_btn.Location = new Point(344, 50);
            med_rad_btn.Location = new Point(200, 50);
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
            if (helper.Language == "arabic")
            {
                result = MessageBox.Show("عايز تخرج من اللعبة اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if (helper.Language == "english")
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
                    player.PlayLooping();
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
