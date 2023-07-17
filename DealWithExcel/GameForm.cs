using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;

namespace DealWithExcel
{
    public partial class GameForm : Form
    {
        private readonly int Difficulty;
        private readonly string language;
        private System.Windows.Forms.Timer timer;
        private static readonly string EnglishfilePath = "Data\\EnglishData.xlsx", ArabicfilePath = "Data\\ArabicData.xlsx";
        private string correct_answer;
        Stream stream;
        IExcelDataReader reader;
        DataSet dataSet;
        public int money_index = 0, choice1, choice2, choice3, choice4;
        readonly int[] money = { 0, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250_000, 500_000, 1000_0000 };
        private static int row = 0, help50_used = 0, deleted_chice1, deleted_chice2;
        private static readonly int num_of_questions = 15;
        static readonly List<int> row_values = new List<int>();
        readonly Random random = new Random();

        public GameForm(string lang, int DifficultyValue = 15)
        {
            InitializeComponent();
            Difficulty = DifficultyValue;
            language = lang;
            x_50_50_btn.Hide();
            x_people_help_btn.Hide();
            x_help_call_btn.Hide();

            money_label.Hide();
            money_panel20.Hide();
            money_panel40.Hide();
            money_panel50.Hide();
            money_panel60.Hide();
            money_panel80.Hide();
            people_chart.Hide();
            if (language == "arabic")
            {
                SwapButtonLocations(choice1a_btn, choice2b_btn);
                SwapButtonLocations(choice3c_btn, choice4d_btn);
            }
            help50_used = 0;
            Loading();
        }

        //Loading() instead of Form1_Load() because opening encyrepted excel file taking time and it make form shows empty for a moment
        private void Loading()
        {
            //generate 1st quetion
            row = random.Next(Difficulty - 20, Difficulty);
            row_values.Clear();//start new memorization
            row_values.Add(row);//memorize choosen question to eliminate repeatition

            //handling language
            if (language == "arabic")
            {
                Question_txt.RightToLeft = RightToLeft.Yes;
                money_values_panel.RightToLeft = RightToLeft.Yes;
                choice1a_btn.RightToLeft = RightToLeft.Yes;
                choice2b_btn.RightToLeft = RightToLeft.Yes;
                choice3c_btn.RightToLeft = RightToLeft.Yes;
                choice4d_btn.RightToLeft = RightToLeft.Yes;
                money_values_panel.RightToLeft = RightToLeft.Yes;
                Show_All_btn.Text = "رؤية كل الاسئلة";
                withdraw_btn.Text = "انسحاب";
                //read data
                stream = File.Open(ArabicfilePath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" });
                dataSet = reader.AsDataSet();
                //generate QA text
                Question_txt.Text = dataSet.Tables[0].Rows[row][0].ToString();
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "أ-" + dataSet.Tables[0].Rows[row][choice1].ToString();
                choice2b_btn.Text = "ب-" + dataSet.Tables[0].Rows[row][choice2].ToString();
                choice3c_btn.Text = "ج-" + dataSet.Tables[0].Rows[row][choice3].ToString();
                choice4d_btn.Text = "د-" + dataSet.Tables[0].Rows[row][choice4].ToString();
            }
            else if (language == "english")
            {
                Question_txt.RightToLeft = RightToLeft.No;
                money_values_panel.RightToLeft = RightToLeft.No;
                choice1a_btn.RightToLeft = RightToLeft.No;
                choice2b_btn.RightToLeft = RightToLeft.No;
                choice3c_btn.RightToLeft = RightToLeft.No;
                choice4d_btn.RightToLeft = RightToLeft.No;
                money_values_panel.RightToLeft = RightToLeft.No;
                Show_All_btn.Text = "Show All Questions";
                withdraw_btn.Text = "Withdraw";
                //read data
                stream = File.Open(EnglishfilePath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" });
                dataSet = reader.AsDataSet();
                //generate QA text
                Question_txt.Text = dataSet.Tables[0].Rows[row][0].ToString();
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "a-" + dataSet.Tables[0].Rows[row][choice1].ToString();
                choice2b_btn.Text = "b-" + dataSet.Tables[0].Rows[row][choice2].ToString();
                choice3c_btn.Text = "c-" + dataSet.Tables[0].Rows[row][choice3].ToString();
                choice4d_btn.Text = "d-" + dataSet.Tables[0].Rows[row][choice4].ToString();
            }
            correct_answer = dataSet.Tables[0].Rows[row][1].ToString();//the correct choice is always in column1
            Change_money_Color(money_index);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stream.Close();
        }

        private void Show_All_btn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ShowDataForm"] == null)//if not opened => open
            {
                if (Difficulty != 60)
                {
                    this.Enabled = false;
                    ShowDataForm form2 = new ShowDataForm(language);
                    form2.Show();
                    this.Enabled = true;
                }
            }
            else//already opened => focus
            {
                ShowDataForm dataForm = (ShowDataForm)Application.OpenForms["ShowDataForm"];
                dataForm.Focus();
            }
        }
        //the correct choice is always in column1 but choices is distributed randomly on buttons
        //so we check if choice_btn.text == column1.text
        private void Choice1a_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            Cursor = Cursors.No;
            this.Enabled = false;
            choice1a_btn.BackColor = Color.DarkOrange;
            if (correct_answer == choice1a_btn.Text.Substring(2))
            {
                money_index++;
                Show_Money();
                Change_money_Color(money_index);
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('a');
            }
            Cursor = Cursors.Default;
        }

