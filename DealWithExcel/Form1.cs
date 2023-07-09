using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ExcelDataReader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DealWithExcel
{
    public partial class Form1 : Form
    {
        private int Difficulty;
        private string language;
        private System.Windows.Forms.Timer timer;
        public Form1(string lang, int DifficultyValue = 15)
        {
            InitializeComponent();
            Difficulty = DifficultyValue;
            language = lang;
            x_50_50_btn.Hide();
            x_people_help_btn.Hide();
            x_call_btn.Hide();
        }

        static String EnglishfilePath = "Data\\EnglishData.xlsx", ArabicfilePath = "Data\\ArabicData.xlsx";
        Stream stream;
        IExcelDataReader reader;
        DataSet dataSet;
        DataTable dataTable;
        public int score = 0, money = 0;
        static int row = 1, num_of_questions = 10, decreasing_couner = 0;
        static List<int> row_values = new List<int>();
        Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            //generate 1st quetion
            decreasing_couner = num_of_questions;
            row = random.Next(Difficulty - 14, Difficulty);
            row_values.Clear();
            row_values.Add(row);

            //handling language
            if (language == "arabic")
            {
                Question_txt.RightToLeft = RightToLeft.Yes;
                Show_All_btn.Text = "رؤية كل الاسئلة";
                withdraw_btn.Text = "انسحاب";
                stream = File.Open(ArabicfilePath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateReader(stream);
                dataSet = reader.AsDataSet();
                dataTable = dataSet.Tables[0];
            }
            else if (language == "english")
            {
                Question_txt.RightToLeft = RightToLeft.No;
                Show_All_btn.Text = "Show All Questions";
                withdraw_btn.Text = "Withdraw";
                stream = File.Open(EnglishfilePath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateReader(stream);
                dataSet = reader.AsDataSet();
                dataTable = dataSet.Tables[0];
            }
            Question_txt.Text = dataSet.Tables[0].Rows[row][0].ToString();
            choice1a_btn.Text = dataSet.Tables[0].Rows[row][1].ToString();
            choice2b_btn.Text = dataSet.Tables[0].Rows[row][2].ToString();
            choice3c_btn.Text = dataSet.Tables[0].Rows[row][3].ToString();
            choice4d_btn.Text = dataSet.Tables[0].Rows[row][4].ToString();
            Change_money_Color();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stream.Close();
        }

        private void Show_All_btn_Click(object sender, EventArgs e)
        {
            bool isForm2Open = Application.OpenForms.OfType<Form2>().Any();
            
            if (!isForm2Open)
            {
                if (Difficulty != 30)
                {
                    Form2 form2 = new Form2(language);
                    form2.Show();
                }
            }
        }

        private void choice1a_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            choice2b_btn.Enabled = false; 
            choice3c_btn.Enabled = false;
            choice4d_btn.Enabled = false;

            choice1a_btn.BackColor = Color.DarkOrange;
            if (dataSet.Tables[0].Rows[row][5].ToString() == "a")
            {
                score++;
                money += 100000;
                Change_money_Color();
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('a');
            }
        }

        private void choice2b_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            choice1a_btn.Enabled = false;
            choice3c_btn.Enabled = false;
            choice4d_btn.Enabled = false;

            choice2b_btn.BackColor = Color.DarkOrange;
            if (dataSet.Tables[0].Rows[row][5].ToString() == "b")
            {
                score++;
                money += 100000;
                Change_money_Color();
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('b');
            }
        }

        private void choice3c_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            choice1a_btn.Enabled = false;
            choice2b_btn.Enabled = false;
            choice4d_btn.Enabled = false;

            choice3c_btn.BackColor = Color.DarkOrange;
            if (dataSet.Tables[0].Rows[row][5].ToString() == "c")
            {
                score++;
                money += 100000;
                Change_money_Color();
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('c');
            }
        }

        private void choice4d_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            choice1a_btn.Enabled = false;
            choice2b_btn.Enabled = false;
            choice3c_btn.Enabled = false;

            choice4d_btn.BackColor = Color.DarkOrange;
            if (dataSet.Tables[0].Rows[row][5].ToString() == "d")
            {
                score++;
                money += 100000;
                Change_money_Color();
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('d');   
            }
        }

        private void help_50_50_btn_Click(object sender, EventArgs e)
        {
            int del1 = 0, del2 = 0;
            switch (dataSet.Tables[0].Rows[row][5].ToString())
            {
                case "a"://1st ans is correct => delete any other 2 questions from rest(2,3,4)
                    {
                        del1 = random.Next(2, 5);
                        do
                        {
                            del2 = random.Next(2, 5);
                        } while (del2 == del1);
                        delete_two_choices(del1, del2);
                        break;
                    }
                case "b":
                    {
                        del1 = random.Next(1, 5);
                        if (del1 == 2)
                            del1 = 3;
                        do
                        {
                            del2 = random.Next(1, 5);
                        } while (del2 == del1 || del2 == 2);
                        delete_two_choices(del1, del2);
                        break;
                    }
                case "c":
                    {
                        del1 = random.Next(1, 5);
                        if (del1 == 3)
                            del1 = 4;
                        do
                        {
                            del2 = random.Next(1, 5);
                        } while (del2 == del1 || del2 == 3);
                        delete_two_choices(del1, del2);
                        break;
                    }
                case "d":
                    {
                        del1 = random.Next(1, 4);
                        do
                        {
                            del2 = random.Next(1, 4);
                        } while (del2 == del1);
                        delete_two_choices(del1, del2);
                        break;
                    }
                default:
                    break;
            }
            x_50_50_btn.Show();
            help_50_50_btn.Hide();
        }

        private void people_help_btn_Click(object sender, EventArgs e)
        {

            people_help_btn.Hide();
            x_people_help_btn.Show();
        }

        private void call_btn_Click(object sender, EventArgs e)
        {
            call_btn.Hide();
            x_call_btn.Show();
        }

        private void withdraw_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (language == "arabic")
            {
                result = MessageBox.Show("عايز تنسحب اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (language == "english")
            {
                result = MessageBox.Show("Are you sure you want to withdraw?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (result == DialogResult.Yes)
            {
                ResultForm resultForm = new ResultForm(language, money, score, num_of_questions);
                resultForm.ShowDialog();
                decreasing_couner = num_of_questions;
                score = 0;
                stream.Close();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
            ResultForm resultForm = new ResultForm(language, money, score, num_of_questions);
            decreasing_couner = num_of_questions;
            score = 0;
            resultForm.ShowDialog();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
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

        private void Leave_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (language == "arabic")
            {
                result = MessageBox.Show("عايز ترجع للشاشة الرئيسية اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else if (language == "english")
            {
                result = MessageBox.Show("Are you sure you want to go to Home Screen?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            if (result == DialogResult.Yes)
            {
               Close();
            }
        }

        private async void Change_Question()
        {
            //add some suspense
            await Task.Delay(2000); // Wait for 2 seconds
            if (money == 500_000)
                await Task.Delay(500); // Wait for additional .5 seconds
            else if (money == 600_000)
                await Task.Delay(600); // Wait for additional .6 seconds
            else if (money == 700_000)
                await Task.Delay(700); // Wait for additional .7 seconds
            else if (money == 800_000)
                await Task.Delay(800); // Wait for additional .8 seconds
            else if (money == 900_000)
                await Task.Delay(900); // Wait for additional .9 seconds
            else if (money == 1000_000)
                await Task.Delay(1000); // Wait for additional 1 seconds
            //reset backcolor after changing it by clicking choice button
            choice1a_btn.BackColor = Color.Transparent;
            choice2b_btn.BackColor = Color.Transparent;
            choice3c_btn.BackColor = Color.Transparent;
            choice4d_btn.BackColor = Color.Transparent;
            //generate random question id(row number)
            do
            {                                                  //Easy ,  Med  , Hard
                row = random.Next(Difficulty - 14, Difficulty);//1:15 , 11:25 , 16:30
            } while (row_values.Contains(row));//if it's repeated question then change it
            row_values.Add(row);
            if (row > dataSet.Tables[0].Rows.Count || decreasing_couner <= 1)
            {
                ResultForm resultForm = new ResultForm(language, money, score, num_of_questions);
                decreasing_couner = num_of_questions;
                score = 0;
                stream.Close();
                //won the million (2+1 sec)
                await Task.Delay(400); // Wait for .4 seconds
                label10.BackColor = Color.Green;
                await Task.Delay(400); // Wait for .4 seconds
                label10.BackColor = Color.LightGreen;
                await Task.Delay(400); // Wait for .4 seconds
                label10.BackColor = Color.Green;
                await Task.Delay(400); // Wait for .4 seconds
                label10.BackColor = Color.LightGreen;
                await Task.Delay(400); // Wait for .4 seconds
                label10.BackColor = Color.Green;
                await Task.Delay(400); // Wait for .4 seconds
                label10.BackColor = Color.LightGreen;
                Close();
                resultForm.ShowDialog();
            }
            Question_txt.Text = dataSet.Tables[0].Rows[row][0].ToString();
            choice1a_btn.Text = dataSet.Tables[0].Rows[row][1].ToString();
            choice2b_btn.Text = dataSet.Tables[0].Rows[row][2].ToString();
            choice3c_btn.Text = dataSet.Tables[0].Rows[row][3].ToString();
            choice4d_btn.Text = dataSet.Tables[0].Rows[row][4].ToString();
            decreasing_couner--;
            //enable all choices buttons after being disabled by clicking choice or by 50:50 button
            choice1a_btn.Enabled = true;
            choice2b_btn.Enabled = true;
            choice3c_btn.Enabled = true;
            choice4d_btn.Enabled = true;
        }

        private async void Change_money_Color()
        {
            switch (money)
            {
                case 0:
                    label1.BackColor = Color.Orange;
                    break;
                case 100_000://2sec
                    await Task.Delay(500); // Wait for .5 seconds
                    label1.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label1.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label1.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label1.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label1.BackColor = Color.Transparent;
                    label2.BackColor = Color.DarkOrange;
                    break;
                case 200_000://2sec
                    await Task.Delay(500); // Wait for .5 seconds
                    label2.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label2.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label2.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label2.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label2.BackColor = Color.Transparent;
                    label3.BackColor = Color.DarkOrange;
                    break;
                case 300_000://2sec
                    await Task.Delay(500); // Wait for .5 seconds
                    label3.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label3.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label3.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label3.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label3.BackColor = Color.Transparent;
                    label4.BackColor = Color.DarkOrange;
                    break;
                case 400_000://2sec
                    await Task.Delay(500); // Wait for .5 seconds
                    label4.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label4.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label4.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label4.BackColor = Color.DarkOrange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label4.BackColor = Color.Transparent;
                    label5.BackColor = Color.Orange;
                    break;
                case 500_000://2+0.5 sec
                    await Task.Delay(1000); // Wait for 1 seconds
                    label5.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label5.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label5.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label5.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label5.BackColor = Color.Green;
                    label5.BackColor = Color.Transparent;
                    label6.BackColor = Color.DarkOrange;
                    break;
                case 600_000://2+0.6 sec
                    await Task.Delay(1100); // Wait for 1.1 seconds
                    label6.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label6.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label6.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label6.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label6.BackColor = Color.Green;
                    label6.BackColor = Color.Transparent;
                    label7.BackColor = Color.DarkOrange;
                    break;
                case 700_000://2+0.7 sec
                    await Task.Delay(1200); // Wait for 1.2 seconds
                    label7.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label7.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label7.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label7.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label7.BackColor = Color.Transparent;
                    label8.BackColor = Color.DarkOrange;
                    break;
                case 800_000://2+0.8 sec
                    await Task.Delay(1400); // Wait for 1.4 seconds
                    label8.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label8.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label8.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label8.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label8.BackColor = Color.Transparent;
                    label9.BackColor = Color.DarkOrange;
                    break;
                case 900_000://2+0.9 sec
                    await Task.Delay(1600); // Wait for 1.6 seconds
                    label9.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label9.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label9.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label9.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label9.BackColor = Color.Transparent;
                    label10.BackColor = Color.DarkOrange;
                    break;
                default:
                    break;
            }
            
        }

        private async void Show_Correct_Answer(char wrong_clicked_ans)
        {
            //add some suspense
            await Task.Delay(2000); // Wait for 2 seconds
            if (money == 500_000)
                await Task.Delay(500); // Wait for additional .5 seconds
            else if (money == 600_000)
                await Task.Delay(600); // Wait for additional .6 seconds
            else if (money == 700_000)
                await Task.Delay(700); // Wait for additional .7 seconds
            else if (money == 800_000)
                await Task.Delay(800); // Wait for additional .8 seconds
            else if (money == 900_000)
                await Task.Delay(900); // Wait for additional .9 seconds
            else if (money == 1000_000)
                await Task.Delay(1000); // Wait for additional 1 seconds
            switch(wrong_clicked_ans)
            {
                case 'a':
                    choice1a_btn.BackColor = Color.Red;
                    break;
                case 'b':
                    choice2b_btn.BackColor = Color.Red;
                    break;
                case 'c':
                    choice3c_btn.BackColor = Color.Red;
                    break;
                case 'd':
                    choice4d_btn.BackColor = Color.Red;
                    break;
                default:
                    break;
            }
            switch (dataSet.Tables[0].Rows[row][5].ToString())
            {
                case "a":
                    {
                        choice1a_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice1a_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice1a_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice1a_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice1a_btn.BackColor = Color.Green;
                        break;
                    }
                case "b":
                    {
                        choice2b_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice2b_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice2b_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice2b_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice2b_btn.BackColor = Color.Green;
                        break;
                    }
                case "c":
                    {
                        choice3c_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice3c_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice3c_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice3c_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice3c_btn.BackColor = Color.Green;
                        break;
                    }
                case "d":
                    {
                        choice4d_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice4d_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice4d_btn.BackColor = Color.Green;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice4d_btn.BackColor = Color.LightGreen;
                        await Task.Delay(400); // Wait for .4 seconds
                        choice4d_btn.BackColor = Color.Green;
                        break;
                    }
                default:
                    break;

            }
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1500; // 1.5 seconds
            timer.Tick += timer1_Tick;
            timer.Enabled = true;
        }

        private void delete_two_choices(int del1_index, int del2_index)
        {
            switch (del1_index)
            {
                case 1:
                    {
                        choice1a_btn.Text = "";
                        choice1a_btn.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        choice2b_btn.Text = "";
                        choice2b_btn.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        choice3c_btn.Text = "";
                        choice3c_btn.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        choice4d_btn.Text = "";
                        choice4d_btn.Enabled = false;
                        break;
                    }
                default:
                    break;
            }
            switch (del2_index)
            {
                case 1:
                    {
                        choice1a_btn.Text = "";
                        choice1a_btn.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        choice2b_btn.Text = "";
                        choice2b_btn.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        choice3c_btn.Text = "";
                        choice3c_btn.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        choice4d_btn.Text = "";
                        choice4d_btn.Enabled = false;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
