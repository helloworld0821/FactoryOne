using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FactoryOne.Utils;
using FactoryOne.DAL.TextDAL;

namespace FactoryOne
{
    /// <summary>
    /// 读取示踪剂文件
    /// </summary>
    public delegate void ShowDateListDelegate();
    public partial class FrmGetTracer : DevExpress.XtraEditors.XtraForm
    {
        public event ShowDateListDelegate ShowDateList;
        OpenFileUtil ofu = new OpenFileUtil();
        public FrmGetTracer()
        {
            InitializeComponent();
        }

        private void btnOpenTracerFile_Click(object sender, EventArgs e)
        {
            txtOpenTracerFile.Text = ofu.OpenSMFile();
        }

        private void btnSJDY_Click(object sender, EventArgs e)
        {
            txtSJDY.Text = ofu.OpenTextFile();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOpenTracerFile.Text) && !string.IsNullOrEmpty(txtSJDY.Text))
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("正在导入示踪剂数据");
                splashScreenManager1.SetWaitFormDescription("请稍后...");

                GetTracerDAL gtd = new GetTracerDAL();
                string[] filePath = txtOpenTracerFile.Text.Split(new char[] { ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] tracePath = txtSJDY.Text.Split(new char[] { ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < filePath.Count(); i++)
                {
                    gtd.GetTracer(filePath[i], tracePath[i]);
                }
                
                ShowDateList();
                splashScreenManager1.CloseWaitForm();
            }
            else
            {
                MessageBox.Show("请检查文件是否选择");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}