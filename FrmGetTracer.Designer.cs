namespace FactoryOne
{
    partial class FrmGetTracer
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblSJDY = new DevExpress.XtraEditors.LabelControl();
            this.txtSJDY = new DevExpress.XtraEditors.TextEdit();
            this.btnSJDY = new DevExpress.XtraEditors.SimpleButton();
            this.lblOpenTracerFile = new DevExpress.XtraEditors.LabelControl();
            this.txtOpenTracerFile = new DevExpress.XtraEditors.TextEdit();
            this.btnOpenTracerFile = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FactoryOne.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSJDY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpenTracerFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(510, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(406, 370);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 25);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblSJDY);
            this.panelControl1.Controls.Add(this.txtSJDY);
            this.panelControl1.Controls.Add(this.btnSJDY);
            this.panelControl1.Controls.Add(this.lblOpenTracerFile);
            this.panelControl1.Controls.Add(this.txtOpenTracerFile);
            this.panelControl1.Controls.Add(this.btnOpenTracerFile);
            this.panelControl1.Location = new System.Drawing.Point(19, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(589, 336);
            this.panelControl1.TabIndex = 11;
            // 
            // lblSJDY
            // 
            this.lblSJDY.Location = new System.Drawing.Point(39, 194);
            this.lblSJDY.Name = "lblSJDY";
            this.lblSJDY.Size = new System.Drawing.Size(114, 14);
            this.lblSJDY.TabIndex = 20;
            this.lblSJDY.Text = "示踪剂对应水井(.txt)";
            // 
            // txtSJDY
            // 
            this.txtSJDY.Enabled = false;
            this.txtSJDY.Location = new System.Drawing.Point(113, 225);
            this.txtSJDY.Name = "txtSJDY";
            this.txtSJDY.Size = new System.Drawing.Size(349, 20);
            this.txtSJDY.TabIndex = 19;
            // 
            // btnSJDY
            // 
            this.btnSJDY.Location = new System.Drawing.Point(474, 224);
            this.btnSJDY.Name = "btnSJDY";
            this.btnSJDY.Size = new System.Drawing.Size(75, 23);
            this.btnSJDY.TabIndex = 18;
            this.btnSJDY.Text = "打开";
            this.btnSJDY.Click += new System.EventHandler(this.btnSJDY_Click);
            // 
            // lblOpenTracerFile
            // 
            this.lblOpenTracerFile.Location = new System.Drawing.Point(39, 48);
            this.lblOpenTracerFile.Name = "lblOpenTracerFile";
            this.lblOpenTracerFile.Size = new System.Drawing.Size(114, 14);
            this.lblOpenTracerFile.TabIndex = 15;
            this.lblOpenTracerFile.Text = "示踪剂文件选择(.prt)";
            // 
            // txtOpenTracerFile
            // 
            this.txtOpenTracerFile.Enabled = false;
            this.txtOpenTracerFile.Location = new System.Drawing.Point(113, 81);
            this.txtOpenTracerFile.Name = "txtOpenTracerFile";
            this.txtOpenTracerFile.Size = new System.Drawing.Size(349, 20);
            this.txtOpenTracerFile.TabIndex = 11;
            // 
            // btnOpenTracerFile
            // 
            this.btnOpenTracerFile.Location = new System.Drawing.Point(474, 80);
            this.btnOpenTracerFile.Name = "btnOpenTracerFile";
            this.btnOpenTracerFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTracerFile.TabIndex = 9;
            this.btnOpenTracerFile.Text = "打开";
            this.btnOpenTracerFile.Click += new System.EventHandler(this.btnOpenTracerFile_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FrmGetTracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 423);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmGetTracer";
            this.Text = "读取示踪剂文件";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSJDY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpenTracerFile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblSJDY;
        private DevExpress.XtraEditors.TextEdit txtSJDY;
        private DevExpress.XtraEditors.SimpleButton btnSJDY;
        private DevExpress.XtraEditors.LabelControl lblOpenTracerFile;
        private DevExpress.XtraEditors.TextEdit txtOpenTracerFile;
        private DevExpress.XtraEditors.SimpleButton btnOpenTracerFile;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}