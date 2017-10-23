namespace PhieuKiemDinh.MyUserControl
{
    partial class uc_DeJP
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TruongSo02 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "2.②お客様名";
            // 
            // txt_TruongSo02
            // 
            this.txt_TruongSo02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TruongSo02.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TruongSo02.Location = new System.Drawing.Point(3, 93);
            this.txt_TruongSo02.Multiline = false;
            this.txt_TruongSo02.Name = "txt_TruongSo02";
            this.txt_TruongSo02.Size = new System.Drawing.Size(455, 96);
            this.txt_TruongSo02.TabIndex = 1;
            this.txt_TruongSo02.Text = "";
            this.txt_TruongSo02.TextChanged += new System.EventHandler(this.txt_TruongSo02_TextChanged);
            // 
            // uc_DeJP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_TruongSo02);
            this.Controls.Add(this.labelControl1);
            this.Name = "uc_DeJP";
            this.Size = new System.Drawing.Size(461, 273);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl labelControl1;
        public System.Windows.Forms.RichTextBox txt_TruongSo02;
    }
}
