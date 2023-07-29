using System;
using System.Media;
using System.Windows.Forms;

namespace MillionLE
{
    public partial class ResultForm : Form
    {
        private readonly int receivedmoney, receivedScore, received_num_of_questions, received_diffculty;
        private readonly string language;
        SoundPlayer player;
        readonly HelperClass helper;

        public ResultForm(string lang, HelperClass helper, int money, int score, int num_of_questions, int DifficultyValue)
        {
            InitializeComponent();
            receivedScore = score;
            received_num_of_questions = num_of_questions;
            language = lang;
            receivedmoney = money;
            received_diffculty = DifficultyValue;
            this.helper = helper;
            //sync sound with Game form
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.clap);
                player.Play();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
            }
        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ResultForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        }

        private void Sound_btn_Click(object sender, EventArgs e)
        {
            // Toggle the state
            helper.IsSoundOn = !helper.IsSoundOn;

            // Set the button's background image based on the state
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.clap);
                player.PlayLooping();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
                player.Stop();
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
            EndForm endForm = new EndForm(language, helper);
            endForm.ShowDialog();
        }

        private void Play_again_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            //show fireworks only if won the million
            if (receivedScore != 15)
            {
                fireworks_pictureBox1.Hide();
                fireworks_pictureBox2.Hide();
                fireworks_pictureBox3.Hide();
                fireworks_pictureBox4.Hide();
            }
            //achieved progress calculations
            float percentage = ((float)receivedScore / (float)received_num_of_questions) * 100;
            if (language == "arabic")
            {
                Exit_btn.Text = "خروج";
                play_again_btn.Text = "العب تاني";
                Result_txt.RightToLeft = RightToLeft.Yes;
                Result_txt.Text = " انت جاوبت علي " + receivedScore.ToString() + " سؤال صح من اصل " + received_num_of_questions.ToString() + " سؤال \n يعني بنسبة  %" + percentage.ToString() + "\n مبروك كسبت " + receivedmoney + " جنيه مصري ";
                if (receivedScore == 15)
                {
                    switch (received_diffculty)
                    {
                        case 20://easy
                            Result_txt.Text += "\n********* مبروك ربحت المليون *********\nتقدر تلعب علي المستوي المتوسط لو حابب";
                            break;
                        case 40://med
                            Result_txt.Text += "\n********* مبروك ربحت المليون *********\nتقدر تلعب علي المستوي الصعب لو حابب \nو في جايزة مستنياك";
                            break;
                        case 60://hard
                            Result_txt.Text += "\n********* مبروك ربحت المليون *********\nانت عبقري و مكافأتك هي الرقم السري ده\npassword: iwonmillion\nتقدر دلوقتي تفتح ملفات الداتا\n و تشوف الاسئلة و تعدلها براحتك";
                            break;
                        default:
                            break;
                    }

                }
                label1.Text = "مع تحيات: عبدالرحمن محمد توفيق";
            }
            else if (language == "english")
            {
                Exit_btn.Text = "Exit";
                play_again_btn.Text = "Play Again";
                Result_txt.RightToLeft = RightToLeft.No;
                Result_txt.Text = "your Score is " + receivedScore.ToString() + "/" + received_num_of_questions.ToString() + "\nand your Percentage is " + percentage.ToString() + "%\nCongratulations, you have " + receivedmoney + " L.E";
                if (receivedScore == 15)
                {
                    switch (received_diffculty)
                    {
                        case 20://easy
                            Result_txt.Text += "\n********* Congrats You Won The Million *********\nyou can now play on medium level if you like";
                            break;
                        case 40://med
                            Result_txt.Text += "\n********* Congrats You Won The Million *********\nyou can now play on hard level if you like\n and there is an award awaits you";
                            break;
                        case 60://hard
                            Result_txt.Text += "\n********* Congrats You Won The Million *********\nyou are a genius and your award is this password\npassword: iwonmillion\nyou can now see and edit questions";
                            break;
                        default:
                            break;
                    }

                }
                label1.Text = "Made by: Abdulrahman Mohamed Tawfik";
            }
        }
    }
}
