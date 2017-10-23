namespace PhieuKiemDinh.MyUserControl
{
    partial class UC_FeedBack
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_DESO_FeedBack3 = new PhieuKiemDinh.MyUserControl.UC_DESO_FeedBack();
            this.uC_DESO_FeedBack2 = new PhieuKiemDinh.MyUserControl.UC_DESO_FeedBack();
            this.uC_DESO_FeedBack1 = new PhieuKiemDinh.MyUserControl.UC_DESO_FeedBack();
            this.uc_PictureBox1 = new PhieuKiemDinh.MyUserControl.uc_PictureBox();
            this.textbox1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uC_DESO_FeedBack3
            // 
            this.uC_DESO_FeedBack3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_DESO_FeedBack3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_DESO_FeedBack3.Location = new System.Drawing.Point(1240, 4);
            this.uC_DESO_FeedBack3.Name = "uC_DESO_FeedBack3";
            this.uC_DESO_FeedBack3.Size = new System.Drawing.Size(174, 431);
            this.uC_DESO_FeedBack3.TabIndex = 7;
            // 
            // uC_DESO_FeedBack2
            // 
            this.uC_DESO_FeedBack2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_DESO_FeedBack2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_DESO_FeedBack2.Location = new System.Drawing.Point(1061, 4);
            this.uC_DESO_FeedBack2.Name = "uC_DESO_FeedBack2";
            this.uC_DESO_FeedBack2.Size = new System.Drawing.Size(174, 431);
            this.uC_DESO_FeedBack2.TabIndex = 6;
            // 
            // uC_DESO_FeedBack1
            // 
            this.uC_DESO_FeedBack1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_DESO_FeedBack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_DESO_FeedBack1.Location = new System.Drawing.Point(882, 4);
            this.uC_DESO_FeedBack1.Name = "uC_DESO_FeedBack1";
            this.uC_DESO_FeedBack1.Size = new System.Drawing.Size(174, 431);
            this.uC_DESO_FeedBack1.TabIndex = 5;
            // 
            // uc_PictureBox1
            // 
            this.uc_PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_PictureBox1.AutoSize = true;
            this.uc_PictureBox1.Location = new System.Drawing.Point(37, 4);
            this.uc_PictureBox1.Name = "uc_PictureBox1";
            this.uc_PictureBox1.Size = new System.Drawing.Size(839, 431);
            this.uc_PictureBox1.TabIndex = 0;
            // 
            // textbox1
            // 
            this.textbox1.AutoSize = true;
            this.textbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.textbox1.Location = new System.Drawing.Point(7, 14);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(19, 20);
            this.textbox1.TabIndex = 8;
            this.textbox1.Text = "1";
            // 
            // UC_FeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.uC_DESO_FeedBack3);
            this.Controls.Add(this.uC_DESO_FeedBack2);
            this.Controls.Add(this.uC_DESO_FeedBack1);
            this.Controls.Add(this.uc_PictureBox1);
            this.Name = "UC_FeedBack";
            this.Size = new System.Drawing.Size(1418, 438);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public uc_PictureBox uc_PictureBox1;
        public UC_DESO_FeedBack uC_DESO_FeedBack1;
        public UC_DESO_FeedBack uC_DESO_FeedBack2;
        public UC_DESO_FeedBack uC_DESO_FeedBack3;
        public System.Windows.Forms.Label textbox1;
    }
}
