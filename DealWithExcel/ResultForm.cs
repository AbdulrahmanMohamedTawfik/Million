using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealWithExcel
{
    public partial class ResultForm : Form
    {
        private int receivedmoney, receivedScore, received_num_of_questions;
        private string language;
        public ResultForm(string lang, int money, int score, int num_of_questions)
        {
            InitializeComponent();
            receivedScore = score;
            received_num_of_questions = num_of_questions;
            language = lang;
            receivedmoney = money;
        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        }

        private void play_again_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            //show fireworks only if won the million
            if (receivedmoney != 1000_000)
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
                OK_btn.Text = "ماشي";
                play_again_btn.Text = "العب تاني";
                Result_txt.RightToLeft = RightToLeft.Yes;
                Result_txt.Text = " انت جاوبت علي " + receivedScore.ToString() + " سؤال صح من اصل " + received_num_of_questions.ToString() + " سؤال \n يعني بنسبة  %" + percentage.ToString() + "\n مبروك صار معك " + receivedmoney + " جنيه مصري ";
                if (receivedmoney==1000_000)
                {
                    Result_txt.Text += "\n********* مبروك ربحت المليون *********";
                }
                label1.Text = "مع تحيات: عبدالرحمن محمد توفيق";
            }
            else if (language == "english")
            {
                OK_btn.Text = "OK";
                play_again_btn.Text = "Play Again";
                Result_txt.RightToLeft = RightToLeft.No;
                Result_txt.Text = "your Score is " + receivedScore.ToString() + "/" + received_num_of_questions.ToString() + "\nand your Percentage is " + percentage.ToString() + "%\nCongratulations, you have " + receivedmoney + " L.E";
                if (receivedmoney == 1000_000)
                {
                    Result_txt.Text += "\n********* Congrats You Won The Million *********";
                }
                label1.Text = "Made by: Abdulrahman Mohamed Tawfik";
            }
        }
    }
}
