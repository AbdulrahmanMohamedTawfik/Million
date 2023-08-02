using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.Media;

namespace MillionLE
{
    public partial class GameForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private string correct_answer;
        DataSet dataSet;
        public int sheet_index = 0, money_index = 0, choice1, choice2, choice3, choice4, del1 = 0, del2 = 0, not_del1 = 0, not_del2 = 0;
        readonly int[] money = { 0, 100, 200, 300, 500, 1_000, 2_000, 4_000, 8_000, 16_000, 32_000, 64_000, 125_000, 250_000, 500_000, 1000_0000 };
        private static int row = 0;
        private static readonly int num_of_questions = 15;
        static readonly List<int> row_values = new List<int>();
        readonly Random random = new Random();
        SoundPlayer player;
        readonly HelperClass helper;
        readonly IExcelDataReader reader;

        public GameForm(IExcelDataReader reader, HelperClass helper)
        {
            InitializeComponent();
            this.reader = reader;
            this.helper = helper;
            //reset call friend result
            helper.IsCorrect = false;
            //sync sound with main form
            if (helper.IsSoundOn)
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_on;
                player = new SoundPlayer(Properties.Resources.thinking);
                player.PlayLooping();
            }
            else
            {
                Sound_btn.BackgroundImage = Properties.Resources.sound_off;
            }
            //zoom once
            this.Scale(new SizeF(1.2f, 1.2f));
            //MoveControlsUpAndLeft();
            //hide some controls
            x_50_50_btn.Hide();
            x_people_help_btn.Hide();
            x_help_call_btn.Hide();
            X_Help_Show_All_btn.Hide();
            money_label.Hide();
            money_panel20.Hide();
            money_panel40.Hide();
            money_panel50.Hide();
            money_panel60.Hide();
            money_panel80.Hide();
            people_chart.Hide();
            Count10pictureBox.Hide();
            //Count10pictureBox.Enabled = false;
            //tooltip
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(Help_Show_All_btn, "Show all questions for 10sec");
            //manage helper.Language direction
            if (helper.Language == "arabic")
            {
                SwapButtonLocations(choice1a_btn, choice2b_btn);
                SwapButtonLocations(choice3c_btn, choice4d_btn);
                //tooltip
                toolTip.SetToolTip(Help_Show_All_btn, "رؤية كل الأسئلة لمدة 10ث");
            }

