namespace FactoryOne
{
    partial class FrmFactorAnalysis
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
            this.lblFA = new DevExpress.XtraEditors.LabelControl();
            this.txtFAPath = new DevExpress.XtraEditors.TextEdit();
            this.btnOpenFA = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FactoryOne.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.txtFAPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFA
            // 
            this.lblFA.Location = new System.Drawing.Point(28, 109);
            this.lblFA.Name = "lblFA";
            this.lblFA.Size = new System.Drawing.Size(96, 14);
            this.lblFA.TabIndex = 32;
            this.lblFA.Text = "影响因素文件选择";
            // 
            // txtFAPath
            // 
            this.txtFAPath.Enabled = false;
            this.txtFAPath.Location = new System.Drawing.Point(102, 140);
            this.txtFAPath.Name = "txtFAPath";
            this.txtFAPath.Size = new System.Drawing.Size(349, 20);
            this.txtFAPath.TabIndex = 31;
            // 
            // btnOpenFA
            // 
            this.btnOpenFA.Location = new System.Drawing.Point(463, 139);
            this.btnOpenFA.Name = "btnOpenFA";
            this.btnOpenFA.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFA.TabIndex = 30;
            this.btnOpenFA.Text = "打开";
            this.btnOpenFA.Click += new System.EventHandler(this.btnOpenFA_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(449, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 28);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "取消";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(342, 225);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(89, 28);
            this.btnSubmit.TabIndex = 39;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FrmFactorAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 360);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblFA);
            this.Controls.Add(this.txtFAPath);
            this.Controls.Add(this.btnOpenFA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFactorAnalysis";
            this.Text = "影响因素文件选择";
            ((System.ComponentModel.ISupportInitialize)(this.txtFAPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblFA;
        private DevExpress.XtraEditors.TextEdit txtFAPath;
        private DevExpress.XtraEditors.SimpleButton btnOpenFA;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}