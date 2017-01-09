using DevExpress.XtraEditors;
using FactoryOne.DAL.DatabaseDAL;
using FactoryOne.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FactoryOne
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable dtXJJ = new DataTable();//下降井
        DataTable dtSLBH = new DataTable();//水量变化
        ConnDatabaseUtil cdu = new ConnDatabaseUtil();
        public static string strStartDate = string.Empty;
        public static string strEndDate = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void barBtnReadTracer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmGetTracer fgt = new FrmGetTracer();
            fgt.ShowDateList += GirdViewResultSource;
            fgt.Show(); 
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            strStartDate = cmbStartDate.Text;
            strEndDate = cmbEndDate.Text;
            if (cmbStartDate.Text.CompareTo(cmbEndDate.Text) <= 0)
            {
                ClxjDAL cd = new ClxjDAL();
                dtXJJ = cd.GetDeWell();
                gridView1.Columns.Clear();
                gridControl1.DataSource = dtXJJ;
                //DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                //gridControl1.ExportToXls(@"F:\研究生\油工数据\data\20161219\下降大的井.xls");
                //DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("起始年月大于终止年月，请重新选择");
            }
        }
        public void GirdViewResultSource()
        {
            cmbEndDate.Properties.Items.Clear();
            cmbStartDate.Properties.Items.Clear();
            //layoutCWSB.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            
            try
            {
                dockDate.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                DataTable dtNY = cdu.SelectDatabase("select distinct ny from T_WELL_TRACER");
                for (int i = 0; i < dtNY.Rows.Count; i++)
                {
                    cmbStartDate.Properties.Items.Add(dtNY.Rows[i]["NY"]);
                    cmbEndDate.Properties.Items.Add(dtNY.Rows[i]["NY"]);
                }
                
            }
            catch (Exception)
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dockDate.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
           
        }

        private void barBtnGetLayer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dockDate.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            DataTable dtNY = cdu.SelectDatabase("select distinct ny from T_WELL_OIL where ny >= '201412' order by ny");
            for (int i = 0; i < dtNY.Rows.Count; i++)
            {
                cmbStartDate.Properties.Items.Add(dtNY.Rows[i]["NY"]);
                cmbEndDate.Properties.Items.Add(dtNY.Rows[i]["NY"]);
            }
        }

        private void barBtnSLBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SlbhDAL sd = new SlbhDAL();
            
            gridView1.Columns.Clear();
            dtSLBH = sd.GetSlbhDAL(dtXJJ);
            gridControl1.DataSource = dtSLBH;
            //DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
            //gridControl1.ExportToXls(@"F:\研究生\油工数据\data\20161219\水量变化大的井.xls");
            //DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barBtnFacAna_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFactorAnalysis ffa = new FrmFactorAnalysis();
            ffa.Show();
        }

        private void barBtnYJCS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CSDAL cd = new CSDAL();
            DataTable dtYJCS = cd.GetYJCS(dtSLBH);
            gridControl1.DataSource = dtYJCS;
        }

        private void barBtnSJCS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CSDAL cd = new CSDAL();
            DataTable dtSJCS = cd.GetSJCS(dtSLBH);
            gridControl1.DataSource = dtSJCS;
        }
    }
}