        private void Choice2b_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            Cursor = Cursors.No;
            this.Enabled = false;
            choice2b_btn.BackColor = Color.DarkOrange;
            if (correct_answer == choice2b_btn.Text.Substring(2))
            {
                money_index++;
                Show_Money();
                Change_money_Color(money_index);
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('b');
            }
            Cursor = Cursors.Default;
        }

        private void Choice3c_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            Cursor = Cursors.No;
            this.Enabled = false;
            choice3c_btn.BackColor = Color.DarkOrange;
            if (correct_answer == choice3c_btn.Text.Substring(2))
            {
                money_index++;
                Show_Money();
                Change_money_Color(money_index);
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('c');
            }
            Cursor = Cursors.Default;
        }

        private void Choice4d_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            Cursor = Cursors.No;
            this.Enabled = false;
            choice4d_btn.BackColor = Color.DarkOrange;
            if (correct_answer == choice4d_btn.Text.Substring(2))
            {
                money_index++;
                Show_Money();
                Change_money_Color(money_index);
                Change_Question();
            }
            else
            {
                Show_Correct_Answer('d');
            }
            Cursor = Cursors.Default;
        }

        private async void Help_50_50_btn_Click(object sender, EventArgs e)
        {
            int del1 = 0, del2 = 0;
            help_50_50_btn.BackColor = Color.DarkOrange;
            Cursor = Cursors.No;
            this.Enabled = false;
            await Task.Delay(2000); // Wait for 2 seconds
            Cursor = Cursors.Default;
            help_50_50_btn.BackColor = Color.Transparent;
            if (correct_answer == choice1a_btn.Text.Substring(2))//1st buttton is correct => delete any other 2 buttons from rest(2,3,4)
            {
                del1 = random.Next(2, 5);
                do
                {
                    del2 = random.Next(2, 5);
                } while (del2 == del1);
                Delete_two_choices(del1, del2);
            }
            else if (correct_answer == choice2b_btn.Text.Substring(2))//2nd buttton is correct => delete any other 2 buttons from rest(1,3,4)
            {
                del1 = random.Next(1, 5);
                if (del1 == 2)
                    del1 = 3;
                do
                {
                    del2 = random.Next(1, 5);
                } while (del2 == del1 || del2 == 2);
                Delete_two_choices(del1, del2);
            }
            else if (correct_answer == choice3c_btn.Text.Substring(2))//3rd buttton is correct => delete any other 2 buttons from rest(1,2,4)
            {
                del1 = random.Next(1, 5);
                if (del1 == 3)
                    del1 = 4;
                do
                {
                    del2 = random.Next(1, 5);
                } while (del2 == del1 || del2 == 3);
                Delete_two_choices(del1, del2);
            }
            else if (correct_answer == choice4d_btn.Text.Substring(2))//4th buttton is correct => delete any other 2 buttons from rest(1,2,3)
            {
                del1 = random.Next(1, 4);
                do
                {
                    del2 = random.Next(1, 4);
                } while (del2 == del1);
                Delete_two_choices(del1, del2);
            }
            help_50_50_btn.Hide();
            x_50_50_btn.Show();
            help50_used = 1;
            deleted_chice1 = del1;
            deleted_chice2 = del2;
            this.Enabled = true;
        }

        private async void people_help_btn_Click(object sender, EventArgs e)
        {
            int[] votes = GenerateRandomVotesWithSomeReliability();

            //adjust some chart properties
            var xAxis = people_chart.ChartAreas[0].AxisX;
            xAxis.Maximum = 4.5;
            xAxis.CustomLabels.Clear();
            int i = 0;
            if (language == "arabic")
            {
                xAxis.CustomLabels.Add(0.5, 1.5, "أ");
                xAxis.CustomLabels.Add(1.5, 2.5, "ب");
                xAxis.CustomLabels.Add(2.5, 3.5, "ج");
                xAxis.CustomLabels.Add(3.5, 4.5, "د");
                people_chart.RightToLeft = RightToLeft.Yes;
                //add votes data to chart
                people_chart.Series.Clear();
                people_chart.Series.Add("الاصوات");
                people_chart.Series["الاصوات"].Points.DataBindY(votes);
                foreach (var point in people_chart.Series["الاصوات"].Points)
                {
                    point.LabelForeColor = Color.White;
                    point.Label = votes[i].ToString();//+ "٪";
                    i++;
                }
            }
            else if (language == "english")
            {
                xAxis.CustomLabels.Add(0.5, 1.5, "a");
                xAxis.CustomLabels.Add(1.5, 2.5, "b");
                xAxis.CustomLabels.Add(2.5, 3.5, "c");
                xAxis.CustomLabels.Add(3.5, 4.5, "d");
                people_chart.RightToLeft = RightToLeft.No;
                //add votes data to chart
                people_chart.Series.Clear();
                people_chart.Series.Add("Votes");
                people_chart.Series["Votes"].Points.DataBindY(votes);
                foreach (var point in people_chart.Series["Votes"].Points)
                {
                    point.LabelForeColor = Color.White;
                    point.Label = votes[i].ToString(); // + "%";
                    i++;
                }
            }


            people_help_btn.BackColor = Color.DarkOrange;
            Cursor = Cursors.No;
            this.Enabled = false;
            await Task.Delay(2000); // Wait for 2 seconds
            Cursor = Cursors.Default;
            people_help_btn.BackColor = Color.Transparent;
            //help is used
            people_help_btn.Hide();
            x_people_help_btn.Show();
            people_chart.Show();
            this.Enabled = true;
        }

        private void Help_Call_btn_Click(object sender, EventArgs e)
        {
            //not added yet
            help_call_btn.Hide();
            x_help_call_btn.Show();
        }

        private void Withdraw_btn_Click(object sender, EventArgs e)
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
                ResultForm resultForm = new ResultForm(language, money[money_index], money_index, num_of_questions, Difficulty);
                resultForm.ShowDialog();
                money_index = 0;
                stream.Close();
                Close();
            }
        }

        private void Auto_Open_Result_Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
            ResultForm resultForm = new ResultForm(language, money[money_index], money_index, num_of_questions, Difficulty);
            money_index = 0;
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

        private void Leave_btn_Click(object sender, EventArgs e)
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
                result = MessageBox.Show("عايز ترجع للشاشة الرئيسية اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            else if (language == "english")
                result = MessageBox.Show("Are you sure you want to go to Home Screen?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //close this form if 'yes' choosed
            if (result == DialogResult.Yes)
                Close();
        }

        private async void Change_Question()
        {
            //add some suspense
            await Task.Delay(2000 + money_index * 100); // Wait for 2 seconds + question_num * 100 (2,2.1,2.2,2.3,2.4,...,3.4)sec

            //reset backcolor after changing it by clicking choice button
            choice1a_btn.BackColor = Color.Transparent;
            choice2b_btn.BackColor = Color.Transparent;
            choice3c_btn.BackColor = Color.Transparent;
            choice4d_btn.BackColor = Color.Transparent;
            //generate random question id(row number)
            do
            {                                                  //Easy ,  Med  , Hard
                row = random.Next(Difficulty - 20, Difficulty);//1:15 , 11:25 , 16:30
            } while (row_values.Contains(row));//if it's repeated question then change it
            correct_answer = dataSet.Tables[0].Rows[row][1].ToString();//the correct choice is always in column1
            row_values.Add(row);//memorize choosen question to eliminate repeatition
            //end of questions
            if (row > dataSet.Tables[0].Rows.Count || money_index == money.Length - 1)
            {
                //close ShowDataForm first if it is opened
                if (Application.OpenForms["ShowDataForm"] != null)
                {
                    ShowDataForm dataForm = (ShowDataForm)Application.OpenForms["ShowDataForm"];
                    dataForm.Close();
                }
                ResultForm resultForm = new ResultForm(language, money[money_index], money_index, num_of_questions, Difficulty);
                money_index = 0;
                stream.Close();
                //won the million (delay = 3.5 sec)
                await Task.Delay(1900); // Wait for 1.9 seconds
                label15.BackColor = Color.Green;
                await Task.Delay(400); // Wait for .4 seconds
                label15.BackColor = Color.LightGreen;
                await Task.Delay(400); // Wait for .4 seconds
                label15.BackColor = Color.Green;
                await Task.Delay(400); // Wait for .4 seconds
                label15.BackColor = Color.LightGreen;
                await Task.Delay(400); // Wait for .4 seconds
                label15.BackColor = Color.Green;
                await Task.Delay(400); // Wait for .4 seconds
                label15.BackColor = Color.LightGreen;
                Close();
                resultForm.ShowDialog();
            }

            //else
            Question_txt.Text = dataSet.Tables[0].Rows[row][0].ToString();
            if (language == "arabic")
            {
                choice1a_btn.RightToLeft = RightToLeft.Yes;
                choice2b_btn.RightToLeft = RightToLeft.Yes;
                choice3c_btn.RightToLeft = RightToLeft.Yes;
                choice4d_btn.RightToLeft = RightToLeft.Yes;
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "أ-" + dataSet.Tables[0].Rows[row][choice1].ToString();
                choice2b_btn.Text = "ب-" + dataSet.Tables[0].Rows[row][choice2].ToString();
                choice3c_btn.Text = "ج-" + dataSet.Tables[0].Rows[row][choice3].ToString();
                choice4d_btn.Text = "د-" + dataSet.Tables[0].Rows[row][choice4].ToString();
            }
            else if (language == "english")
            {
                choice1a_btn.RightToLeft = RightToLeft.No;
                choice2b_btn.RightToLeft = RightToLeft.No;
                choice3c_btn.RightToLeft = RightToLeft.No;
                choice4d_btn.RightToLeft = RightToLeft.No;
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "a-" + dataSet.Tables[0].Rows[row][choice1].ToString();
                choice2b_btn.Text = "b-" + dataSet.Tables[0].Rows[row][choice2].ToString();
                choice3c_btn.Text = "c-" + dataSet.Tables[0].Rows[row][choice3].ToString();
                choice4d_btn.Text = "d-" + dataSet.Tables[0].Rows[row][choice4].ToString();
            }
            //enable all choices buttons after 2 of them are disabled by 50:50 button
            if (help50_used == 1)
            {
                choice1a_btn.Enabled = true; choice2b_btn.Enabled = true; choice3c_btn.Enabled = true; choice4d_btn.Enabled = true;
                help50_used = 0;
            }
            this.Enabled = true;
            people_chart.Hide();

            money_label.Hide();
            money_panel20.Hide();
            money_panel40.Hide();
            money_panel50.Hide();
            money_panel60.Hide();
            money_panel80.Hide();
        }

        private async void Change_money_Color(int money_index)
        {
            switch (money_index)
            {
                case 0://change question delay = 2sec
                    label1.BackColor = Color.Orange;
                    break;
                case 1://change question delay = 2.1sec
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
                case 2://change question delay = 2.2sec
                    await Task.Delay(600); // Wait for .6 seconds
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
                case 3://change question delay = 2.3sec
                    await Task.Delay(700); // Wait for .7 seconds
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
                case 4://change question delay = 2.4sec
                    await Task.Delay(800); // Wait for .8 seconds
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
                case 5://change question delay = 2.5sec
                    await Task.Delay(900); // Wait for 0.9 seconds
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
                case 6://change question delay = 2.6sec
                    await Task.Delay(1000); // Wait for 1 seconds
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
                case 7://change question delay = 2.7sec
                    await Task.Delay(1100); // Wait for 1.1 seconds
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
                case 8://change question delay = 2.8sec
                    await Task.Delay(1200); // Wait for 1.2 seconds
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
                case 9://change question delay = 2.9sec
                    await Task.Delay(1300); // Wait for 1.3 seconds
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
                case 10://change question delay = 3sec
                    await Task.Delay(1400); // Wait for 1.4 seconds
                    label10.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label10.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label10.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label10.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label10.BackColor = Color.Transparent;
                    label11.BackColor = Color.DarkOrange;
                    break;
                case 11://change question delay = 3.1sec
                    await Task.Delay(1500); // Wait for 1.5 seconds
                    label11.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label11.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label11.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label11.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label11.BackColor = Color.Transparent;
                    label12.BackColor = Color.DarkOrange;
                    break;
                case 12://change question delay = 3.2sec
                    await Task.Delay(1600); // Wait for 1.6 seconds
                    label12.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label12.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label12.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label12.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label12.BackColor = Color.Transparent;
                    label13.BackColor = Color.DarkOrange;
                    break;
                case 13://change question delay = 3.3sec
                    await Task.Delay(1700); // Wait for 1.7 seconds
                    label13.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label13.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label13.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label13.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label13.BackColor = Color.Transparent;
                    label14.BackColor = Color.DarkOrange;
                    break;
                case 14://change question delay = 3.4sec
                    await Task.Delay(1800); // Wait for 1.8 seconds
                    label14.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label14.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label14.BackColor = Color.Green;
                    await Task.Delay(400); // Wait for .4 seconds
                    label14.BackColor = Color.Orange;
                    await Task.Delay(400); // Wait for .4 seconds
                    label14.BackColor = Color.Transparent;
                    label15.BackColor = Color.DarkOrange;
                    break;
                default:
                    break;
            }

        }

        private async void Show_Correct_Answer(char wrong_clicked_ans)
        {
            //add some suspense
            await Task.Delay(2000); // Wait for 2 seconds
            if (money[money_index] == 500_000)
                await Task.Delay(500); // Wait for additional .5 seconds
            else if (money[money_index] == 600_000)
                await Task.Delay(600); // Wait for additional .6 seconds
            else if (money[money_index] == 700_000)
                await Task.Delay(700); // Wait for additional .7 seconds
            else if (money[money_index] == 800_000)
                await Task.Delay(800); // Wait for additional .8 seconds
            else if (money[money_index] == 900_000)
                await Task.Delay(900); // Wait for additional .9 seconds
            else if (money[money_index] == 1000_000)
                await Task.Delay(1000); // Wait for additional 1 seconds
            switch (wrong_clicked_ans)
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
            if (choice1a_btn.Text != "" && correct_answer == choice1a_btn.Text.Substring(2))
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
            }
            else if (choice2b_btn.Text != "" && correct_answer == choice2b_btn.Text.Substring(2))
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
            }
            else if (choice3c_btn.Text != "" && correct_answer == choice3c_btn.Text.Substring(2))
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
            }
            else if (choice4d_btn.Text != "" && correct_answer == choice4d_btn.Text.Substring(2))
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
            }
            //open result form automatically after 1sec
            timer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1 seconds
            };
            timer.Tick += Auto_Open_Result_Timer_Tick;
            timer.Enabled = true;
        }

        private void Delete_two_choices(int del1_index, int del2_index)
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

        private int[] GenerateRandomVotesWithSomeReliability()
        {
            Random random = new Random();
            int[] votes = new int[4];
            for (int i = 0; i < votes.Length; i++)
            {
                votes[i] = random.Next(1, 80);
            }
            //if help 50:50 used first
            if (help50_used == 1)
            {
                votes[deleted_chice1 - 1] = 0;
                votes[deleted_chice2 - 1] = 0;
            }
            //add some reliability to people opinion
            if (choice1a_btn.Text != "" && correct_answer == choice1a_btn.Text.Substring(2))//1st buttton is correct => increase votes of 1st choice
            {
                votes[0] += 16;
            }
            else if (choice2b_btn.Text != "" && correct_answer == choice2b_btn.Text.Substring(2))//2nd buttton is correct => increase votes of 2nd choice
            {
                votes[1] += 16;
            }
            else if (choice3c_btn.Text != "" && correct_answer == choice3c_btn.Text.Substring(2))//3rd buttton is correct => increase votes of 3rd choice
            {
                votes[2] += 16;
            }
            else if (choice4d_btn.Text != "" && correct_answer == choice4d_btn.Text.Substring(2))//4th buttton is correct => increase votes of 4th choice
            {
                votes[3] += 16;
            }

            return votes;
        }

        public static void GenerateRandomChoices(out int choice1, out int choice2, out int choice3, out int choice4)
        {
            Random random = new Random();
            HashSet<int> uniqueValues = new HashSet<int>();

            while (uniqueValues.Count < 4)
            {
                int randomValue = random.Next(1, 5);
                uniqueValues.Add(randomValue);
            }

            int[] valuesArray = uniqueValues.ToArray();
            choice1 = valuesArray[0];
            choice2 = valuesArray[1];
            choice3 = valuesArray[2];
            choice4 = valuesArray[3];
        }

        public static void SwapButtonLocations(Button button1, Button button2)
        {
            Point temp = button1.Location;
            button1.Location = button2.Location;
            button2.Location = temp;
        }

        private async void Show_Money()
        {
            people_chart.Hide();
            money_label.Text = money[money_index].ToString();
            await Task.Delay(500);
            money_panel20.Show();
            money_label.ForeColor = Color.Goldenrod;
            money_label.Show();
            await Task.Delay(100);
            money_panel20.Hide();
            money_panel40.Show();
            await Task.Delay(100);
            money_panel40.Hide();
            money_panel50.Show();
            money_label.ForeColor = Color.Gold;
            await Task.Delay(100);
            money_panel50.Hide();
            money_panel60.Show();
            money_label.Show();
            await Task.Delay(100);
            money_panel60.Hide();
            money_panel80.Show();
        }
    }
}
