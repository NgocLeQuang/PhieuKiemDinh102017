namespace PhieuKiemDinh.MyForm
{
    partial class frm_Checker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Checker));
            this.uc_PictureBox1 = new PhieuKiemDinh.MyUserControl.uc_PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.tp_DeSo2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_DESO2 = new PhieuKiemDinh.MyUserControl.uc_DeSo();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lb_User2 = new System.Windows.Forms.Label();
            this.btn_SuaVaLuu_DeSo2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Luu_DeSo2 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tp_DeSo1 = new DevExpress.XtraTab.XtraTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uC_DESO1 = new PhieuKiemDinh.MyUserControl.uc_DeSo();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lb_User1 = new System.Windows.Forms.Label();
            this.btn_SuaVaLuu_DeSo1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Luu_DeSo1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_CheckLai = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.splitCheck = new DevExpress.XtraEditors.SplitContainerControl();
            this.btn_Start = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_ShowImageCheck = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbb_Batch_Check = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lb_Image = new DevExpress.XtraEditors.LabelControl();
            this.lb_Loi = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.tp_DeSo2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tp_DeSo1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCheck)).BeginInit();
            this.splitCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uc_PictureBox1
            // 
            this.uc_PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_PictureBox1.Location = new System.Drawing.Point(0, 30);
            this.uc_PictureBox1.Name = "uc_PictureBox1";
            this.uc_PictureBox1.Size = new System.Drawing.Size(845, 625);
            this.uc_PictureBox1.TabIndex = 25;
            this.uc_PictureBox1.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.xtraTabControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.xtraTabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 655);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(3, 330);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.tp_DeSo2;
            this.xtraTabControl2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl2.Size = new System.Drawing.Size(427, 322);
            this.xtraTabControl2.TabIndex = 3;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tp_DeSo2});
            this.xtraTabControl2.TabStop = false;
            // 
            // tp_DeSo2
            // 
            this.tp_DeSo2.Controls.Add(this.panel2);
            this.tp_DeSo2.Controls.Add(this.panelControl4);
            this.tp_DeSo2.Name = "tp_DeSo2";
            this.tp_DeSo2.Size = new System.Drawing.Size(421, 316);
            this.tp_DeSo2.Text = "Số";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.uC_DESO2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 282);
            this.panel2.TabIndex = 1;
            // 
            // uC_DESO2
            // 
            this.uC_DESO2.AutoScroll = true;
            this.uC_DESO2.AutoSize = true;
            this.uC_DESO2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DESO2.Location = new System.Drawing.Point(0, 0);
            this.uC_DESO2.Name = "uC_DESO2";
            this.uC_DESO2.Size = new System.Drawing.Size(421, 282);
            this.uC_DESO2.TabIndex = 0;
            this.uC_DESO2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.uC_DESO2_Scroll);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.lb_User2);
            this.panelControl4.Controls.Add(this.btn_SuaVaLuu_DeSo2);
            this.panelControl4.Controls.Add(this.btn_Luu_DeSo2);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 282);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(421, 34);
            this.panelControl4.TabIndex = 0;
            // 
            // lb_User2
            // 
            this.lb_User2.AutoSize = true;
            this.lb_User2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_User2.Location = new System.Drawing.Point(7, 8);
            this.lb_User2.Name = "lb_User2";
            this.lb_User2.Size = new System.Drawing.Size(0, 18);
            this.lb_User2.TabIndex = 2;
            // 
            // btn_SuaVaLuu_DeSo2
            // 
            this.btn_SuaVaLuu_DeSo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SuaVaLuu_DeSo2.Location = new System.Drawing.Point(205, 4);
            this.btn_SuaVaLuu_DeSo2.Name = "btn_SuaVaLuu_DeSo2";
            this.btn_SuaVaLuu_DeSo2.Size = new System.Drawing.Size(75, 25);
            this.btn_SuaVaLuu_DeSo2.TabIndex = 1;
            this.btn_SuaVaLuu_DeSo2.Text = "Sửa và lưu";
            this.btn_SuaVaLuu_DeSo2.Click += new System.EventHandler(this.btn_SuaVaLuu_DeSo2_Click);
            // 
            // btn_Luu_DeSo2
            // 
            this.btn_Luu_DeSo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Luu_DeSo2.Location = new System.Drawing.Point(124, 4);
            this.btn_Luu_DeSo2.Name = "btn_Luu_DeSo2";
            this.btn_Luu_DeSo2.Size = new System.Drawing.Size(75, 25);
            this.btn_Luu_DeSo2.TabIndex = 1;
            this.btn_Luu_DeSo2.Text = "Lưu";
            this.btn_Luu_DeSo2.Click += new System.EventHandler(this.btn_Luu_DeSo2_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tp_DeSo1;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(427, 321);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tp_DeSo1});
            this.xtraTabControl1.TabStop = false;
            // 
            // tp_DeSo1
            // 
            this.tp_DeSo1.Controls.Add(this.panel1);
            this.tp_DeSo1.Controls.Add(this.panelControl3);
            this.tp_DeSo1.Name = "tp_DeSo1";
            this.tp_DeSo1.Size = new System.Drawing.Size(421, 315);
            this.tp_DeSo1.Text = "Số";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.uC_DESO1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 284);
            this.panel1.TabIndex = 1;
            // 
            // uC_DESO1
            // 
            this.uC_DESO1.AutoScroll = true;
            this.uC_DESO1.AutoSize = true;
            this.uC_DESO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DESO1.Location = new System.Drawing.Point(0, 0);
            this.uC_DESO1.Name = "uC_DESO1";
            this.uC_DESO1.Size = new System.Drawing.Size(421, 284);
            this.uC_DESO1.TabIndex = 0;
            this.uC_DESO1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.uC_DESO1_Scroll);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.lb_User1);
            this.panelControl3.Controls.Add(this.btn_SuaVaLuu_DeSo1);
            this.panelControl3.Controls.Add(this.btn_Luu_DeSo1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 284);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(421, 31);
            this.panelControl3.TabIndex = 0;
            // 
            // lb_User1
            // 
            this.lb_User1.AutoSize = true;
            this.lb_User1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_User1.Location = new System.Drawing.Point(6, 7);
            this.lb_User1.Name = "lb_User1";
            this.lb_User1.Size = new System.Drawing.Size(0, 18);
            this.lb_User1.TabIndex = 2;
            // 
            // btn_SuaVaLuu_DeSo1
            // 
            this.btn_SuaVaLuu_DeSo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SuaVaLuu_DeSo1.Location = new System.Drawing.Point(205, 4);
            this.btn_SuaVaLuu_DeSo1.Name = "btn_SuaVaLuu_DeSo1";
            this.btn_SuaVaLuu_DeSo1.Size = new System.Drawing.Size(75, 25);
            this.btn_SuaVaLuu_DeSo1.TabIndex = 1;
            this.btn_SuaVaLuu_DeSo1.Text = "Sửa và lưu";
            this.btn_SuaVaLuu_DeSo1.Click += new System.EventHandler(this.btn_SuaVaLuu_DeSo1_Click);
            // 
            // btn_Luu_DeSo1
            // 
            this.btn_Luu_DeSo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Luu_DeSo1.Location = new System.Drawing.Point(124, 4);
            this.btn_Luu_DeSo1.Name = "btn_Luu_DeSo1";
            this.btn_Luu_DeSo1.Size = new System.Drawing.Size(75, 25);
            this.btn_Luu_DeSo1.TabIndex = 1;
            this.btn_Luu_DeSo1.Text = "Lưu";
            this.btn_Luu_DeSo1.Click += new System.EventHandler(this.btn_Luu_DeSo1_Click);
            // 
            // btn_CheckLai
            // 
            this.btn_CheckLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CheckLai.Location = new System.Drawing.Point(766, 621);
            this.btn_CheckLai.Name = "btn_CheckLai";
            this.btn_CheckLai.Size = new System.Drawing.Size(57, 28);
            this.btn_CheckLai.TabIndex = 3;
            this.btn_CheckLai.Text = "<<";
            this.btn_CheckLai.ToolTip = "Nhấp để check lại phiếu vừa submit";
            this.btn_CheckLai.ToolTipController = this.toolTipController1;
            this.btn_CheckLai.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btn_CheckLai.Click += new System.EventHandler(this.btn_CheckLai_Click);
            // 
            // toolTipController1
            // 
            this.toolTipController1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolTipController1.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.toolTipController1.Appearance.Options.UseBackColor = true;
            this.toolTipController1.AppearanceTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolTipController1.AppearanceTitle.BackColor2 = System.Drawing.Color.Gray;
            this.toolTipController1.AppearanceTitle.Options.UseBackColor = true;
            this.toolTipController1.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopRight;
            // 
            // splitCheck
            // 
            this.splitCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCheck.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitCheck.Location = new System.Drawing.Point(0, 0);
            this.splitCheck.Name = "splitCheck";
            this.splitCheck.Panel1.Controls.Add(this.btn_CheckLai);
            this.splitCheck.Panel1.Controls.Add(this.btn_Start);
            this.splitCheck.Panel1.Controls.Add(this.uc_PictureBox1);
            this.splitCheck.Panel1.Controls.Add(this.panelControl1);
            this.splitCheck.Panel1.Text = "Panel1";
            this.splitCheck.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitCheck.Panel2.Text = "Panel2";
            this.splitCheck.Size = new System.Drawing.Size(1283, 655);
            this.splitCheck.SplitterPosition = 433;
            this.splitCheck.TabIndex = 28;
            this.splitCheck.Text = "splitContainerControl1";
            this.splitCheck.SplitterPositionChanged += new System.EventHandler(this.splitContainerControl1_SplitterPositionChanged);
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Start.Location = new System.Drawing.Point(679, 621);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(81, 29);
            this.btn_Start.TabIndex = 27;
            this.btn_Start.Text = "Start";
            this.btn_Start.ToolTip = "Bắt đầu nhập";
            this.btn_Start.ToolTipController = this.toolTipController1;
            this.btn_Start.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_ShowImageCheck);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cbb_Batch_Check);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lb_Image);
            this.panelControl1.Controls.Add(this.lb_Loi);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(845, 30);
            this.panelControl1.TabIndex = 26;
            // 
            // btn_ShowImageCheck
            // 
            this.btn_ShowImageCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowImageCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ShowImageCheck.Appearance.Options.UseFont = true;
            this.btn_ShowImageCheck.Location = new System.Drawing.Point(739, 3);
            this.btn_ShowImageCheck.Name = "btn_ShowImageCheck";
            this.btn_ShowImageCheck.Size = new System.Drawing.Size(101, 23);
            this.btn_ShowImageCheck.TabIndex = 3;
            this.btn_ShowImageCheck.Text = "Show Image Check";
            this.btn_ShowImageCheck.ToolTip = "Xem lại dữ liệu hình đã check";
            this.btn_ShowImageCheck.Click += new System.EventHandler(this.btn_ShowImageCheck_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(297, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Image:";
            // 
            // cbb_Batch_Check
            // 
            this.cbb_Batch_Check.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Batch_Check.FormattingEnabled = true;
            this.cbb_Batch_Check.Location = new System.Drawing.Point(47, 4);
            this.cbb_Batch_Check.Name = "cbb_Batch_Check";
            this.cbb_Batch_Check.Size = new System.Drawing.Size(214, 21);
            this.cbb_Batch_Check.TabIndex = 6;
            this.cbb_Batch_Check.SelectedIndexChanged += new System.EventHandler(this.cbb_Batch_Check_SelectedIndexChanged);
            this.cbb_Batch_Check.TextChanged += new System.EventHandler(this.cbb_Batch_Check_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Batch:";
            // 
            // lb_Image
            // 
            this.lb_Image.Location = new System.Drawing.Point(337, 8);
            this.lb_Image.Name = "lb_Image";
            this.lb_Image.Size = new System.Drawing.Size(0, 13);
            this.lb_Image.TabIndex = 4;
            this.lb_Image.Click += new System.EventHandler(this.lb_Image_Click);
            // 
            // lb_Loi
            // 
            this.lb_Loi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_Loi.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_Loi.Appearance.Options.UseFont = true;
            this.lb_Loi.Appearance.Options.UseForeColor = true;
            this.lb_Loi.Location = new System.Drawing.Point(537, 9);
            this.lb_Loi.Name = "lb_Loi";
            this.lb_Loi.Size = new System.Drawing.Size(75, 13);
            this.lb_Loi.TabIndex = 5;
            this.lb_Loi.Text = "labelControl3";
            // 
            // frm_Checker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 655);
            this.Controls.Add(this.splitCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Checker";
            this.Text = "Check DESO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Checker_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.tp_DeSo2.ResumeLayout(false);
            this.tp_DeSo2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tp_DeSo1.ResumeLayout(false);
            this.tp_DeSo1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCheck)).EndInit();
            this.splitCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MyUserControl.uc_PictureBox uc_PictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage tp_DeSo2;
        private System.Windows.Forms.Panel panel2;
        private MyUserControl.uc_DeSo uC_DESO2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.Label lb_User2;
        private DevExpress.XtraEditors.SimpleButton btn_SuaVaLuu_DeSo2;
        private DevExpress.XtraEditors.SimpleButton btn_Luu_DeSo2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tp_DeSo1;
        private System.Windows.Forms.Panel panel1;
        private MyUserControl.uc_DeSo uC_DESO1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label lb_User1;
        private DevExpress.XtraEditors.SimpleButton btn_SuaVaLuu_DeSo1;
        private DevExpress.XtraEditors.SimpleButton btn_Luu_DeSo1;
        private DevExpress.XtraEditors.SplitContainerControl splitCheck;
        private DevExpress.XtraEditors.SimpleButton btn_CheckLai;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_ShowImageCheck;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbb_Batch_Check;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lb_Image;
        private DevExpress.XtraEditors.LabelControl lb_Loi;
        private DevExpress.XtraEditors.SimpleButton btn_Start;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}