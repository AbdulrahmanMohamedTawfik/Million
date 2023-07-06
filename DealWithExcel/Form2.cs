using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealWithExcel
{
    public partial class Form2 : Form
    {
        private string language;
        public Form2(string lang)
        {
            InitializeComponent();
            language = lang;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (language == "arabic")
                LoadExcelFile("Data\\AllArabicData.xlsx");
            else if (language == "english")

                LoadExcelFile("Data\\AllEnglishData.xlsx");
            else
                MessageBox.Show("Error:not specified language");
        }
        private void LoadExcelFile(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet dataSet = reader.AsDataSet();
                    DataTable dataTable = dataSet.Tables[0]; // Assuming the first sheet is of interest
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
