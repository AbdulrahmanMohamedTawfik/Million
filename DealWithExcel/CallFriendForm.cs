using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
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
        readonly int[] Percentages = new int[4];
        public CallFriendForm(HelperClass helper, int[] percentages)
        {
            InitializeComponent();
            Written_text.Hide();
            this.helper = helper;
            random = new Random();
            //sync sound with Game form
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.call_friend_counter);
                player.Play();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
            }
            Count30pictureBox.Enabled = true;
            for (int i = 0; i < percentages.Length; i++)
            {
                Percentages[i] = percentages[i];
            }
        }

        private void CallFriendForm_Load(object sender, EventArgs e)
        {
            GenerateRandomQuestion();

            //close automatically after 31sec
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

        private async void Write_text(string[] text)
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
        }

        private string[] Get_ans(int max, int item)
        {
            string[] ans = new string[2] { "v", "v" };
            if (helper.Language == "arabic")
            {
                switch (item)
                {
                    case 1:
                        {
                            ans[0] = "أ";
                            if (max > 35)
                                ans[1] = "على الارجح";
                            else
                                ans[1] = "لست متأكد";
                            break;
                        }
                    case 2:
                        {
                            ans[0] = "ب";
                            if (max > 35)
                                ans[1] = "على الارجح";
                            else
                                ans[1] = "لست متأكد";
                            break;
                        }
                    case 3:
                        {
                            ans[0] = "ج";
                            if (max > 35)
                                ans[1] = "على الارجح";
                            else
                                ans[1] = "لست متأكد";
                            break;
                        }
                    case 4:
                        {
                            ans[0] = "د";
                            if (max > 35)
                                ans[1] = "على الارجح";
                            else
                                ans[1] = "لست متأكد";
                            break;
                        }
                }
            }
            else if (helper.Language == "english")
            {
                switch (item)
                {
                    case 1:
                        {
                            ans[0] = "a";
                            if (max > 35)
                                ans[1] = "Most Probably";
                            else
                                ans[1] = "I'm not sure";
                            break;
                        }
                    case 2:
                        {
                            ans[0] = "b";
                            if (max > 35)
                                ans[1] = "Most Probably";
                            else
                                ans[1] = "I'm not sure";
                            break;
                        }
                    case 3:
                        {
                            ans[0] = "c";
                            if (max > 35)
                                ans[1] = "Most Probably";
                            else
                                ans[1] = "I'm not sure";
                            break;
                        }
                    case 4:
                        {
                            ans[0] = "d";
                            if (max > 35)
                                ans[1] = "Most Probably";
                            else
                                ans[1] = "I'm not sure";
                            break;
                        }
                }
            }
            return ans;
        }

        private void Get_ans_and_write()
        {
            int temp_max = 0, max = 0;
            for (int i = 0; i < Percentages.Length; i++)
            {
                if (Percentages[i] > temp_max)
                {
                    temp_max = Percentages[i];
                    max = i + 1;
                }
            }
            string[] ans = Get_ans(temp_max, max);
            if (helper.Language == "arabic")
            {
                Written_text.RightToLeft = RightToLeft.Yes;
                string[] Arabic_texts = new string[] { "أعتقد الاجابة الصحيحة هي", ans[0], ans[1] };
                Written_text.Show();
                Write_text(Arabic_texts);
            }
            else if (helper.Language == "english")
            {
                Written_text.RightToLeft = RightToLeft.No;
                string[] English_texts = new string[] { "I think the correct answer is", ans[0], ans[1] };
                Written_text.Show();
                Write_text(English_texts);
            }
        }
        private async void Choice1_btn_Click(object sender, EventArgs e)
        {
            choice1_btn.BackColor = Color.DarkOrange;
            if (correct_ans == 1)//correct
            {
                choice1_btn.Enabled = false;
                choice2_btn.Enabled = false;
                choice3_btn.Enabled = false;
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
                choice1_btn.Enabled = true;
                choice2_btn.Enabled = true;
                choice3_btn.Enabled = true;
                Get_ans_and_write();
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
                choice1_btn.Enabled = false;
                choice2_btn.Enabled = false;
                choice3_btn.Enabled = false;
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
                choice1_btn.Enabled = true;
                choice2_btn.Enabled = true;
                choice3_btn.Enabled = true;
                Get_ans_and_write();
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
                choice1_btn.Enabled = false;
                choice2_btn.Enabled = false;
                choice3_btn.Enabled = false;
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
                choice1_btn.Enabled = true;
                choice2_btn.Enabled = true;
                choice3_btn.Enabled = true;
                Get_ans_and_write();
            }
            else
            {
                helper.IsCorrect = false;
                Show_correct_ans(3);
            }
        }

        private async void Show_correct_ans(int wrong_clicked_ans)
        {
            this.Enabled = false;
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
            switch (correct_ans)
            {
                case 1:
                    choice1_btn.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice1_btn.BackColor = Color.LightGreen;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice1_btn.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice1_btn.BackColor = Color.LightGreen;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice1_btn.BackColor = Color.Green;
                    break;
                case 2:
                    choice2_btn.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice2_btn.BackColor = Color.LightGreen;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice2_btn.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice2_btn.BackColor = Color.LightGreen;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice2_btn.BackColor = Color.Green;
                    break;
                case 3:
                    choice3_btn.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice3_btn.BackColor = Color.LightGreen;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice3_btn.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice3_btn.BackColor = Color.LightGreen;
                    await Task.Delay(500); // Wait for .5 seconds
                    choice3_btn.BackColor = Color.Green;
                    break;
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
            timer.Stop();
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer();
                player.Stop();
            }
        }

        private void Skip_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;

            //handle helper.Language
            if (helper.Language == "arabic")
                result = MessageBox.Show("عايز تقفل مساعدة الصديق اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            else if (helper.Language == "english")
                result = MessageBox.Show("Are you sure you want to close friend help?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //close this form if 'yes' choosed
            if (result == DialogResult.Yes)
                Close();
        }

        private void CallFriendForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        }
    }
}
