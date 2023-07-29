using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionLE
{
    public partial class CallFriendForm : Form
    {
        readonly HelperClass helper;
        readonly Random random;
        int correct_ans;
        SoundPlayer player;

        public CallFriendForm(HelperClass helper)
        {
            InitializeComponent();
            this.helper = helper;
            random = new Random();
            Count30pictureBox.Enabled = true;
        }

        private void CallFriendForm_Load(object sender, EventArgs e)
        {
            GenerateRandomQuestion();

            //close automatically after 30sec
            timer = new System.Windows.Forms.Timer
            {
                Interval = 31000 // 31 seconds
            };
            timer.Tick += Auto_Close_Timer_Tick;
            timer.Enabled = true;
        }

        private void GenerateRandomQuestion()
        {
            int question = random.Next(1, 8);
            switch (question)
            {
                case 0:
                    {
                        QuestionPictureBox.Image = Properties.Resources._0_ans1;
                        correct_ans = 1;
                        break;
                    }
                case 1:
                    {
                        QuestionPictureBox.Image = Properties.Resources._1_ans3;
                        correct_ans = 3;
                        break;
                    }
                case 2:

                    {
                        QuestionPictureBox.Image = Properties.Resources._2_ans2;
                        correct_ans = 2;
                        break;
                    }
                case 3:
                    {
                        QuestionPictureBox.Image = Properties.Resources._3_ans2;
                        correct_ans = 2;
                        break;
                    }
                case 4:
                    {
                        QuestionPictureBox.Image = Properties.Resources._4_ans1;
                        correct_ans = 1;
                        break;
                    }
                case 5:
                    {
                        QuestionPictureBox.Image = Properties.Resources._5_ans1;
                        correct_ans = 1;
                        break;
                    }
                case 6:
                    {
                        QuestionPictureBox.Image = Properties.Resources._6_ans3;
                        correct_ans = 3;
                        break;
                    }
                case 7:
                    {
                        QuestionPictureBox.Image = Properties.Resources._7_ans1;
                        correct_ans = 1;
                        break;
                    }
                default:
                    break;
            }
        }

        private async void Choice1_btn_Click(object sender, EventArgs e)
        {
            choice1_btn.BackColor = Color.DarkOrange;
            if (correct_ans == 1)//correct
            {
                timer.Stop();
                Count30pictureBox.Enabled = false;
                helper.IsCorrect = true;
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.CORRECT_ANSWER);
                    player.Play();
                }
                choice1_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice1_btn.BackColor = Color.Green;

            }
            else//not correct
            {
                helper.IsCorrect = false;
                Show_correct_ans(1);
            }
        }

        private async void Choice2_btn_Click(object sender, EventArgs e)
        {
            choice2_btn.BackColor = Color.DarkOrange;
            if (correct_ans == 2)//correct
            {
                timer.Stop();
                Count30pictureBox.Enabled = false;
                helper.IsCorrect = true;
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.CORRECT_ANSWER);
                    player.Play();
                }
                choice2_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice2_btn.BackColor = Color.Green;
            }
            else
            {
                helper.IsCorrect = false;
                Show_correct_ans(2);
            }
        }

        private async void Choice3_btn_Click(object sender, EventArgs e)
        {
            choice3_btn.BackColor = Color.DarkOrange;
            if (correct_ans == 3)//correct
            {
                timer.Stop();
                Count30pictureBox.Enabled = false;
                helper.IsCorrect = true;
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.CORRECT_ANSWER);
                    player.Play();
                }
                choice3_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.Green;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.LightGreen;
                await Task.Delay(100);
                choice3_btn.BackColor = Color.Green;
            }
            else
            {
                helper.IsCorrect = false;
                Show_correct_ans(3);
            }
        }

        private async void Show_correct_ans(int wrong_clicked_ans)
        {
            timer.Stop();
            Count30pictureBox.Enabled = false;
            //add some suspense
            await Task.Delay(2000); // Wait for 2 seconds
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.wrong_answer);
                player.Play();
            }
            await Task.Delay(6000); // Wait for additional 6 seconds
            switch (wrong_clicked_ans)
            {
                case 1:
                    choice1_btn.BackColor = Color.Red;
                    break;
                case 2:
                    choice2_btn.BackColor = Color.Red;
                    break;
                case 3:
                    choice3_btn.BackColor = Color.Red;
                    break;
                default:
                    break;
            }
            if (choice1_btn.Text != "" && correct_ans == 1)
            {
                choice1_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice1_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice1_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice1_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice1_btn.BackColor = Color.Green;
            }
            else if (choice2_btn.Text != "" && correct_ans == 2)
            {
                choice2_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice2_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice2_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice2_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice2_btn.BackColor = Color.Green;
            }
            else if (choice3_btn.Text != "" && correct_ans == 3)
            {
                choice3_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice3_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice3_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice3_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice3_btn.BackColor = Color.Green;
            }

            //close automatically after 1sec
            timer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1 seconds
            };
            timer.Tick += Auto_Close_Timer_Tick;
            timer.Enabled = true;
        }
        private void Sound_btn_Click(object sender, EventArgs e)
        {
            // Toggle the state
            helper.IsSoundOn = !helper.IsSoundOn;

            // Set the button's background image based on the state
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.thinking);
                player.PlayLooping();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
                player.Stop();
            }
        }

        private void Auto_Close_Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        private void CallFriendForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (helper.IsSoundOn)
            {
                player.Stop();
            }
        }
    }
}
