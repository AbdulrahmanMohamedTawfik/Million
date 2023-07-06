namespace DealWithExcel
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ar_radioButton = new System.Windows.Forms.RadioButton();
            this.en_radioButton = new System.Windows.Forms.RadioButton();
            this.difficulty_groupBox.SuspendLayout();
            this.lang_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_btn
            // 
            this.Start_btn.BackColor = System.Drawing.Color.Transparent;
            this.Start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_btn.ForeColor = System.Drawing.Color.Transparent;
            this.Start_btn.Location = new System.Drawing.Point(309, 176);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(141, 58);
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
            this.easy_rad_btn.CheckedChanged += new System.EventHandler(this.easy_rad_btn_CheckedChanged);
            // 
            // med_rad_btn
            // 
            this.med_rad_btn.AutoSize = true;
            this.med_rad_btn.ForeColor = System.Drawing.Color.LightBlue;
            this.med_rad_btn.Location = new System.Drawing.Point(185, 50);
            this.med_rad_btn.Name = "med_rad_btn";
            this.med_rad_btn.Size = new System.Drawing.Size(141, 40);
            this.med_rad_btn.TabIndex = 2;
            this.med_rad_btn.TabStop = true;
            this.med_rad_btn.Text = "Medium";
            this.med_rad_btn.UseVisualStyleBackColor = true;
            this.med_rad_btn.CheckedChanged += new System.EventHandler(this.med_rad_btn_CheckedChanged);
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
            this.hard_rad_btn.CheckedChanged += new System.EventHandler(this.hard_rad_btn_CheckedChanged);
            // 
            // difficulty_groupBox
            // 
            this.difficulty_groupBox.BackColor = System.Drawing.Color.Purple;
            this.difficulty_groupBox.Controls.Add(this.hard_rad_btn);
            this.difficulty_groupBox.Controls.Add(this.easy_rad_btn);
            this.difficulty_groupBox.Controls.Add(this.med_rad_btn);
            this.difficulty_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficulty_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty_groupBox.ForeColor = System.Drawing.Color.White;
            this.difficulty_groupBox.Location = new System.Drawing.Point(124, 33);
            this.difficulty_groupBox.Name = "difficulty_groupBox";
            this.difficulty_groupBox.Size = new System.Drawing.Size(581, 137);
            this.difficulty_groupBox.TabIndex = 4;
            this.difficulty_groupBox.TabStop = false;
            this.difficulty_groupBox.Text = "Choose Difficulty:";
            this.difficulty_groupBox.Enter += new System.EventHandler(this.difficulty_groupBox_Enter);
            // 
            // lang_groupBox
            // 
            this.lang_groupBox.Controls.Add(this.pictureBox2);
            this.lang_groupBox.Controls.Add(this.pictureBox1);
            this.lang_groupBox.Controls.Add(this.ar_radioButton);
            this.lang_groupBox.Controls.Add(this.en_radioButton);
            this.lang_groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lang_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lang_groupBox.ForeColor = System.Drawing.Color.White;
            this.lang_groupBox.Location = new System.Drawing.Point(280, 338);
            this.lang_groupBox.Name = "lang_groupBox";
            this.lang_groupBox.Size = new System.Drawing.Size(200, 100);
            this.lang_groupBox.TabIndex = 7;
            this.lang_groupBox.TabStop = false;
            this.lang_groupBox.Text = "Language";
            this.lang_groupBox.Enter += new System.EventHandler(this.lang_groupBox_Enter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(84, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(108, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ar_radioButton
            // 
            this.ar_radioButton.ForeColor = System.Drawing.Color.White;
            this.ar_radioButton.Location = new System.Drawing.Point(19, 56);
            this.ar_radioButton.Name = "ar_radioButton";
            this.ar_radioButton.Size = new System.Drawing.Size(107, 38);
            this.ar_radioButton.TabIndex = 1;
            this.ar_radioButton.TabStop = true;
            this.ar_radioButton.Text = "العربية";
            this.ar_radioButton.UseVisualStyleBackColor = true;
            this.ar_radioButton.CheckedChanged += new System.EventHandler(this.ar_radioButton_CheckedChanged);
            // 
            // en_radioButton
            // 
            this.en_radioButton.ForeColor = System.Drawing.Color.White;
            this.en_radioButton.Location = new System.Drawing.Point(19, 21);
            this.en_radioButton.Name = "en_radioButton";
            this.en_radioButton.Size = new System.Drawing.Size(107, 38);
            this.en_radioButton.TabIndex = 0;
            this.en_radioButton.TabStop = true;
            this.en_radioButton.Text = "English";
            this.en_radioButton.UseVisualStyleBackColor = true;
            this.en_radioButton.CheckedChanged += new System.EventHandler(this.en_radioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lang_groupBox);
            this.Controls.Add(this.difficulty_groupBox);
            this.Controls.Add(this.Start_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.difficulty_groupBox.ResumeLayout(false);
            this.difficulty_groupBox.PerformLayout();
            this.lang_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.RadioButton easy_rad_btn;
        private System.Windows.Forms.RadioButton med_rad_btn;
        private System.Windows.Forms.RadioButton hard_rad_btn;
        private System.Windows.Forms.GroupBox difficulty_groupBox;
        private System.Windows.Forms.GroupBox lang_groupBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton ar_radioButton;
        private System.Windows.Forms.RadioButton en_radioButton;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}