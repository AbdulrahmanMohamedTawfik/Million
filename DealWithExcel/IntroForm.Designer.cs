namespace MillionLE
{
    partial class IntroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroForm));
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.Skip_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.SuspendLayout();
            // 
            // wmp
            // 
            this.wmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(0, 0);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(1298, 716);
            this.wmp.TabIndex = 0;
            this.wmp.TabStop = false;
            this.wmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Wmp_PlayStateChange);
            // 
            // Skip_btn
            // 
            this.Skip_btn.BackColor = System.Drawing.Color.Transparent;
            this.Skip_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Skip_btn.ForeColor = System.Drawing.Color.White;
            this.Skip_btn.Location = new System.Drawing.Point(0, 0);
            this.Skip_btn.Name = "Skip_btn";
            this.Skip_btn.Size = new System.Drawing.Size(109, 34);
            this.Skip_btn.TabIndex = 7;
            this.Skip_btn.Text = "Skip";
            this.Skip_btn.UseVisualStyleBackColor = false;
            this.Skip_btn.Click += new System.EventHandler(this.Skip_btn_Click);
            // 
            // IntroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1298, 716);
            this.ControlBox = false;
            this.Controls.Add(this.Skip_btn);
            this.Controls.Add(this.wmp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IntroForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "IntroForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IntroForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmp;
        private System.Windows.Forms.Button Skip_btn;
    }
}