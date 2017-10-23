namespace PhieuKiemDinh.MyUserControl
{
    partial class UC_DEJP_FeedBack
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
            this.label15 = new System.Windows.Forms.Label();
            this.lb_Ussername = new System.Windows.Forms.Label();
            this.txt_TruongSo02 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo02.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "UserName:";
            // 
            // lb_Ussername
            // 
            this.lb_Ussername.AutoSize = true;
            this.lb_Ussername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Ussername.ForeColor = System.Drawing.Color.Maroon;
            this.lb_Ussername.Location = new System.Drawing.Point(96, 1);
            this.lb_Ussername.Name = "lb_Ussername";
            this.lb_Ussername.Size = new System.Drawing.Size(14, 20);
            this.lb_Ussername.TabIndex = 33;
            this.lb_Ussername.Text = " ";
            // 
            // txt_TruongSo02
            // 
            this.txt_TruongSo02.Location = new System.Drawing.Point(11, 26);
            this.txt_TruongSo02.Name = "txt_TruongSo02";
            this.txt_TruongSo02.Size = new System.Drawing.Size(152, 20);
            this.txt_TruongSo02.TabIndex = 7;
            // 
            // UC_DEJP_FeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lb_Ussername);
            this.Controls.Add(this.txt_TruongSo02);
            this.Name = "UC_DEJP_FeedBack";
            this.Size = new System.Drawing.Size(174, 59);
            ((System.ComponentModel.ISupportInitialize)(this.txt_TruongSo02.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label lb_Ussername;
        public DevExpress.XtraEditors.TextEdit txt_TruongSo02;
    }
}
