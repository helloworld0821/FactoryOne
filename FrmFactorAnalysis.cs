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
using FactorsAnalysis.DAL;
using FactoryOne.DAL.DatabaseDAL;
using FactoryOne.DAL.TextDAL;

namespace FactoryOne
{
    public partial class FrmFactorAnalysis : DevExpress.XtraEditors.XtraForm
    {
        public FrmFactorAnalysis()
        {
            InitializeComponent();
        }

        private void btnOpenFA_Click(object sender, EventArgs e)
        {
            txtFAPath.Text = FileDialogHelper.Open("请选择文件", "全部文件(*.*)|*.*");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("正在处理数据");
            splashScreenManager1.SetWaitFormDescription("请稍后...");
            LocationDAL.GetAllLocation(@"F:\研究生\油工数据\data\1020.data.bak");
            ReadFilesDAL.ReadFiles(txtFAPath.Text);
            DatabaseWellDAL dwd = new DatabaseWellDAL();
            dwd.GetLTJInf(MainForm.strEndDate);
            splashScreenManager1.CloseWaitForm();
        }
    }
}