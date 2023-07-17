namespace DealWithExcel
{
    partial class EndForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndForm));
            this.Skip_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Written_text = new System.Windows.Forms.TextBox();
            this.Exit_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Skip_btn
            // 
            this.Skip_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Skip_btn.BackColor = System.Drawing.Color.Transparent;
            this.Skip_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Skip_btn.ForeColor = System.Drawing.Color.White;
            this.Skip_btn.Location = new System.Drawing.Point(710, 763);
            this.Skip_btn.Name = "Skip_btn";
            this.Skip_btn.Size = new System.Drawing.Size(109, 34);
            this.Skip_btn.TabIndex = 6;
            this.Skip_btn.Text = "Skip";
            this.Skip_btn.UseVisualStyleBackColor = false;
            this.Skip_btn.Click += new System.EventHandler(this.Skip_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(587, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            this.Written_text.Location = new System.Drawing.Point(484, 358);
            this.Written_text.Multiline = true;
            this.Written_text.Name = "Written_text";
            this.Written_text.ReadOnly = true;
            this.Written_text.Size = new System.Drawing.Size(630, 399);
            this.Written_text.TabIndex = 9;
            this.Written_text.Text = "Thanks";
            this.Written_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.Exit_btn.Location = new System.Drawing.Point(12, 13);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(66, 46);
            this.Exit_btn.TabIndex = 22;
            this.Exit_btn.UseVisualStyleBackColor = false;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // EndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1394, 808);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Written_text);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Skip_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EndForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EndForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EndForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Skip_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Written_text;
        private System.Windows.Forms.Button Exit_btn;
    }
}