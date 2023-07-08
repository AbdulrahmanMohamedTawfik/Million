using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DealWithExcel
{
    public partial class MainForm : Form
    {
        private int Difficulty;
        public string language;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(language, Difficulty);
            f.Show();
            //Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void easy_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 15;
            Start_btn.BackColor = Color.LightGreen;
        }

        private void med_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 25;
            Start_btn.BackColor = Color.DeepSkyBlue;
        }

        private void hard_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 30;
            Start_btn.BackColor = Color.LightCoral;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            easy_rad_btn.Checked = true;
            en_radioButton.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void en_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            language = "english";
            lang_groupBox.Text = "Coose Language:";
            Start_btn.Text = "Start";
            difficulty_groupBox.Text = "Choose Difficulty:";
            easy_rad_btn.Text = "Easy";
            med_rad_btn.Text = "Medium";
            hard_rad_btn.Text = "Hard";
            difficulty_groupBox.RightToLeft = RightToLeft.No;
        }

        private void ar_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            language = "arabic";
            lang_groupBox.Text = ":اختر اللغة";
            Start_btn.Text = "ابدأ";
            difficulty_groupBox.Text = ":اختر مستوى الصعوبة";
            easy_rad_btn.Text = "سهل";
            med_rad_btn.Text = "متوسط";
            hard_rad_btn.Text = "صعب";
            difficulty_groupBox.RightToLeft = RightToLeft.Yes;
        }

        private void lang_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void difficulty_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_Leave(object sender, EventArgs e)
        {

        }
    }
}
