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
        private int receivedScore, received_num_of_questions;
        private string language;
        public ResultForm(string lang, int score, int num_of_questions)
        {
            InitializeComponent();
            receivedScore = score;
            received_num_of_questions = num_of_questions;
            language = lang;
        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void play_again_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            float percentage = ((float)receivedScore / (float)received_num_of_questions) * 100;
            if (language == "arabic")
            {
                Result_txt.Text = " انت جاوبت علي " + receivedScore.ToString() + " سؤال صح من اصل " + received_num_of_questions.ToString() + " سؤال \n يعني بنسبة  %" + percentage.ToString();
                label1.Text = "مع تحيات: عبدالرحمن محمد توفيق";
            }
            else if (language == "english")
            {
                Result_txt.Text = "your Score is " + receivedScore.ToString() + "/" + received_num_of_questions.ToString() + "\nand your Percentage is " + percentage.ToString() + "%";
                label1.Text = "Made by: Abdulrahman Mohamed Tawfik";
            }
        }
    }
}
