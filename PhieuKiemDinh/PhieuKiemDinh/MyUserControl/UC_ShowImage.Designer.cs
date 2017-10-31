namespace PhieuKiemDinh.MyUserControl
{
    partial class UC_ShowImage
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_User2 = new System.Windows.Forms.Label();
            this.uc_DeSo3 = new PhieuKiemDinh.MyUserControl.uc_DeSo();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_User1 = new System.Windows.Forms.Label();
            this.uc_DeSo2 = new PhieuKiemDinh.MyUserControl.uc_DeSo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_UserCheck = new System.Windows.Forms.Label();
            this.uc_DeSo1 = new PhieuKiemDinh.MyUserControl.uc_DeSo();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lb_User2);
            this.panel3.Controls.Add(this.uc_DeSo3);
            this.panel3.Location = new System.Drawing.Point(1, 527);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 264);
            this.panel3.TabIndex = 1;
            // 
            // lb_User2
            // 
            this.lb_User2.AutoSize = true;
            this.lb_User2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_User2.Location = new System.Drawing.Point(251, 234);
            this.lb_User2.Name = "lb_User2";
            this.lb_User2.Size = new System.Drawing.Size(49, 15);
            this.lb_User2.TabIndex = 1;
            this.lb_User2.Text = "User1:";
            // 
            // uc_DeSo3
            // 
            this.uc_DeSo3.AutoScroll = true;
            this.uc_DeSo3.Location = new System.Drawing.Point(-1, -1);
            this.uc_DeSo3.Name = "uc_DeSo3";
            this.uc_DeSo3.Size = new System.Drawing.Size(429, 267);
            this.uc_DeSo3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lb_User1);
            this.panel2.Controls.Add(this.uc_DeSo2);
            this.panel2.Location = new System.Drawing.Point(1, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 264);
            this.panel2.TabIndex = 2;
            // 
            // lb_User1
            // 
            this.lb_User1.AutoSize = true;
            this.lb_User1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_User1.Location = new System.Drawing.Point(251, 234);
            this.lb_User1.Name = "lb_User1";
            this.lb_User1.Size = new System.Drawing.Size(53, 15);
            this.lb_User1.TabIndex = 1;
            this.lb_User1.Text = "User1: ";
            // 
            // uc_DeSo2
            // 
            this.uc_DeSo2.AutoScroll = true;
            this.uc_DeSo2.Location = new System.Drawing.Point(4, 2);
            this.uc_DeSo2.Name = "uc_DeSo2";
            this.uc_DeSo2.Size = new System.Drawing.Size(424, 261);
            this.uc_DeSo2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_UserCheck);
            this.panel1.Controls.Add(this.uc_DeSo1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 264);
            this.panel1.TabIndex = 3;
            // 
            // lb_UserCheck
            // 
            this.lb_UserCheck.AutoSize = true;
            this.lb_UserCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UserCheck.Location = new System.Drawing.Point(251, 234);
            this.lb_UserCheck.Name = "lb_UserCheck";
            this.lb_UserCheck.Size = new System.Drawing.Size(54, 15);
            this.lb_UserCheck.TabIndex = 1;
            this.lb_UserCheck.Text = "Check: ";
            // 
            // uc_DeSo1
            // 
            this.uc_DeSo1.AutoScroll = true;
            this.uc_DeSo1.Location = new System.Drawing.Point(4, 2);
            this.uc_DeSo1.Name = "uc_DeSo1";
            this.uc_DeSo1.Size = new System.Drawing.Size(425, 261);
            this.uc_DeSo1.TabIndex = 0;
            // 
            // UC_ShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_ShowImage";
            this.Size = new System.Drawing.Size(434, 794);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label lb_User2;
        public uc_DeSo uc_DeSo3;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lb_User1;
        public uc_DeSo uc_DeSo2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lb_UserCheck;
        public uc_DeSo uc_DeSo1;
    }
}
