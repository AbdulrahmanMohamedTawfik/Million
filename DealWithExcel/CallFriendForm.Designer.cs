namespace MillionLE
{
    partial class CallFriendForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallFriendForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Written_text = new System.Windows.Forms.TextBox();
            this.Count30pictureBox = new System.Windows.Forms.PictureBox();
            this.Sound_btn = new System.Windows.Forms.Button();
            this.choice3_btn = new System.Windows.Forms.Button();
            this.choice2_btn = new System.Windows.Forms.Button();
            this.choice1_btn = new System.Windows.Forms.Button();
            this.QuestionPictureBox = new System.Windows.Forms.PictureBox();
            this.Skip_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Count30pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Auto_Close_Timer_Tick);
            // 
            // Written_text
            // 
            this.Written_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Written_text.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Written_text.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.Written_text.BackColor = System.Drawing.Color.Black;
            this.Written_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Written_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Written_text.ForeColor = System.Drawing.Color.White;
            this.Written_text.Location = new System.Drawing.Point(135, 40);
            this.Written_text.Multiline = true;
            this.Written_text.Name = "Written_text";
            this.Written_text.ReadOnly = true;
            this.Written_text.Size = new System.Drawing.Size(629, 577);
            this.Written_text.TabIndex = 91;
            this.Written_text.Text = "Answer";
            this.Written_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Count30pictureBox
            // 
            this.Count30pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Count30pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.Count30pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Count30pictureBox.Image")));
            this.Count30pictureBox.Location = new System.Drawing.Point(770, 110);
            this.Count30pictureBox.Name = "Count30pictureBox";
            this.Count30pictureBox.Size = new System.Drawing.Size(325, 185);
            this.Count30pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Count30pictureBox.TabIndex = 90;
            this.Count30pictureBox.TabStop = false;
            // 
            // Sound_btn
            // 
            this.Sound_btn.BackColor = System.Drawing.Color.Transparent;
            this.Sound_btn.BackgroundImage = global::MillionLE.Properties.Resources.sound_on;
            this.Sound_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sound_btn.FlatAppearance.BorderSize = 0;
            this.Sound_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Sound_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sound_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sound_btn.ForeColor = System.Drawing.Color.Transparent;
            this.Sound_btn.Location = new System.Drawing.Point(38, 12);
            this.Sound_btn.Name = "Sound_btn";
            this.Sound_btn.Size = new System.Drawing.Size(58, 46);
            this.Sound_btn.TabIndex = 80;
            this.Sound_btn.UseVisualStyleBackColor = false;
            this.Sound_btn.Click += new System.EventHandler(this.Sound_btn_Click);
            // 
            // choice3_btn
            // 
            this.choice3_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.choice3_btn.BackColor = System.Drawing.Color.Transparent;
            this.choice3_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("choice3_btn.BackgroundImage")));
            this.choice3_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.choice3_btn.FlatAppearance.BorderSize = 0;
            this.choice3_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.choice3_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.choice3_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choice3_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choice3_btn.ForeColor = System.Drawing.Color.White;
            this.choice3_btn.Location = new System.Drawing.Point(598, 521);
            this.choice3_btn.Name = "choice3_btn";
            this.choice3_btn.Size = new System.Drawing.Size(85, 85);
            this.choice3_btn.TabIndex = 79;
            this.choice3_btn.Text = "3";
            this.choice3_btn.UseVisualStyleBackColor = false;
            this.choice3_btn.Click += new System.EventHandler(this.Choice3_btn_Click);
            // 
            // choice2_btn
            // 
            this.choice2_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.choice2_btn.BackColor = System.Drawing.Color.Transparent;
            this.choice2_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("choice2_btn.BackgroundImage")));
            this.choice2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.choice2_btn.FlatAppearance.BorderSize = 0;
            this.choice2_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.choice2_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.choice2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choice2_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choice2_btn.ForeColor = System.Drawing.Color.White;
            this.choice2_btn.Location = new System.Drawing.Point(398, 521);
            this.choice2_btn.Name = "choice2_btn";
            this.choice2_btn.Size = new System.Drawing.Size(85, 85);
            this.choice2_btn.TabIndex = 78;
            this.choice2_btn.Text = "2";
            this.choice2_btn.UseVisualStyleBackColor = false;
            this.choice2_btn.Click += new System.EventHandler(this.Choice2_btn_Click);
            // 
            // choice1_btn
            // 
            this.choice1_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.choice1_btn.BackColor = System.Drawing.Color.Transparent;
            this.choice1_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("choice1_btn.BackgroundImage")));
            this.choice1_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.choice1_btn.FlatAppearance.BorderSize = 0;
            this.choice1_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.choice1_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.choice1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choice1_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choice1_btn.ForeColor = System.Drawing.Color.White;
            this.choice1_btn.Location = new System.Drawing.Point(198, 521);
            this.choice1_btn.Name = "choice1_btn";
            this.choice1_btn.Size = new System.Drawing.Size(85, 85);
            this.choice1_btn.TabIndex = 77;
            this.choice1_btn.Text = "1";
            this.choice1_btn.UseVisualStyleBackColor = false;
            this.choice1_btn.Click += new System.EventHandler(this.Choice1_btn_Click);
            // 
            // QuestionPictureBox
            // 
            this.QuestionPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QuestionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("QuestionPictureBox.Image")));
            this.QuestionPictureBox.Location = new System.Drawing.Point(135, 40);
            this.QuestionPictureBox.Name = "QuestionPictureBox";
            this.QuestionPictureBox.Size = new System.Drawing.Size(629, 419);
            this.QuestionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QuestionPictureBox.TabIndex = 0;
            this.QuestionPictureBox.TabStop = false;
            // 
            // Skip_btn
            // 
            this.Skip_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Skip_btn.BackColor = System.Drawing.Color.Transparent;
            this.Skip_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Skip_btn.ForeColor = System.Drawing.Color.White;
            this.Skip_btn.Location = new System.Drawing.Point(38, 572);
            this.Skip_btn.Name = "Skip_btn";
            this.Skip_btn.Size = new System.Drawing.Size(109, 34);
            this.Skip_btn.TabIndex = 92;
            this.Skip_btn.Text = "Skip";
            this.Skip_btn.UseVisualStyleBackColor = false;
            this.Skip_btn.Click += new System.EventHandler(this.Skip_btn_Click);
            // 
            // CallFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1107, 629);
            this.Controls.Add(this.Skip_btn);
            this.Controls.Add(this.Written_text);
            this.Controls.Add(this.Count30pictureBox);
            this.Controls.Add(this.Sound_btn);
            this.Controls.Add(this.choice3_btn);
            this.Controls.Add(this.choice2_btn);
            this.Controls.Add(this.choice1_btn);
            this.Controls.Add(this.QuestionPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CallFriendForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CallFriendForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CallFriendForm_FormClosed);
            this.Load += new System.EventHandler(this.CallFriendForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CallFriendForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.Count30pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QuestionPictureBox;
        private System.Windows.Forms.Button choice3_btn;
        private System.Windows.Forms.Button choice2_btn;
        private System.Windows.Forms.Button choice1_btn;
        private System.Windows.Forms.Button Sound_btn;
        private System.Windows.Forms.PictureBox Count30pictureBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox Written_text;
        private System.Windows.Forms.Button Skip_btn;
    }
}