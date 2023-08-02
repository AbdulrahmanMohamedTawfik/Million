using System;
using System.Media;
using System.Windows.Forms;

namespace MillionLE
{
    public partial class ResultForm : Form
    {
        private readonly int receivedmoney, receivedScore, received_num_of_questions;
        SoundPlayer player;
        readonly HelperClass helper;

        public ResultForm(HelperClass helper, int money, int score, int num_of_questions)
        {
            InitializeComponent();
            receivedScore = score;
            received_num_of_questions = num_of_questions;
            receivedmoney = money;
            this.helper = helper;
            //sync sound with Game form
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
                if (receivedScore == 15)
                {
                    player = new SoundPlayer(Properties.Resources.fireworks);
                    player.PlayLooping();
                }
                else
                {
                    player = new SoundPlayer(Properties.Resources.End);
                    player.PlayLooping();
                }
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
                player.Stop();
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Credits_btn_Click(object sender, EventArgs e)
        {
            Close();
            EndForm endForm = new EndForm(helper.Language, helper);
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
                ResultpictureBox.Hide();
            }
            else//won million
            {
                this.BackgroundImage = null;
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.fireworks);
                    player.PlayLooping();
                }
            }
            if (receivedScore == 0)
            {
                ResultpictureBox.Hide();
                if (helper.Language == "arabic")
                {
                    Result_txt.RightToLeft = RightToLeft.Yes;
                    Exit_btn.Text = "لا يعم انا عايز اخرج";
                    Credits_btn.Text = "مين اللي عمل اللعبة؟";
                    play_again_btn.Text = "هلعب تاني";
                    Result_txt.Text = "للاسف معلوماتك مش كفاية \n بس لو لعبت تاني يمكن تكسب ";
                    label1.Text = "مع تحيات: عبدالرحمن محمد توفيق";
                }
                else if (helper.Language == "english")
                {
                    Result_txt.RightToLeft = RightToLeft.No;
                    Exit_btn.Text = "No bro, i want to exit";
                    Credits_btn.Text = "Who Made this game?";
                    play_again_btn.Text = "I'll Play Again";
                    Result_txt.Text = "Sorry, your knowledge is not good enough \n but if you play again,you may win ";
                    label1.Text = "Made by: Abdulrahman Mohamed Tawfik";
                }
            }
            else//normal case
            {
                //achieved progress calculations
                float percentage = ((float)receivedScore / (float)received_num_of_questions) * 100;
                if (helper.Language == "arabic")
                {
                    Exit_btn.Text = "خروج";
                    Credits_btn.Text = "المطور";
                    play_again_btn.Text = "العب تاني";
                    Result_txt.RightToLeft = RightToLeft.Yes;
                    Result_txt.Text = " انت جاوبت علي " + receivedScore.ToString() + " سؤال صح من اصل " + received_num_of_questions.ToString() + " سؤال \n يعني بنسبة  %" + percentage.ToString() + "\n مبروك كسبت " + receivedmoney + " جنيه مصري ";
                    if (receivedScore == 15)
                    {
                        switch (helper.Difficulty)
                        {
                            case "Easy":
                                Result_txt.Text += "\n********* مبروك ربحت المليون *********\nتقدر تلعب علي المستوي المتوسط لو حابب";
                                break;
                            case "Medium":
                                Result_txt.Text += "\n********* مبروك ربحت المليون *********\nتقدر تلعب علي المستوي الصعب لو حابب \nو في جايزة مستنياك";
                                break;
                            case "Hard":
                                Result_txt.Text += "\n********* مبروك ربحت المليون *********\nانت عبقري و مكافأتك هي الرقم السري ده\npassword: iwonmillion\nتقدر دلوقتي تفتح ملفات الداتا\n و تشوف الاسئلة و تعدلها براحتك";
                                break;
                            default:
                                break;
                        }

                    }
                    label1.Text = "مع تحيات: عبدالرحمن محمد توفيق";
                }
                else if (helper.Language == "english")
                {
                    Exit_btn.Text = "Exit";
                    Credits_btn.Text = "Developer";
                    play_again_btn.Text = "Play Again";
                    Result_txt.RightToLeft = RightToLeft.No;
                    Result_txt.Text = "your Score is " + receivedScore.ToString() + "/" + received_num_of_questions.ToString() + "\nand your Percentage is " + percentage.ToString() + "%\nCongratulations, you have " + receivedmoney + " L.E";
                    if (receivedScore == 15)
                    {
                        switch (helper.Difficulty)
                        {
                            case "Easy":
                                Result_txt.Text += "\n********* Congrats You Won The Million *********\nyou can now play on medium level if you like";
                                break;
                            case "Medium":
                                Result_txt.Text += "\n********* Congrats You Won The Million *********\nyou can now play on hard level if you like\n and there is an award awaits you";
                                break;
                            case "Hard":
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
}
