namespace MarkingImage_PhieuKiemDinh.MyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CreateBatch));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_fBatchName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
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
            this.txt_ImagePath = new DevExpress.XtraEditors.TextEdit();
            this.btn_ChonAnh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_folder_Multiline = new DevExpress.XtraEditors.TextEdit();
            this.btn_Browser = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lb_SoBatch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdo_Server = new System.Windows.Forms.RadioButton();
            this.rdo_Client = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_tocdoMasking = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fBatchName.Properties)).BeginInit();
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
            this.labelControl1.Location = new System.Drawing.Point(352, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "MASKING";
            // 
            // txt_fBatchName
            // 
            this.txt_fBatchName.Location = new System.Drawing.Point(156, 41);
            this.txt_fBatchName.Name = "txt_fBatchName";
            this.txt_fBatchName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fBatchName.Properties.Appearance.Options.UseFont = true;
            this.txt_fBatchName.Size = new System.Drawing.Size(461, 22);
            this.txt_fBatchName.TabIndex = 4;
            this.txt_fBatchName.EditValueChanged += new System.EventHandler(this.txt_fBatchName_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(13, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(123, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Batch name (Single):";
            // 
            // btn_TaoBatch
            // 
            this.btn_TaoBatch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_TaoBatch.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btn_TaoBatch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_TaoBatch.Appearance.Options.UseFont = true;
            this.btn_TaoBatch.Appearance.Options.UseForeColor = true;
            this.btn_TaoBatch.Location = new System.Drawing.Point(340, 224);
            this.btn_TaoBatch.Name = "btn_TaoBatch";
            this.btn_TaoBatch.Size = new System.Drawing.Size(160, 29);
            this.btn_TaoBatch.TabIndex = 12;
            this.btn_TaoBatch.Text = "Start";
            this.btn_TaoBatch.Click += new System.EventHandler(this.btn_TaoBatch_Click);
            // 
            // lb_SoLuongAnh
            // 
            this.lb_SoLuongAnh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_SoLuongAnh.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_SoLuongAnh.Appearance.Options.UseFont = true;
            this.lb_SoLuongAnh.Appearance.Options.UseForeColor = true;
            this.lb_SoLuongAnh.Location = new System.Drawing.Point(138, 199);
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
            this.progressBar1.Location = new System.Drawing.Point(39, 266);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(732, 23);
            this.progressBar1.TabIndex = 15;
            // 
            // lb_SobatchHoanThanh
            // 
            this.lb_SobatchHoanThanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_SobatchHoanThanh.AutoSize = true;
            this.lb_SobatchHoanThanh.Location = new System.Drawing.Point(81, 224);
            this.lb_SobatchHoanThanh.Name = "lb_SobatchHoanThanh";
            this.lb_SobatchHoanThanh.Size = new System.Drawing.Size(35, 13);
            this.lb_SobatchHoanThanh.TabIndex = 16;
            this.lb_SobatchHoanThanh.Text = "label1";
            // 
            // btn_drawhide
            // 
            this.btn_drawhide.Location = new System.Drawing.Point(134, 165);
            this.btn_drawhide.Name = "btn_drawhide";
            this.btn_drawhide.Size = new System.Drawing.Size(88, 23);
            this.btn_drawhide.TabIndex = 17;
            this.btn_drawhide.Text = "Draw masking ";
            this.btn_drawhide.Click += new System.EventHandler(this.btn_drawhide_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(311, 165);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(350, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Template :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(678, 214);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 39);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btn_ShowPoint
            // 
            this.btn_ShowPoint.Location = new System.Drawing.Point(678, 163);
            this.btn_ShowPoint.Name = "btn_ShowPoint";
            this.btn_ShowPoint.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowPoint.TabIndex = 21;
            this.btn_ShowPoint.Text = "Edit";
            this.btn_ShowPoint.Click += new System.EventHandler(this.btn_ShowPoint_Click);
            // 
            // txt_ImagePath
            // 
            this.txt_ImagePath.Location = new System.Drawing.Point(156, 69);
            this.txt_ImagePath.Name = "txt_ImagePath";
            this.txt_ImagePath.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ImagePath.Properties.Appearance.Options.UseFont = true;
            this.txt_ImagePath.Size = new System.Drawing.Size(505, 22);
            this.txt_ImagePath.TabIndex = 74;
            // 
            // btn_ChonAnh
            // 
            this.btn_ChonAnh.Location = new System.Drawing.Point(679, 67);
            this.btn_ChonAnh.Name = "btn_ChonAnh";
            this.btn_ChonAnh.Size = new System.Drawing.Size(92, 23);
            this.btn_ChonAnh.TabIndex = 73;
            this.btn_ChonAnh.Text = "Image browser";
            this.btn_ChonAnh.Click += new System.EventHandler(this.btn_ChonAnh_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(13, 73);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(70, 16);
            this.labelControl7.TabIndex = 72;
            this.labelControl7.Text = "Image path:";
            // 
            // txt_folder_Multiline
            // 
            this.txt_folder_Multiline.Location = new System.Drawing.Point(156, 99);
            this.txt_folder_Multiline.Name = "txt_folder_Multiline";
            this.txt_folder_Multiline.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_folder_Multiline.Properties.Appearance.Options.UseFont = true;
            this.txt_folder_Multiline.Properties.ReadOnly = true;
            this.txt_folder_Multiline.Size = new System.Drawing.Size(505, 22);
            this.txt_folder_Multiline.TabIndex = 77;
            this.txt_folder_Multiline.EditValueChanged += new System.EventHandler(this.txt_folder_Multiline_EditValueChanged);
            // 
            // btn_Browser
            // 
            this.btn_Browser.Location = new System.Drawing.Point(679, 97);
            this.btn_Browser.Name = "btn_Browser";
            this.btn_Browser.Size = new System.Drawing.Size(92, 23);
            this.btn_Browser.TabIndex = 76;
            this.btn_Browser.Text = "Folder browser";
            this.btn_Browser.Click += new System.EventHandler(this.btn_Browser_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(13, 103);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(127, 16);
            this.labelControl5.TabIndex = 75;
            this.labelControl5.Text = "Image path (Multiple):";
            // 
            // lb_SoBatch
            // 
            this.lb_SoBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_SoBatch.AutoSize = true;
            this.lb_SoBatch.Location = new System.Drawing.Point(13, 224);
            this.lb_SoBatch.Name = "lb_SoBatch";
            this.lb_SoBatch.Size = new System.Drawing.Size(35, 13);
            this.lb_SoBatch.TabIndex = 78;
            this.lb_SoBatch.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 79;
            this.label2.Text = "Program Run Form :";
            // 
            // rdo_Server
            // 
            this.rdo_Server.AutoSize = true;
            this.rdo_Server.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Server.Location = new System.Drawing.Point(158, 131);
            this.rdo_Server.Name = "rdo_Server";
            this.rdo_Server.Size = new System.Drawing.Size(64, 20);
            this.rdo_Server.TabIndex = 80;
            this.rdo_Server.TabStop = true;
            this.rdo_Server.Text = "Server";
            this.rdo_Server.UseVisualStyleBackColor = true;
            this.rdo_Server.CheckedChanged += new System.EventHandler(this.rdo_Server_CheckedChanged);
            // 
            // rdo_Client
            // 
            this.rdo_Client.AutoSize = true;
            this.rdo_Client.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Client.Location = new System.Drawing.Point(229, 131);
            this.rdo_Client.Name = "rdo_Client";
            this.rdo_Client.Size = new System.Drawing.Size(58, 20);
            this.rdo_Client.TabIndex = 81;
            this.rdo_Client.TabStop = true;
            this.rdo_Client.Text = "Client";
            this.rdo_Client.UseVisualStyleBackColor = true;
            this.rdo_Client.CheckedChanged += new System.EventHandler(this.rdo_Client_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_tocdoMasking
            // 
            this.lb_tocdoMasking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_tocdoMasking.AutoSize = true;
            this.lb_tocdoMasking.Location = new System.Drawing.Point(193, 224);
            this.lb_tocdoMasking.Name = "lb_tocdoMasking";
            this.lb_tocdoMasking.Size = new System.Drawing.Size(35, 13);
            this.lb_tocdoMasking.TabIndex = 82;
            this.lb_tocdoMasking.Text = "label3";
            // 
            // frm_CreateBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 301);
            this.Controls.Add(this.lb_tocdoMasking);
            this.Controls.Add(this.rdo_Client);
            this.Controls.Add(this.rdo_Server);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_SoBatch);
            this.Controls.Add(this.txt_folder_Multiline);
            this.Controls.Add(this.btn_Browser);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txt_ImagePath);
            this.Controls.Add(this.btn_ChonAnh);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btn_ShowPoint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_drawhide);
            this.Controls.Add(this.lb_SobatchHoanThanh);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_SoLuongAnh);
            this.Controls.Add(this.btn_TaoBatch);
            this.Controls.Add(this.txt_fBatchName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_CreateBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marking image";
            this.Load += new System.EventHandler(this.frm_CreateBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_fBatchName.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txt_ImagePath;
        private DevExpress.XtraEditors.SimpleButton btn_ChonAnh;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_folder_Multiline;
        private DevExpress.XtraEditors.SimpleButton btn_Browser;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label lb_SoBatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdo_Server;
        private System.Windows.Forms.RadioButton rdo_Client;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_tocdoMasking;
    }
}