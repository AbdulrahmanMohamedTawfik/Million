namespace DealWithExcel
{
    partial class ResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.Result_txt = new System.Windows.Forms.Label();
            this.OK_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.play_again_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fireworks_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.fireworks_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fireworks_pictureBox4 = new System.Windows.Forms.PictureBox();
            this.fireworks_pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Result_txt
            // 
            this.Result_txt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Result_txt.AutoSize = true;
            this.Result_txt.BackColor = System.Drawing.Color.Transparent;
            this.Result_txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_txt.ForeColor = System.Drawing.Color.White;
            this.Result_txt.Location = new System.Drawing.Point(197, 170);
            this.Result_txt.Name = "Result_txt";
            this.Result_txt.Size = new System.Drawing.Size(71, 28);
            this.Result_txt.TabIndex = 4;
            this.Result_txt.Text = "Result";
            // 
            // OK_btn
            // 
            this.OK_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_btn.BackColor = System.Drawing.Color.Transparent;
            this.OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_btn.ForeColor = System.Drawing.Color.White;
            this.OK_btn.Location = new System.Drawing.Point(255, 387);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(109, 34);
            this.OK_btn.TabIndex = 5;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(723, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(197, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = " Made by: Abdulrahman Mohamed Tawfik";
            // 
            // play_again_btn
            // 
            this.play_again_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.play_again_btn.BackColor = System.Drawing.Color.Transparent;
            this.play_again_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.play_again_btn.ForeColor = System.Drawing.Color.White;
            this.play_again_btn.Location = new System.Drawing.Point(411, 387);
            this.play_again_btn.Name = "play_again_btn";
            this.play_again_btn.Size = new System.Drawing.Size(109, 34);
            this.play_again_btn.TabIndex = 8;
            this.play_again_btn.Text = "Play Again";
            this.play_again_btn.UseVisualStyleBackColor = false;
            this.play_again_btn.Click += new System.EventHandler(this.play_again_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Result_txt);
            this.panel1.Controls.Add(this.play_again_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OK_btn);
            this.panel1.Location = new System.Drawing.Point(485, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 537);
            this.panel1.TabIndex = 10;
            // 
            // fireworks_pictureBox2
            // 
            this.fireworks_pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fireworks_pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.fireworks_pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox2.BackgroundImage")));
            this.fireworks_pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fireworks_pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox2.Image")));
            this.fireworks_pictureBox2.Location = new System.Drawing.Point(1407, 20);
            this.fireworks_pictureBox2.Name = "fireworks_pictureBox2";
            this.fireworks_pictureBox2.Size = new System.Drawing.Size(436, 290);
            this.fireworks_pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fireworks_pictureBox2.TabIndex = 11;
            this.fireworks_pictureBox2.TabStop = false;
            // 
            // fireworks_pictureBox1
            // 
            this.fireworks_pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.fireworks_pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox1.Image")));
            this.fireworks_pictureBox1.Location = new System.Drawing.Point(40, 20);
            this.fireworks_pictureBox1.Name = "fireworks_pictureBox1";
            this.fireworks_pictureBox1.Size = new System.Drawing.Size(436, 290);
            this.fireworks_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fireworks_pictureBox1.TabIndex = 12;
            this.fireworks_pictureBox1.TabStop = false;
            // 
            // fireworks_pictureBox4
            // 
            this.fireworks_pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fireworks_pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.fireworks_pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox4.BackgroundImage")));
            this.fireworks_pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fireworks_pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox4.Image")));
            this.fireworks_pictureBox4.Location = new System.Drawing.Point(1407, 731);
            this.fireworks_pictureBox4.Name = "fireworks_pictureBox4";
            this.fireworks_pictureBox4.Size = new System.Drawing.Size(436, 290);
            this.fireworks_pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fireworks_pictureBox4.TabIndex = 13;
            this.fireworks_pictureBox4.TabStop = false;
            // 
            // fireworks_pictureBox3
            // 
            this.fireworks_pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fireworks_pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.fireworks_pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox3.BackgroundImage")));
            this.fireworks_pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fireworks_pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("fireworks_pictureBox3.Image")));
            this.fireworks_pictureBox3.Location = new System.Drawing.Point(40, 731);
            this.fireworks_pictureBox3.Name = "fireworks_pictureBox3";
            this.fireworks_pictureBox3.Size = new System.Drawing.Size(436, 290);
            this.fireworks_pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fireworks_pictureBox3.TabIndex = 14;
            this.fireworks_pictureBox3.TabStop = false;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.fireworks_pictureBox3);
            this.Controls.Add(this.fireworks_pictureBox4);
            this.Controls.Add(this.fireworks_pictureBox1);
            this.Controls.Add(this.fireworks_pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultForm";
            this.Text = "Result";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ResultForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks_pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Result_txt;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button play_again_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox fireworks_pictureBox2;
        private System.Windows.Forms.PictureBox fireworks_pictureBox1;
        private System.Windows.Forms.PictureBox fireworks_pictureBox4;
        private System.Windows.Forms.PictureBox fireworks_pictureBox3;
    }
}