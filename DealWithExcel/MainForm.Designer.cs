namespace MillionLE
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Start_btn = new System.Windows.Forms.Button();
            this.easy_rad_btn = new System.Windows.Forms.RadioButton();
            this.med_rad_btn = new System.Windows.Forms.RadioButton();
            this.hard_rad_btn = new System.Windows.Forms.RadioButton();
            this.difficulty_groupBox = new System.Windows.Forms.GroupBox();
            this.lang_groupBox = new System.Windows.Forms.GroupBox();
            this.ar_pictureBox = new System.Windows.Forms.PictureBox();
            this.en_pictureBox = new System.Windows.Forms.PictureBox();
            this.ar_radioButton = new System.Windows.Forms.RadioButton();
            this.en_radioButton = new System.Windows.Forms.RadioButton();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.Sound_btn = new System.Windows.Forms.Button();
            this.Intro_btn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.difficulty_groupBox.SuspendLayout();
            this.lang_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ar_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.en_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_btn
            // 
            this.Start_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Start_btn.BackColor = System.Drawing.Color.Transparent;
            this.Start_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start_btn.BackgroundImage")));
            this.Start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Start_btn.FlatAppearance.BorderSize = 0;
            this.Start_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.Start_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGreen;
            this.Start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_btn.ForeColor = System.Drawing.Color.Transparent;
            this.Start_btn.Location = new System.Drawing.Point(392, 284);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(196, 67);
            this.Start_btn.TabIndex = 0;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = false;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // easy_rad_btn
            // 
            this.easy_rad_btn.AutoSize = true;
            this.easy_rad_btn.BackColor = System.Drawing.Color.Transparent;
            this.easy_rad_btn.ForeColor = System.Drawing.Color.LightGreen;
            this.easy_rad_btn.Location = new System.Drawing.Point(67, 50);
            this.easy_rad_btn.Name = "easy_rad_btn";
            this.easy_rad_btn.Size = new System.Drawing.Size(102, 40);
            this.easy_rad_btn.TabIndex = 1;
            this.easy_rad_btn.TabStop = true;
            this.easy_rad_btn.Text = "Easy";
            this.easy_rad_btn.UseVisualStyleBackColor = false;
            this.easy_rad_btn.CheckedChanged += new System.EventHandler(this.Easy_rad_btn_CheckedChanged);
            // 
            // med_rad_btn
            // 
            this.med_rad_btn.AutoSize = true;
            this.med_rad_btn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.med_rad_btn.Location = new System.Drawing.Point(185, 50);
            this.med_rad_btn.Name = "med_rad_btn";
            this.med_rad_btn.Size = new System.Drawing.Size(141, 40);
            this.med_rad_btn.TabIndex = 2;
            this.med_rad_btn.TabStop = true;
            this.med_rad_btn.Text = "Medium";
            this.med_rad_btn.UseVisualStyleBackColor = true;
            this.med_rad_btn.CheckedChanged += new System.EventHandler(this.Med_rad_btn_CheckedChanged);
            // 
            // hard_rad_btn
            // 
            this.hard_rad_btn.AutoSize = true;
            this.hard_rad_btn.ForeColor = System.Drawing.Color.LightCoral;
            this.hard_rad_btn.Location = new System.Drawing.Point(344, 50);
            this.hard_rad_btn.Name = "hard_rad_btn";
            this.hard_rad_btn.Size = new System.Drawing.Size(100, 40);
            this.hard_rad_btn.TabIndex = 3;
            this.hard_rad_btn.TabStop = true;
            this.hard_rad_btn.Text = "Hard";
            this.hard_rad_btn.UseVisualStyleBackColor = true;
            this.hard_rad_btn.CheckedChanged += new System.EventHandler(this.Hard_rad_btn_CheckedChanged);
            // 
            // difficulty_groupBox
            // 
            this.difficulty_groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.difficulty_groupBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.difficulty_groupBox.Controls.Add(this.hard_rad_btn);
            this.difficulty_groupBox.Controls.Add(this.easy_rad_btn);
            this.difficulty_groupBox.Controls.Add(this.med_rad_btn);
            this.difficulty_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficulty_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty_groupBox.ForeColor = System.Drawing.Color.White;
            this.difficulty_groupBox.Location = new System.Drawing.Point(207, 105);
            this.difficulty_groupBox.Name = "difficulty_groupBox";
            this.difficulty_groupBox.Size = new System.Drawing.Size(636, 164);
            this.difficulty_groupBox.TabIndex = 4;
            this.difficulty_groupBox.TabStop = false;
            this.difficulty_groupBox.Text = "Choose Difficulty:";
            // 
            // lang_groupBox
            // 
            this.lang_groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lang_groupBox.Controls.Add(this.ar_pictureBox);
            this.lang_groupBox.Controls.Add(this.en_pictureBox);
            this.lang_groupBox.Controls.Add(this.ar_radioButton);
            this.lang_groupBox.Controls.Add(this.en_radioButton);
            this.lang_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lang_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lang_groupBox.ForeColor = System.Drawing.Color.White;
            this.lang_groupBox.Location = new System.Drawing.Point(363, 410);
            this.lang_groupBox.Name = "lang_groupBox";
            this.lang_groupBox.Size = new System.Drawing.Size(255, 127);
            this.lang_groupBox.TabIndex = 7;
            this.lang_groupBox.TabStop = false;
            this.lang_groupBox.Text = "Language";
            // 
            // ar_pictureBox
            // 
            this.ar_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ar_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ar_pictureBox.Image")));
            this.ar_pictureBox.Location = new System.Drawing.Point(127, 35);
            this.ar_pictureBox.Name = "ar_pictureBox";
            this.ar_pictureBox.Size = new System.Drawing.Size(33, 21);
            this.ar_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ar_pictureBox.TabIndex = 3;
            this.ar_pictureBox.TabStop = false;
            // 
            // en_pictureBox
            // 
            this.en_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.en_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("en_pictureBox.Image")));
            this.en_pictureBox.Location = new System.Drawing.Point(146, 78);
            this.en_pictureBox.Name = "en_pictureBox";
            this.en_pictureBox.Size = new System.Drawing.Size(33, 20);
            this.en_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.en_pictureBox.TabIndex = 2;
            this.en_pictureBox.TabStop = false;
            // 
            // ar_radioButton
            // 
            this.ar_radioButton.ForeColor = System.Drawing.Color.White;
            this.ar_radioButton.Location = new System.Drawing.Point(53, 25);
            this.ar_radioButton.Name = "ar_radioButton";
            this.ar_radioButton.Size = new System.Drawing.Size(107, 38);
            this.ar_radioButton.TabIndex = 1;
            this.ar_radioButton.TabStop = true;
            this.ar_radioButton.Text = "العربية";
            this.ar_radioButton.UseVisualStyleBackColor = true;
            this.ar_radioButton.CheckedChanged += new System.EventHandler(this.Ar_radioButton_CheckedChanged);
            // 
            // en_radioButton
            // 
            this.en_radioButton.ForeColor = System.Drawing.Color.White;
            this.en_radioButton.Location = new System.Drawing.Point(53, 69);
            this.en_radioButton.Name = "en_radioButton";
            this.en_radioButton.Size = new System.Drawing.Size(107, 38);
            this.en_radioButton.TabIndex = 0;
            this.en_radioButton.TabStop = true;
            this.en_radioButton.Text = "English";
            this.en_radioButton.UseVisualStyleBackColor = true;
            this.en_radioButton.CheckedChanged += new System.EventHandler(this.En_radioButton_CheckedChanged);
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit_btn.BackgroundImage")));
            this.Exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit_btn.FlatAppearance.BorderSize = 0;
            this.Exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.Exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn.ForeColor = System.Drawing.Color.Transparent;
            this.Exit_btn.Location = new System.Drawing.Point(12, 12);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(58, 46);
            this.Exit_btn.TabIndex = 8;
            this.Exit_btn.UseVisualStyleBackColor = false;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Sound_btn
            // 
            this.Sound_btn.BackColor = System.Drawing.Color.Transparent;
            this.Sound_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sound_btn.BackgroundImage")));
            this.Sound_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sound_btn.FlatAppearance.BorderSize = 0;
            this.Sound_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Sound_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sound_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sound_btn.ForeColor = System.Drawing.Color.Transparent;
            this.Sound_btn.Location = new System.Drawing.Point(92, 12);
            this.Sound_btn.Name = "Sound_btn";
            this.Sound_btn.Size = new System.Drawing.Size(58, 46);
            this.Sound_btn.TabIndex = 34;
            this.Sound_btn.Tag = "";
            this.Sound_btn.UseVisualStyleBackColor = false;
            this.Sound_btn.Click += new System.EventHandler(this.Sound_btn_Click);
            // 
            // Intro_btn
            // 
            this.Intro_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Intro_btn.BackColor = System.Drawing.Color.Transparent;
            this.Intro_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Intro_btn.ForeColor = System.Drawing.Color.White;
            this.Intro_btn.Location = new System.Drawing.Point(12, 548);
            this.Intro_btn.Name = "Intro_btn";
            this.Intro_btn.Size = new System.Drawing.Size(109, 34);
            this.Intro_btn.TabIndex = 35;
            this.Intro_btn.Text = "intro";
            this.Intro_btn.UseVisualStyleBackColor = false;
            this.Intro_btn.Click += new System.EventHandler(this.Intro_btn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(392, 357);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(196, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 36;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(967, 594);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Intro_btn);
            this.Controls.Add(this.Sound_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.lang_groupBox);
            this.Controls.Add(this.difficulty_groupBox);
            this.Controls.Add(this.Start_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Game";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.difficulty_groupBox.ResumeLayout(false);
            this.difficulty_groupBox.PerformLayout();
            this.lang_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ar_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.en_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.RadioButton easy_rad_btn;
        private System.Windows.Forms.RadioButton med_rad_btn;
        private System.Windows.Forms.RadioButton hard_rad_btn;
        private System.Windows.Forms.GroupBox difficulty_groupBox;
        private System.Windows.Forms.GroupBox lang_groupBox;
        private System.Windows.Forms.PictureBox en_pictureBox;
        private System.Windows.Forms.RadioButton ar_radioButton;
        private System.Windows.Forms.RadioButton en_radioButton;
        private System.Windows.Forms.PictureBox ar_pictureBox;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Button Sound_btn;
        private System.Windows.Forms.Button Intro_btn;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}