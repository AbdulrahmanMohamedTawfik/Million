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
using ExcelDataReader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DealWithExcel
{
    public partial class Form1 : Form
    {
        private int Difficulty;
        private string language;
        public Form1(string lang, int DifficultyValue = 15)
        {
            InitializeComponent();
            Difficulty = DifficultyValue;
            language = lang;
        }

        static String EnglishfilePath = "Data\\EnglishData.xlsx";
        static String ArabicfilePath = "Data\\ArabicData.xlsx";
        Stream stream;
        IExcelDataReader reader;
        DataSet dataSet;
        DataTable dataTable;
        public int score = 0;
        static int row = 1, col = 0, num_of_questions = 10, decreasing_couner = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            decreasing_couner = num_of_questions;
            Random random = new Random();
            row = random.Next(Difficulty - 14, Difficulty);
            if (language == "arabic")
            {
                Show_All_btn.Text = "رؤية كل الاسئلة";
                stream = File.Open(ArabicfilePath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateReader(stream);
                dataSet = reader.AsDataSet();
                dataTable = dataSet.Tables[0];
            }
            else if (language == "english")
            {
                Show_All_btn.Text = "Show All Questions";
                stream = File.Open(EnglishfilePath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateReader(stream);
                dataSet = reader.AsDataSet();
                dataTable = dataSet.Tables[0];
            }
            Question_txt.Text = dataSet.Tables[0].Rows[row][col].ToString();
            choice1a_btn.Text = dataSet.Tables[0].Rows[row][col + 1].ToString();
            choice2b_btn.Text = dataSet.Tables[0].Rows[row][col + 2].ToString();
            choice3c_btn.Text = dataSet.Tables[0].Rows[row][col + 3].ToString();
            choice4d_btn.Text = dataSet.Tables[0].Rows[row][col + 4].ToString();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
        }

        private void Show_All_btn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(language);
            form2.Show();
        }

        private void choice1a_btn_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows[row][col + 5].ToString() == "a")
            {
                status_txt.Text = "Correct";
                status_txt.ForeColor = Color.Green;
                score++;
            }
            else
            {
                status_txt.Text = "Not Correct";
                status_txt.ForeColor = Color.Red;
            }
            Change_Question();
        }

        private void choice2b_btn_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows[row][col + 5].ToString() == "b")
            {
                status_txt.Text = "Correct";
                status_txt.ForeColor = Color.Green;
                score++;
            }
            else
            {
                status_txt.Text = "Not Correct";
                status_txt.ForeColor = Color.Red;
            }
            Change_Question();
        }

        private void choice3c_btn_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows[row][col + 5].ToString() == "c")
            {
                status_txt.Text = "Correct";
                status_txt.ForeColor = Color.Green;
                score++;
            }
            else
            {
                status_txt.Text = "Not Correct";
                status_txt.ForeColor = Color.Red;
            }
            Change_Question();
        }

        private void choice4d_btn_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows[row][col + 5].ToString() == "d")
            {
                status_txt.Text = "Correct";
                status_txt.ForeColor = Color.Green;
                score++;
            }
            else
            {
                status_txt.Text = "Not Correct";
                status_txt.ForeColor = Color.Red;
            }
            Change_Question();
        }
        private void Change_Question()
        {
            Random random = new Random();
            int last_row_value = row;
            do
            {                                                  //Easy ,  Med  , Hard
                row = random.Next(Difficulty - 14, Difficulty);//1:15 , 11:25 , 16:30
            } while (row == last_row_value);
            if (row < dataSet.Tables[0].Rows.Count && decreasing_couner > 1)
            {
                Question_txt.Text = dataSet.Tables[0].Rows[row][col].ToString();
                choice1a_btn.Text = dataSet.Tables[0].Rows[row][col + 1].ToString();
                choice2b_btn.Text = dataSet.Tables[0].Rows[row][col + 2].ToString();
                choice3c_btn.Text = dataSet.Tables[0].Rows[row][col + 3].ToString();
                choice4d_btn.Text = dataSet.Tables[0].Rows[row][col + 4].ToString();
                decreasing_couner--;
            }
            else
            {
                ResultForm resultForm = new ResultForm(language, score, num_of_questions);
                resultForm.ShowDialog();
                decreasing_couner = num_of_questions;
                score = 0;
                Close();
            }

        }

    }
}
