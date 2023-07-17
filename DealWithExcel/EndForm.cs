using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealWithExcel
{
    public partial class EndForm : Form
    {
        private readonly string language;
        public EndForm(string lang)
        {
            InitializeComponent();
            language = lang;
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            if (language == "arabic")
            {
                Written_text.RightToLeft= RightToLeft.Yes;
                string[] Arabic_texts = new string[] { "الاسئلة: عبدالرحمن محمد", "الشكل و التنسيق: عبدالرحمن محمد", "الكود: عبدالرحمن محمد", "شكر خاص للاستاذ: عبدالرحمن محمد" };
                Write_text(Arabic_texts);
            }
            else if (language == "english")
            {
                Written_text.RightToLeft = RightToLeft.No;
                string[] English_texts = new string[] { "Questions: Abdulrahman Mohamed", "UI: Abdulrahman Mohamed", "Code: Abdulrahman Mohamed", "Special Thanks To: Abdulrahman Mohamed" };
                Write_text(English_texts);
            }
        }

        private void Skip_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void Write_text(string [] text)
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
    }
}