            Loading();
        }

        //Loading() instead of Form1_Load() because opening encyrepted excel file taking time and it make form shows empty for a moment
        private void Loading()
        {
            //generate 1st quetion
            row = random.Next(0, 30);
            row_values.Clear();//start new memorization
            row_values.Add(row);//memorize choosen question to eliminate repeatition
            //choose sheet based on helper.Difficulty
            switch (helper.Difficulty)
            {
                case "Easy":
                    sheet_index = 0;
                    break;
                case "Medium":
                    sheet_index = 1;
                    break;
                case "Hard":
                    sheet_index = 2;
                    break;
            }
            //handling helper.Language
            if (helper.Language == "arabic")
            {
                Question_txt.RightToLeft = RightToLeft.Yes;
                money_values_panel.RightToLeft = RightToLeft.Yes;
                choice1a_btn.RightToLeft = RightToLeft.Yes;
                choice2b_btn.RightToLeft = RightToLeft.Yes;
                choice3c_btn.RightToLeft = RightToLeft.Yes;
                choice4d_btn.RightToLeft = RightToLeft.Yes;
                money_values_panel.RightToLeft = RightToLeft.Yes;
                //Help_Show_All_btn. = "رؤية كل الاسئلة";
                withdraw_btn.Text = "انسحاب";
                //read data

                dataSet = reader.AsDataSet();
                //generate QA text
                Question_txt.Text = dataSet.Tables[sheet_index].Rows[row][0].ToString();//all questions at column 0
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "أ-" + dataSet.Tables[sheet_index].Rows[row][choice1].ToString();
                choice2b_btn.Text = "ب-" + dataSet.Tables[sheet_index].Rows[row][choice2].ToString();
                choice3c_btn.Text = "ج-" + dataSet.Tables[sheet_index].Rows[row][choice3].ToString();
                choice4d_btn.Text = "د-" + dataSet.Tables[sheet_index].Rows[row][choice4].ToString();

            }
            else if (helper.Language == "english")
            {
                Question_txt.RightToLeft = RightToLeft.No;
                money_values_panel.RightToLeft = RightToLeft.No;
                choice1a_btn.RightToLeft = RightToLeft.No;
                choice2b_btn.RightToLeft = RightToLeft.No;
                choice3c_btn.RightToLeft = RightToLeft.No;
                choice4d_btn.RightToLeft = RightToLeft.No;
                money_values_panel.RightToLeft = RightToLeft.No;
                //Help_Show_All_btn.Text = "Show All Questions";
                withdraw_btn.Text = "Withdraw";
                //read data
                dataSet = reader.AsDataSet();
                //generate QA text
                Question_txt.Text = dataSet.Tables[sheet_index].Rows[row][0].ToString();
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "a-" + dataSet.Tables[sheet_index].Rows[row][choice1].ToString();
                choice2b_btn.Text = "b-" + dataSet.Tables[sheet_index].Rows[row][choice2].ToString();
                choice3c_btn.Text = "c-" + dataSet.Tables[sheet_index].Rows[row][choice3].ToString();
                choice4d_btn.Text = "d-" + dataSet.Tables[sheet_index].Rows[row][choice4].ToString();
            }
            correct_answer = dataSet.Tables[sheet_index].Rows[row][1].ToString();//the correct choice is always in column1
            Change_money_Color(money_index);
        }


        //the correct choice is always in column 1 (2nd column) but choices is distributed randomly on buttons
        //so we check if choice_btn.text == column1.text
        private void Choice1a_btn_Click(object sender, EventArgs e)
        {
            //disable rest choices
            //Cursor = Cursors.No;
            //this.Enabled = false;
            choice1a_btn.Enabled = false;
            choice2b_btn.Enabled = false;
            choice3c_btn.Enabled = false;
            choice4d_btn.Enabled = false;
            //Exit_btn.Enabled=false;
            withdraw_btn.Enabled = false;
            Leave_btn.Enabled = false;
            help_50_50_btn.Enabled = false;
            people_help_btn.Enabled = false;
            help_call_btn.Enabled = false;
            Help_Show_All_btn.Enabled = false;
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
            //Cursor = Cursors.No;
            choice1a_btn.Enabled = false;
            choice2b_btn.Enabled = false;
            choice3c_btn.Enabled = false;
            choice4d_btn.Enabled = false;
            //Exit_btn.Enabled = false;
            withdraw_btn.Enabled = false;
            Leave_btn.Enabled = false;
            help_50_50_btn.Enabled = false;
            people_help_btn.Enabled = false;
            help_call_btn.Enabled = false;
            Help_Show_All_btn.Enabled = false;
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
            //Cursor = Cursors.No;
            choice1a_btn.Enabled = false;
            choice2b_btn.Enabled = false;
            choice3c_btn.Enabled = false;
            choice4d_btn.Enabled = false;
            //Exit_btn.Enabled = false;
            withdraw_btn.Enabled = false;
            Leave_btn.Enabled = false;
            help_50_50_btn.Enabled = false;
            people_help_btn.Enabled = false;
            help_call_btn.Enabled = false;
            Help_Show_All_btn.Enabled = false;
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
            //Cursor = Cursors.No;
            choice1a_btn.Enabled = false;
            choice2b_btn.Enabled = false;
            choice3c_btn.Enabled = false;
            choice4d_btn.Enabled = false;
            //Exit_btn.Enabled = false;
            withdraw_btn.Enabled = false;
            Leave_btn.Enabled = false;
            help_50_50_btn.Enabled = false;
            people_help_btn.Enabled = false;
            help_call_btn.Enabled = false;
            Help_Show_All_btn.Enabled = false;
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

        private async void Help_Show_All_btn_Click(object sender, EventArgs e)
        {

            if (money_index >= 0)
            {
                X_Help_Show_All_btn.Show();
                Help_Show_All_btn.Hide();
                this.Enabled = false;
                ShowDataForm form2 = new ShowDataForm(helper.Language, sheet_index);
                form2.Show();
                this.Enabled = true;
                Count10pictureBox.Show();
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources.Countdown_10_seconds);
                    player.Play();
                }
                await Task.Delay(11000); // Wait for 11 seconds
                Count10pictureBox.Hide();
                form2.Close();
            }
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.thinking);
                player.Play();
            }
        }

        private async void Help_50_50_btn_Click(object sender, EventArgs e)
        {
            help_50_50_btn.Hide();
            x_50_50_btn.Show();

            help_50_50_btn.BackColor = Color.DarkOrange;
            Cursor = Cursors.No;
            this.Enabled = false;
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.help_50_50);
                player.Play();
            }
            await Task.Delay(8600); // Wait for 8.6 seconds
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
            helper.IsHelp50Used = true;
            this.Enabled = true;

            await Task.Delay(1500);
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.thinking);
                player.Play();
            }
        }

        private void UpdateChartSeriesData()
        {
            // Clear the existing data points

            var xAxis = people_chart.ChartAreas[0].AxisX;
            if (helper.Language == "arabic")
            {
                xAxis.CustomLabels.Add(0.5, 1.5, "أ");
                xAxis.CustomLabels.Add(1.5, 2.5, "ب");
                xAxis.CustomLabels.Add(2.5, 3.5, "ج");
                xAxis.CustomLabels.Add(3.5, 4.5, "د");
                people_chart.RightToLeft = RightToLeft.Yes;
                //add votes data to chart
                people_chart.Series.Clear();
                people_chart.Series.Add("الاصوات");
                // Generate random values for the chart series
                for (int i = 0; i < 4; i++)
                {
                    int randomValue = random.Next(100);
                    people_chart.Series["الاصوات"].Points.AddXY(i + 1, randomValue);
                }
            }
            else if (helper.Language == "english")
            {
                xAxis.CustomLabels.Add(0.5, 1.5, "a");
                xAxis.CustomLabels.Add(1.5, 2.5, "b");
                xAxis.CustomLabels.Add(2.5, 3.5, "c");
                xAxis.CustomLabels.Add(3.5, 4.5, "d");
                people_chart.RightToLeft = RightToLeft.No;
                //add votes data to chart
                people_chart.Series.Clear();
                people_chart.Series.Add("Votes");
                // Generate random values for the chart series
                for (int i = 0; i < 4; i++)
                {
                    int randomValue = random.Next(100);
                    people_chart.Series["Votes"].Points.AddXY(i + 1, randomValue);
                }
            }
            // Refresh the chart to reflect the changes
            people_chart.Invalidate();
        }

        void Scale_2_to_100(ref int[] percentages)
        {
            int sum = percentages[not_del1] + percentages[not_del2];
            while (sum != 100)
            {
                if (sum > 100)
                {
                    percentages[not_del1] -= 1;
                    sum = percentages[not_del1] + percentages[not_del2];
                    if (sum == 100)
                        break;
                    percentages[not_del2] -= 1;
                    sum = percentages[not_del1] + percentages[not_del2];
                    if (sum == 100)
                        break;
                }
                else if (sum < 100)
                {
                    percentages[not_del1] += 1;
                    sum = percentages[not_del1] + percentages[not_del2];
                    if (sum == 100)
                        break;
                    percentages[not_del2] += 1;
                    sum = percentages[not_del1] + percentages[not_del2];
                    if (sum == 100)
                        break;
                }
            }
        }

        void Scale_4_to_100(ref int[] percentages)
        {
            int sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
            while (sum != 100)
            {
                if (percentages[0] < 0)
                    percentages[0] = 0;
                if (percentages[1] < 0)
                    percentages[1] = 0;
                if (percentages[2] < 0)
                    percentages[2] = 0;
                if (percentages[3] < 0)
                    percentages[3] = 0;
                if (sum > 100)
                {
                    percentages[1] -= 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                    percentages[2] -= 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                    percentages[3] -= 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                }
                else if (sum < 100)
                {
                    percentages[0] += 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                    percentages[1] += 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                    percentages[2] += 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                    percentages[3] += 1;
                    sum = percentages[0] + percentages[1] + percentages[2] + percentages[3];
                    if (sum == 100)
                        break;
                }
            }
            if (percentages[1] < 0)
            {
                percentages[1] = 0;
                percentages[0] -= 1;
            }
            if (percentages[2] < 0)
            {
                percentages[2] = 0;
                percentages[0] -= 1;
            }
            if (percentages[3] < 0)
            {
                percentages[3] = 0;
                percentages[0] -= 1;
            }
        }

        void Get_not_del_indexes()//get not deleted answers
        {
            int[] not_del;
            List<int> indexes = new List<int> { 1, 2, 3, 4 };
            indexes.Remove(del1);
            indexes.Remove(del2);
            Console.WriteLine("indexes:");
            foreach (int i in indexes)
            {
                Console.WriteLine(i);
            }
            not_del = indexes.ToArray();
            not_del1 = not_del[0] - 1;
            not_del2 = not_del[1] - 1;
        }

        int Get_reliability_level_using_difficulty()
        {
            int level = 0;
            switch (helper.Difficulty)
            {
                case "Easy":
                    level = 11;
                    break;
                case "Medium":
                    level = 9;
                    break;
                case "Hard":
                    level = 7;
                    break;
            }
            return level;
        }

        private int[] GenerateRandomReliablePercentages()
        {
            Random random = new Random();
            int[] percentages = new int[4];
            int reliability = Get_reliability_level_using_difficulty();
            if (helper.IsHelp50Used)
            {
                Get_not_del_indexes();//array holds two indexes of not deleted answers(one of them are correct)
                if (choice1a_btn.Text != "" && correct_answer == choice1a_btn.Text.Substring(2))//1st buttton is correct => increase votes of 1st choice
                {
                    //randomize & shuffle
                    percentages[not_del1] = random.Next(50);
                    percentages[not_del2] = random.Next(50);
                    //add reliability
                    percentages[0] += reliability;
                    Scale_2_to_100(ref percentages);

                }
                else if (choice2b_btn.Text != "" && correct_answer == choice2b_btn.Text.Substring(2))//2nd buttton is correct => increase votes of 2nd choice
                {
                    //randomize & shuffle
                    percentages[not_del1] = random.Next(50);
                    percentages[not_del2] = random.Next(50);
                    //add reliability
                    percentages[1] += reliability;
                    Scale_2_to_100(ref percentages);
                }
                else if (choice3c_btn.Text != "" && correct_answer == choice3c_btn.Text.Substring(2))//3rd buttton is correct => increase votes of 3rd choice
                {
                    //randomize & shuffle
                    percentages[not_del1] = random.Next(50);
                    percentages[not_del2] = random.Next(50);
                    //add reliability
                    percentages[2] += reliability;
                    Scale_2_to_100(ref percentages);
                }
                else if (choice4d_btn.Text != "" && correct_answer == choice4d_btn.Text.Substring(2))//4th buttton is correct => increase votes of 4th choice
                {
                    //randomize & shuffle
                    percentages[not_del1] = random.Next(50);
                    percentages[not_del2] = random.Next(50);
                    //add reliability
                    percentages[3] += reliability;
                    Scale_2_to_100(ref percentages);
                }

            }
            else
            {
                if (choice1a_btn.Text != "" && correct_answer == choice1a_btn.Text.Substring(2))//1st buttton is correct => increase votes of 1st choice
                {
                    //randomize & shuffle
                    percentages[0] = random.Next(25);
                    percentages[1] = random.Next(25);
                    percentages[2] = random.Next(25);
                    percentages[3] = random.Next(25);
                    ShuffleArray(percentages);
                    //add reliability
                    percentages[0] += reliability;
                    Scale_4_to_100(ref percentages);

                }
                else if (choice2b_btn.Text != "" && correct_answer == choice2b_btn.Text.Substring(2))//2nd buttton is correct => increase votes of 2nd choice
                {
                    //randomize & shuffle
                    percentages[0] = random.Next(25);
                    percentages[1] = random.Next(25);
                    percentages[2] = random.Next(25);
                    percentages[3] = random.Next(25);
                    ShuffleArray(percentages);
                    //add reliability
                    percentages[1] += reliability;
                    Scale_4_to_100(ref percentages);
                }
                else if (choice3c_btn.Text != "" && correct_answer == choice3c_btn.Text.Substring(2))//3rd buttton is correct => increase votes of 3rd choice
                {
                    //randomize & shuffle
                    percentages[0] = random.Next(25);
                    percentages[1] = random.Next(25);
                    percentages[2] = random.Next(25);
                    percentages[3] = random.Next(25);
                    ShuffleArray(percentages);
                    //add reliability
                    percentages[2] += reliability;
                    Scale_4_to_100(ref percentages);
                }
                else if (choice4d_btn.Text != "" && correct_answer == choice4d_btn.Text.Substring(2))//4th buttton is correct => increase votes of 4th choice
                {
                    //randomize & shuffle
                    percentages[0] = random.Next(25);
                    percentages[1] = random.Next(25);
                    percentages[2] = random.Next(25);
                    percentages[3] = random.Next(25);
                    ShuffleArray(percentages);
                    //add reliability
                    percentages[3] += reliability;
                    Scale_4_to_100(ref percentages);
                }
            }
            return percentages;
        }

        private void ShuffleArray<T>(T[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                (array[randomIndex], array[i]) = (array[i], array[randomIndex]);
            }
        }

        private async void People_help_btn_Click(object sender, EventArgs e)
        {
            people_help_btn.Hide();
            x_people_help_btn.Show();
            int[] votes = GenerateRandomReliablePercentages();

            //adjust some chart properties
            var xAxis = people_chart.ChartAreas[0].AxisX;
            xAxis.Maximum = 4.5;
            xAxis.CustomLabels.Clear();
            int i = 0;
            people_help_btn.BackColor = Color.DarkOrange;
            Cursor = Cursors.No;
            this.Enabled = false;
            Cursor = Cursors.Default;
            people_help_btn.BackColor = Color.Transparent;
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.people_opinion);
                player.Play();
            }
            await Task.Delay(7500); // Wait for 7.5 seconds

            people_chart.Show();
            for (int j = 0; j < 20; j++)
            {
                UpdateChartSeriesData();
                await Task.Delay(500); // Wait for 1 seconds
            }
            if (helper.Language == "arabic")
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
                    point.Label = votes[i].ToString() + "٪";
                    i++;
                }
            }
            else if (helper.Language == "english")
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
                    point.Label = votes[i].ToString() + "%";
                    i++;
                }
            }
            this.Enabled = true;
            await Task.Delay(1500);
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.thinking);
                player.Play();
            }
        }

        private async void Help_Call_Friend_btn_Click(object sender, EventArgs e)
        {
            //not added yet
            help_call_btn.Hide();
            x_help_call_btn.Show();
            this.Enabled = false;
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.call_friend_intro);
                player.Play();
            }
            await Task.Delay(11000);
            CallFriendForm callFriendForm = new CallFriendForm(helper, GenerateRandomReliablePercentages());
            Hide();
            callFriendForm.ShowDialog();
            Show();
            this.Enabled = true;

            if (helper.IsSoundOn && player.SoundLocation == null)
            {
                player = new SoundPlayer(Properties.Resources.thinking);
                player.Play();
            }
        }

        private void Withdraw_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (helper.Language == "arabic")
            {
                result = MessageBox.Show("عايز تنسحب اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (helper.Language == "english")
            {
                result = MessageBox.Show("Are you sure you want to withdraw?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (result == DialogResult.Yes)
            {
                ResultForm resultForm = new ResultForm(helper, money[money_index], money_index, num_of_questions);
                resultForm.ShowDialog();
                money_index = 0;
                Close();
            }
        }

        private void Auto_Open_Result_Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
            ResultForm resultForm = new ResultForm(helper, money[money_index], money_index, num_of_questions);
            money_index = 0;
            resultForm.ShowDialog();
        }

        private void GaneForm_Paint(object sender, PaintEventArgs e)
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
            //handle helper.Language
            if (helper.Language == "arabic")
                result = MessageBox.Show("عايز تخرج من اللعبة اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            else if (helper.Language == "english")
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
            //handle helper.Language
            if (helper.Language == "arabic")
                result = MessageBox.Show("عايز ترجع للشاشة الرئيسية اكيد؟", "بتأكد بس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            else if (helper.Language == "english")
                result = MessageBox.Show("Are you sure you want to go to Home Screen?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //close this form if 'yes' choosed
            if (result == DialogResult.Yes)
                Close();
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

        private void Zoom_in_btn_Click(object sender, EventArgs e)
        {
            this.Scale(new SizeF(1.1f, 1.1f));
            //label17.Text = this.Size.ToString();
            DialogResult result1 = DialogResult.No;

            //handle helper.Language
            if (helper.Language == "arabic")
                result1 = MessageBox.Show("حجم الشاشة مع اللعبة مظبوط؟", "ايه رأيك؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else if (helper.Language == "english")
                result1 = MessageBox.Show("The game fits the screen?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //do nothing if 'yes' choosed
            if (result1 == DialogResult.No)
            {
                this.Scale(new SizeF(0.9f, 0.9f));//(1.0f / 1.1f, 1.0f / 1.1f));//(1.0f + (1.0f - 1.1f), 1.0f + (1.0f - 1.1f)));//
                //label17.Text = this.Size.ToString();
            }
        }

        private void Zoom_out_btn_Click(object sender, EventArgs e)
        {
            this.Scale(new SizeF(0.9f, 0.9f));

            DialogResult result1 = DialogResult.No;

            //handle helper.Language
            if (helper.Language == "arabic")
                result1 = MessageBox.Show("حجم الشاشة مع اللعبة مظبوط؟", "ايه رأيك؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else if (helper.Language == "english")
                result1 = MessageBox.Show("The game fits the screen?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //do nothing if 'yes' choosed
            if (result1 == DialogResult.No)
                this.Scale(new SizeF(1.1f, 1.1f));

        }

        //private void MoveControlsUpAndLeft()
        //{
        //    foreach (Control control in Controls)
        //    {
        //        Point newLocation = new Point(control.Location.X - 150, control.Location.Y - 70);
        //        //Point newLocation = new Point(0, 0);
        //        control.Location = newLocation;
        //    }
        //}
        //private void MoveControlsDownAndRight()
        //{
        //    foreach (Control control in Controls)
        //    {
        //        Point newLocation = new Point(control.Location.X + 150, control.Location.Y + 70);
        //        control.Location = newLocation;
        //    }
        //}

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            money_index = 0;
            if (helper.IsSoundOn)
                player.Stop();
        }

        private async void Change_Question()
        {
            //add some suspense(wait before change the question)
            switch (money_index)
            {
                case 0:
                    await Task.Delay(2000); // Wait for 2 seconds
                    break;
                case 1:
                    await Task.Delay(6000); // Wait for 6 seconds
                    break;
                case 2:
                    await Task.Delay(6000); // Wait for 6 seconds
                    break;
                case 3:
                    await Task.Delay(11000); // Wait for 11 seconds
                    break;
                case 4:
                    await Task.Delay(13000); // Wait for 13 seconds
                    break;
                case 5:
                    await Task.Delay(10000); // Wait for 10 seconds
                    break;
                case 6:
                    await Task.Delay(13000); // Wait for 13 seconds
                    break;
                case 7:
                    await Task.Delay(15000); // Wait for 15 seconds
                    break;
                case 8:
                    await Task.Delay(16500); // Wait for 16.5 seconds
                    break;
                case 9:
                    await Task.Delay(9000); // Wait for 9 seconds
                    break;
                case 10:
                    await Task.Delay(16500); // Wait for 16.5 seconds
                    break;
                case 11:
                    await Task.Delay(16500); // Wait for 16.5 seconds
                    break;
                case 12:
                    await Task.Delay(18500); // Wait for 18.5 seconds
                    break;
                case 13:
                    await Task.Delay(21500); // Wait for 21.5 seconds
                    break;
                case 14:
                    await Task.Delay(19000); // Wait for 19 seconds
                    break;
                default:
                    break;
            }

            //reset backcolor after changing it by clicking choice button
            choice1a_btn.BackColor = Color.Transparent;
            choice2b_btn.BackColor = Color.Transparent;
            choice3c_btn.BackColor = Color.Transparent;
            choice4d_btn.BackColor = Color.Transparent;
            //generate random question id(row number)
            do
            {
                row = random.Next(0, 30);
            } while (row_values.Contains(row));//if it's repeated question then don't take it(repeat until we find unrepeated question)
            correct_answer = dataSet.Tables[sheet_index].Rows[row][1].ToString();//the correct choice is always in column1
            row_values.Add(row);//memorize choosen question to eliminate repeatition
            //end of questions
            if (row > dataSet.Tables[sheet_index].Rows.Count || money_index == money.Length - 1)
            {
                //won the million
                await Task.Delay(1000); // Wait for 1 seconds
                if (helper.IsSoundOn)
                {
                    player = new SoundPlayer(Properties.Resources._1000000);
                    player.Play();
                }
                await Task.Delay(8000); // Wait for 8 seconds
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
                await Task.Delay(400); // Wait for .4 seconds
                label15.BackColor = Color.LightGreen;
                await Task.Delay(13000); // Wait for 13 seconds
                //close ShowDataForm first if it is opened
                if (Application.OpenForms["ShowDataForm"] != null)
                {
                    ShowDataForm dataForm = (ShowDataForm)Application.OpenForms["ShowDataForm"];
                    dataForm.Close();
                }
                ResultForm resultForm = new ResultForm(helper, money[money_index], money_index, num_of_questions);
                money_index = 0;
                Close();
                resultForm.ShowDialog();
            }

            //else
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.thinking);
                player.PlayLooping();
            }

            Question_txt.Text = dataSet.Tables[sheet_index].Rows[row][0].ToString();
            if (helper.Language == "arabic")
            {
                choice1a_btn.RightToLeft = RightToLeft.Yes;
                choice2b_btn.RightToLeft = RightToLeft.Yes;
                choice3c_btn.RightToLeft = RightToLeft.Yes;
                choice4d_btn.RightToLeft = RightToLeft.Yes;
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "أ-" + dataSet.Tables[sheet_index].Rows[row][choice1].ToString();
                choice2b_btn.Text = "ب-" + dataSet.Tables[sheet_index].Rows[row][choice2].ToString();
                choice3c_btn.Text = "ج-" + dataSet.Tables[sheet_index].Rows[row][choice3].ToString();
                choice4d_btn.Text = "د-" + dataSet.Tables[sheet_index].Rows[row][choice4].ToString();
            }
            else if (helper.Language == "english")
            {
                choice1a_btn.RightToLeft = RightToLeft.No;
                choice2b_btn.RightToLeft = RightToLeft.No;
                choice3c_btn.RightToLeft = RightToLeft.No;
                choice4d_btn.RightToLeft = RightToLeft.No;
                GenerateRandomChoices(out choice1, out choice2, out choice3, out choice4);
                choice1a_btn.Text = "a-" + dataSet.Tables[sheet_index].Rows[row][choice1].ToString();
                choice2b_btn.Text = "b-" + dataSet.Tables[sheet_index].Rows[row][choice2].ToString();
                choice3c_btn.Text = "c-" + dataSet.Tables[sheet_index].Rows[row][choice3].ToString();
                choice4d_btn.Text = "d-" + dataSet.Tables[sheet_index].Rows[row][choice4].ToString();
            }
            //enable all choices buttons after 2 of them are disabled by 50:50 button
            if (helper.IsHelp50Used)
            {
                choice1a_btn.Enabled = true; choice2b_btn.Enabled = true; choice3c_btn.Enabled = true; choice4d_btn.Enabled = true;
                helper.IsHelp50Used = false;
            }
            //this.Enabled = true;
            choice1a_btn.Enabled = true;
            choice2b_btn.Enabled = true;
            choice3c_btn.Enabled = true;
            choice4d_btn.Enabled = true;
            //Exit_btn.Enabled = true;
            Leave_btn.Enabled = true;
            withdraw_btn.Enabled = true;
            help_50_50_btn.Enabled = true;
            people_help_btn.Enabled = true;
            help_call_btn.Enabled = true;
            Help_Show_All_btn.Enabled = true;
            people_chart.Hide();
            money_label.Hide();
            money_panel20.Hide();
            money_panel40.Hide();
            money_panel50.Hide();
            money_panel60.Hide();
            money_panel80.Hide();
        }

        private void Help_Show_All_btn_MouseHover(object sender, EventArgs e)
        {

        }

        private async void Change_money_Color(int money_index)
        {
            switch (money_index)
            {
                case 0://change question delay = 2sec
                    label1.BackColor = Color.Orange;
                    break;
                case 1://change question delay = 6sec
                    await Task.Delay(1000); // Wait for 1 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._100);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label1.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label1.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label1.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label1.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label1.BackColor = Color.Transparent;
                    label2.BackColor = Color.DarkOrange;
                    break;
                case 2://change question delay = 6sec
                    await Task.Delay(1000); // Wait for 1 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._200);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label2.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label2.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label2.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label2.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label2.BackColor = Color.Transparent;
                    label3.BackColor = Color.DarkOrange;
                    break;
                case 3://change question delay = 12sec
                    await Task.Delay(2000); // Wait for 2 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._300_next_500);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label3.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label3.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label3.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label3.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label3.BackColor = Color.Transparent;
                    label4.BackColor = Color.DarkOrange;
                    break;
                case 4://change question delay = 13sec
                    await Task.Delay(3000); // Wait for 3 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._500_next_1000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label4.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label4.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label4.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label4.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label4.BackColor = Color.Transparent;
                    label5.BackColor = Color.DarkOrange;
                    break;
                case 5://change question delay = 10sec
                    await Task.Delay(3000); // Wait for 3 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._1000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label5.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label5.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label5.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label5.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label5.BackColor = Color.Transparent;
                    label6.BackColor = Color.DarkOrange;
                    break;
                case 6://change question delay = 13sec
                    await Task.Delay(3000); // Wait for 3 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._2000_next_4000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label6.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label6.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label6.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label6.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label6.BackColor = Color.Transparent;
                    label7.BackColor = Color.DarkOrange;
                    break;
                case 7://change question delay = 15sec
                    await Task.Delay(3000); // Wait for 3 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._4000_next_8000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label7.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label7.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label7.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label7.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label7.BackColor = Color.Transparent;
                    label8.BackColor = Color.DarkOrange;
                    break;
                case 8://change question delay = 16.5sec
                    await Task.Delay(3500); // Wait for 3.5 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._8000_next_16000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label8.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label8.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label8.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label8.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label8.BackColor = Color.Transparent;
                    label9.BackColor = Color.DarkOrange;
                    break;
                case 9://change question delay = 9sec
                    await Task.Delay(3500); // Wait for 3.5 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._16000_next_32000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label9.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label9.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label9.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label9.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label9.BackColor = Color.Transparent;
                    label10.BackColor = Color.DarkOrange;
                    break;
                case 10://change question delay = 16.5sec
                    await Task.Delay(3500); // Wait for 3.5 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._32000_next_64000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label10.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label10.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label10.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label10.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label10.BackColor = Color.Transparent;
                    label11.BackColor = Color.DarkOrange;
                    break;
                case 11://change question delay = 16.5sec
                    await Task.Delay(3500); // Wait for 3.5 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._64000_next_125000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label11.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label11.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label11.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label11.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label11.BackColor = Color.Transparent;
                    label12.BackColor = Color.DarkOrange;
                    break;
                case 12://change question delay = 18.5sec
                    await Task.Delay(3500); // Wait for 3.5 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._125000_next_250000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label12.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label12.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label12.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label12.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label12.BackColor = Color.Transparent;
                    label13.BackColor = Color.DarkOrange;
                    break;
                case 13://change question delay = 21.5sec
                    await Task.Delay(3000); // Wait for 3 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._250000_next_500000);
                        player.Play();
                    }
                    await Task.Delay(4000); // Wait for 4 seconds
                    label13.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label13.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label13.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label13.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label13.BackColor = Color.Transparent;
                    label14.BackColor = Color.DarkOrange;
                    break;
                case 14://change question delay = 19sec
                    await Task.Delay(3500); // Wait for 3.5 seconds
                    if (helper.IsSoundOn)
                    {
                        player = new SoundPlayer(Properties.Resources._500000_next_1000000);
                        player.Play();
                    }
                    await Task.Delay(500); // Wait for .5 seconds
                    label14.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label14.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
                    label14.BackColor = Color.Green;
                    await Task.Delay(500); // Wait for .5 seconds
                    label14.BackColor = Color.Orange;
                    await Task.Delay(500); // Wait for .5 seconds
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
            if (helper.IsSoundOn)
            {
                player = new SoundPlayer(Properties.Resources.wrong_answer);
                player.Play();
            }
            await Task.Delay(6000); // Wait for additional 6 seconds
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
                await Task.Delay(500); // Wait for .5 seconds
                choice1a_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice1a_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice1a_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice1a_btn.BackColor = Color.Green;
            }
            else if (choice2b_btn.Text != "" && correct_answer == choice2b_btn.Text.Substring(2))
            {
                choice2b_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice2b_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice2b_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice2b_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice2b_btn.BackColor = Color.Green;
            }
            else if (choice3c_btn.Text != "" && correct_answer == choice3c_btn.Text.Substring(2))
            {
                choice3c_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice3c_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice3c_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice3c_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice3c_btn.BackColor = Color.Green;
            }
            else if (choice4d_btn.Text != "" && correct_answer == choice4d_btn.Text.Substring(2))
            {
                choice4d_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice4d_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
                choice4d_btn.BackColor = Color.Green;
                await Task.Delay(500); // Wait for .5 seconds
                choice4d_btn.BackColor = Color.LightGreen;
                await Task.Delay(500); // Wait for .5 seconds
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
            bool flag = false;
            if (money_index == 5)
            {
                await Task.Delay(3000);
                flag = true;
            }
            else if (money_index == 9)
            {
                await Task.Delay(3500);
                flag = true;
            }
            else if (money_index >= 12)
            {
                if (money_index == money.Length - 1)//million
                    await Task.Delay(9000);
                else
                    await Task.Delay(5000);
                flag = true;
            }
            Show_Money_Panel(flag);
        }

        private async void Show_Money_Panel(bool flag)
        {
            if (flag)
            {
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
}
