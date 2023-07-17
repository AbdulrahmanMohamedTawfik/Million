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
            bool isForm1Open = Application.OpenForms.OfType<GameForm>().Any();
            if (isForm1Open)
                Hide();
            GameForm f = new GameForm(language, Difficulty);
            f.ShowDialog();
            Show();
        }
        //75 Arabic question
        //60 English question
        private void Easy_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 20;
            Start_btn.FlatAppearance.MouseOverBackColor = Color.LightGreen;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Green;
        }

        private void Med_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 40;
            Start_btn.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Blue;
        }

        private void Hard_rad_btn_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty = 60;
            Start_btn.FlatAppearance.MouseOverBackColor = Color.LightCoral;
            Start_btn.FlatAppearance.MouseDownBackColor = Color.Red;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            easy_rad_btn.Checked = true;
            ar_radioButton.Checked = true;
        }

        private void En_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            language = "english";
            lang_groupBox.Text = "Coose Language:";
            Start_btn.Text = "Start";
            difficulty_groupBox.Text = "Choose Difficulty:";
            lang_groupBox.RightToLeft = RightToLeft.No;
            ar_radioButton.RightToLeft = RightToLeft.No;
            en_radioButton.RightToLeft = RightToLeft.No;
            ar_pictureBox.Location = new Point(100, 30);
            en_pictureBox.Location = new Point(120, 65);
            easy_rad_btn.Text = "Easy";
            med_rad_btn.Text = "Medium";
            hard_rad_btn.Text = "Hard";
            easy_rad_btn.RightToLeft = RightToLeft.No;
            med_rad_btn.RightToLeft = RightToLeft.No;
            hard_rad_btn.RightToLeft = RightToLeft.No;
            easy_rad_btn.Location = new Point(67, 50);
            med_rad_btn.Location = new Point(185, 50);
            hard_rad_btn.Location = new Point(344, 50);
            difficulty_groupBox.RightToLeft = RightToLeft.No;
        }

        private void Ar_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            language = "arabic";
            lang_groupBox.Text = "اختر اللغة:";
            lang_groupBox.RightToLeft = RightToLeft.Yes;
            ar_radioButton.RightToLeft = RightToLeft.Yes;
            en_radioButton.RightToLeft = RightToLeft.Yes;
            ar_pictureBox.Location = new Point(24, 30);
            en_pictureBox.Location = new Point(14, 65);
            Start_btn.Text = "ابدأ";
            difficulty_groupBox.Text = "اختر مستوى الصعوبة:";
            easy_rad_btn.Text = "سهل";
            med_rad_btn.Text = "متوسط";
            hard_rad_btn.Text = "صعب";
            easy_rad_btn.RightToLeft = RightToLeft.Yes;
            med_rad_btn.RightToLeft = RightToLeft.Yes;
            hard_rad_btn.RightToLeft = RightToLeft.Yes;
            easy_rad_btn.Location = new Point(344, 50);
            med_rad_btn.Location = new Point(185, 50);
            hard_rad_btn.Location = new Point(67, 50);
            difficulty_groupBox.RightToLeft = RightToLeft.Yes;
        }


        private void MainForm_Paint(object sender, PaintEventArgs e)
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
    }
}
