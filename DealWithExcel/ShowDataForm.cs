using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MillionLE
{
    public partial class ShowDataForm : Form
    {
        private string language;
        private int sheet_index = 0;
        public ShowDataForm(string lang, int sheet_i)
        {
            InitializeComponent();
            language = lang;
            sheet_index = sheet_i;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //form appears in left half
            Rectangle screenRectangle = Screen.PrimaryScreen.WorkingArea;
            int leftHalfWidth = screenRectangle.Width / 2;
            this.Location = new Point(screenRectangle.Left, screenRectangle.Top);
            this.Size = new Size(leftHalfWidth - 120, screenRectangle.Height);
            //handle language
            dataGridView1.Columns.Clear();
            if (language == "arabic")
            {
                dataGridView1.RightToLeft = RightToLeft.Yes;
                dataGridView1.Columns.Add("Column0", "السؤال");
                dataGridView1.Columns.Add("Column1", "الإجابة");
                LoadExcelFile("Data\\AllArabicData.xlsx");
            }
            else if (language == "english")
            {
                dataGridView1.RightToLeft = RightToLeft.No;
                dataGridView1.Columns.Add("Column0", "Question");
                dataGridView1.Columns.Add("Column1", "Answer");
                LoadExcelFile("Data\\AllEnglishData.xlsx");
            }
            else
                MessageBox.Show("Error: not specified language");
        }

        private void LoadExcelFile(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { Password = "iwonmillion" }))
                {
                    DataSet dataSet = reader.AsDataSet();
                    DataTable dataTable = dataSet.Tables[sheet_index];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string column1Value = row["Column0"].ToString();
                        string column2Value = row["Column1"].ToString();

                        dataGridView1.Rows.Add(column1Value, column2Value);
                    }
                }
            }
        }
    }
}
