namespace PhieuKiemDinh.MyForm
{
    partial class frm_CreateBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CreateBatch));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_fBatchName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DateCreate = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserCreate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_TaoBatch = new DevExpress.XtraEditors.SimpleButton();
            this.lb_SoLuongAnh = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lb_SobatchHoanThanh = new System.Windows.Forms.Label();
            this.btn_drawhide = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_ShowPoint = new DevExpress.XtraEditors.SimpleButton();
            this.ck_ChiaUser = new System.Windows.Forms.CheckBox();
            this.txt_ImagePath = new DevExpress.XtraEditors.TextEdit();
            this.btn_ChonAnh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_folder_Multiline = new DevExpress.XtraEditors.TextEdit();
            this.btn_Browser = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lb_SoBatch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fBatchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ImagePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_folder_Multiline.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(258, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(160, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "TẠO BATCH MỚI";
            // 
            // txt_fBatchName
            // 
            this.txt_fBatchName.Location = new System.Drawing.Point(156, 41);
            this.txt_fBatchName.Name = "txt_fBatchName";
            this.txt_fBatchName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fBatchName.Properties.Appearance.Options.UseFont = true;
            this.txt_fBatchName.Size = new System.Drawing.Size(348, 22);
            this.txt_fBatchName.TabIndex = 4;
            this.txt_fBatchName.EditValueChanged += new System.EventHandler(this.txt_fBatchName_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(112, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tên batch (Single):";
            // 
            // txt_DateCreate
            // 
            this.txt_DateCreate.Location = new System.Drawing.Point(156, 161);
            this.txt_DateCreate.Name = "txt_DateCreate";
            this.txt_DateCreate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DateCreate.Properties.Appearance.Options.UseFont = true;
            this.txt_DateCreate.Properties.ReadOnly = true;
            this.txt_DateCreate.Size = new System.Drawing.Size(171, 22);
            this.txt_DateCreate.TabIndex = 8;
            // 
            // txt_UserCreate
            // 
            this.txt_UserCreate.Location = new System.Drawing.Point(156, 132);
            this.txt_UserCreate.Name = "txt_UserCreate";
            this.txt_UserCreate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserCreate.Properties.Appearance.Options.UseFont = true;
            this.txt_UserCreate.Properties.ReadOnly = true;
            this.txt_UserCreate.Size = new System.Drawing.Size(171, 22);
            this.txt_UserCreate.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 164);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(94, 16);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Ngày tạo batch:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 135);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "User tạo batch:";
            // 
            // btn_TaoBatch
            // 
            this.btn_TaoBatch.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btn_TaoBatch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_TaoBatch.Appearance.Options.UseFont = true;
            this.btn_TaoBatch.Appearance.Options.UseForeColor = true;
            this.btn_TaoBatch.Location = new System.Drawing.Point(258, 256);
            this.btn_TaoBatch.Name = "btn_TaoBatch";
            this.btn_TaoBatch.Size = new System.Drawing.Size(160, 29);
            this.btn_TaoBatch.TabIndex = 12;
            this.btn_TaoBatch.Text = "Tạo Batch";
            this.btn_TaoBatch.Click += new System.EventHandler(this.btn_TaoBatch_Click);
            // 
            // lb_SoLuongAnh
            // 
            this.lb_SoLuongAnh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_SoLuongAnh.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_SoLuongAnh.Appearance.Options.UseFont = true;
            this.lb_SoLuongAnh.Appearance.Options.UseForeColor = true;
            this.lb_SoLuongAnh.Location = new System.Drawing.Point(138, 229);
            this.lb_SoLuongAnh.Name = "lb_SoLuongAnh";
            this.lb_SoLuongAnh.Size = new System.Drawing.Size(0, 16);
            this.lb_SoLuongAnh.TabIndex = 14;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(36, 323);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // lb_SobatchHoanThanh
            // 
            this.lb_SobatchHoanThanh.AutoSize = true;
            this.lb_SobatchHoanThanh.Location = new System.Drawing.Point(103, 293);
            this.lb_SobatchHoanThanh.Name = "lb_SobatchHoanThanh";
            this.lb_SobatchHoanThanh.Size = new System.Drawing.Size(35, 13);
            this.lb_SobatchHoanThanh.TabIndex = 16;
            this.lb_SobatchHoanThanh.Text = "label1";
            // 
            // btn_drawhide
            // 
            this.btn_drawhide.Location = new System.Drawing.Point(134, 195);
            this.btn_drawhide.Name = "btn_drawhide";
            this.btn_drawhide.Size = new System.Drawing.Size(75, 23);
            this.btn_drawhide.TabIndex = 17;
            this.btn_drawhide.Text = "Vẽ ẫn";
            this.btn_drawhide.Click += new System.EventHandler(this.btn_drawhide_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(311, 195);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Chọn tọa độ :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(467, 229);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 77);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btn_ShowPoint
            // 
            this.btn_ShowPoint.Location = new System.Drawing.Point(562, 193);
            this.btn_ShowPoint.Name = "btn_ShowPoint";
            this.btn_ShowPoint.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowPoint.TabIndex = 21;
            this.btn_ShowPoint.Text = "Sửa";
            this.btn_ShowPoint.Click += new System.EventHandler(this.btn_ShowPoint_Click);
            // 
            // ck_ChiaUser
            // 
            this.ck_ChiaUser.AutoSize = true;
            this.ck_ChiaUser.Location = new System.Drawing.Point(510, 44);
            this.ck_ChiaUser.Name = "ck_ChiaUser";
            this.ck_ChiaUser.Size = new System.Drawing.Size(72, 17);
            this.ck_ChiaUser.TabIndex = 71;
            this.ck_ChiaUser.Text = "Chia User";
            this.ck_ChiaUser.UseVisualStyleBackColor = true;
            // 
            // txt_ImagePath
            // 
            this.txt_ImagePath.Location = new System.Drawing.Point(156, 69);
            this.txt_ImagePath.Name = "txt_ImagePath";
            this.txt_ImagePath.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImagePath.Properties.Appearance.Options.UseFont = true;
            this.txt_ImagePath.Size = new System.Drawing.Size(392, 22);
            this.txt_ImagePath.TabIndex = 74;
            // 
            // btn_ChonAnh
            // 
            this.btn_ChonAnh.Location = new System.Drawing.Point(563, 67);
            this.btn_ChonAnh.Name = "btn_ChonAnh";
            this.btn_ChonAnh.Size = new System.Drawing.Size(75, 23);
            this.btn_ChonAnh.TabIndex = 73;
            this.btn_ChonAnh.Text = "&Chọn ảnh";
            this.btn_ChonAnh.Click += new System.EventHandler(this.btn_ChonAnh_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(13, 73);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(93, 16);
            this.labelControl7.TabIndex = 72;
            this.labelControl7.Text = "Đường dẫn ảnh:";
            // 
            // txt_folder_Multiline
            // 
            this.txt_folder_Multiline.Location = new System.Drawing.Point(156, 99);
            this.txt_folder_Multiline.Name = "txt_folder_Multiline";
            this.txt_folder_Multiline.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_folder_Multiline.Properties.Appearance.Options.UseFont = true;
            this.txt_folder_Multiline.Size = new System.Drawing.Size(392, 22);
            this.txt_folder_Multiline.TabIndex = 77;
            this.txt_folder_Multiline.EditValueChanged += new System.EventHandler(this.txt_folder_Multiline_EditValueChanged);
            // 
            // btn_Browser
            // 
            this.btn_Browser.Location = new System.Drawing.Point(563, 97);
            this.btn_Browser.Name = "btn_Browser";
            this.btn_Browser.Size = new System.Drawing.Size(75, 23);
            this.btn_Browser.TabIndex = 76;
            this.btn_Browser.Text = "Browser...";
            this.btn_Browser.Click += new System.EventHandler(this.btn_Browser_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(13, 103);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(137, 16);
            this.labelControl5.TabIndex = 75;
            this.labelControl5.Text = "Folder batch (Multiline):";
            // 
            // lb_SoBatch
            // 
            this.lb_SoBatch.AutoSize = true;
            this.lb_SoBatch.Location = new System.Drawing.Point(33, 293);
            this.lb_SoBatch.Name = "lb_SoBatch";
            this.lb_SoBatch.Size = new System.Drawing.Size(35, 13);
            this.lb_SoBatch.TabIndex = 78;
            this.lb_SoBatch.Text = "label1";
            // 
            // frm_CreateBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 358);
            this.Controls.Add(this.lb_SoBatch);
            this.Controls.Add(this.txt_folder_Multiline);
            this.Controls.Add(this.btn_Browser);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txt_ImagePath);
            this.Controls.Add(this.btn_ChonAnh);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.ck_ChiaUser);
            this.Controls.Add(this.btn_ShowPoint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_drawhide);
            this.Controls.Add(this.lb_SobatchHoanThanh);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_SoLuongAnh);
            this.Controls.Add(this.btn_TaoBatch);
            this.Controls.Add(this.txt_DateCreate);
            this.Controls.Add(this.txt_UserCreate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_fBatchName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_CreateBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Batch mới";
            this.Load += new System.EventHandler(this.frm_CreateBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_fBatchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DateCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ImagePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_folder_Multiline.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_fBatchName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_DateCreate;
        private DevExpress.XtraEditors.TextEdit txt_UserCreate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_TaoBatch;
        private DevExpress.XtraEditors.LabelControl lb_SoLuongAnh;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_SobatchHoanThanh;
        private DevExpress.XtraEditors.SimpleButton btn_drawhide;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btn_ShowPoint;
        private System.Windows.Forms.CheckBox ck_ChiaUser;
        private DevExpress.XtraEditors.TextEdit txt_ImagePath;
        private DevExpress.XtraEditors.SimpleButton btn_ChonAnh;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_folder_Multiline;
        private DevExpress.XtraEditors.SimpleButton btn_Browser;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label lb_SoBatch;
    }
}