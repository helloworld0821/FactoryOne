using FactoryOne.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOne.DAL.DatabaseDAL
{
    class SlbhDAL
    {
        int connNumber = 20;
        ConnDatabaseUtil cdu = new ConnDatabaseUtil();

        public DataTable GetSlbhDAL(DataTable dtYJ)
        {
            DataTable dtSLBH = new DataTable();
            dtSLBH.Columns.Add("JHY", System.Type.GetType("System.String"));
            dtSLBH.Columns.Add("SZJ", System.Type.GetType("System.String"));
            dtSLBH.Columns.Add("CSL", System.Type.GetType("System.Double"));
            dtSLBH.Columns.Add("MSL", System.Type.GetType("System.Double"));
            dtSLBH.Columns.Add("BH", System.Type.GetType("System.Double"));
            dtSLBH.Columns.Add("K", System.Type.GetType("System.Int32"));
            for (int i = 0; i < dtYJ.Rows.Count; i++)
            {
                DataTable dtSJYJH = cdu.SelectDatabase("select * from dyjh where smjh = '" + dtYJ.Rows[i]["jh"] + "'");
                if (dtSJYJH.Rows.Count > 0)
                {
                    DataTable dtLtjhs = cdu.SelectDatabase("select * from ltk where jh = '" + dtSJYJH.Rows[0]["sjjh"] + "'");
                    if (dtLtjhs.Rows.Count > 0)
                    {
                        int dbjs = Convert.ToInt32(dtLtjhs.Rows[0]["dbjs"]);
                        for (int j = 1; j <= dbjs; j++)
                        {
                            DataTable dtSMSJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + dtLtjhs.Rows[0]["dbjh" + j] + "'");
                            if (dtSMSJH.Rows.Count > 0)
                            {
                                double dblCsl = 0;
                                double dblMsl = 0;
                                DataTable dtCSZJ = cdu.SelectDatabase("select a.jhy, a.szj, a.k, a.szjnd cnd from T_WELL_TRACER a where a.jhy = '" + dtYJ.Rows[i]["jh"] + "' and a.szj = '" + dtSMSJH.Rows[0]["smjh"] + "' and a.ny = '" + MainForm.strStartDate + "' and a.K = " + dtYJ.Rows[i]["K"]);
                                DataTable dtMSZJ = cdu.SelectDatabase("select a.jhy, a.szj, a.k, a.szjnd mnd from T_WELL_TRACER a where a.jhy = '" + dtYJ.Rows[i]["jh"] + "' and a.szj = '" + dtSMSJH.Rows[0]["smjh"] + "' and a.ny = '" + MainForm.strEndDate + "' and a.K = " + dtYJ.Rows[i]["K"]);
                                if (dtCSZJ.Rows.Count > 0)
                                {
                                    dblCsl = Convert.ToDouble(dtYJ.Rows[i]["ccs"]) * Convert.ToDouble(dtCSZJ.Rows[0]["cnd"]);//初水量
                                }
                                if (dtMSZJ.Rows.Count > 0)
                                {
                                    dblMsl = Convert.ToDouble(dtYJ.Rows[i]["mcs"]) * Convert.ToDouble(dtMSZJ.Rows[0]["mnd"]);//末水量
                                }
                                DataRow drSLBH = dtSLBH.NewRow();
                                drSLBH["JHY"] = dtYJ.Rows[i]["jh"];
                                drSLBH["K"] = dtYJ.Rows[i]["K"];
                                drSLBH["CSL"] = dblCsl;
                                drSLBH["MSL"] = dblMsl;
                                drSLBH["SZJ"] = dtSMSJH.Rows[0]["smjh"];
                                drSLBH["BH"] = dblCsl - dblMsl;
                                dtSLBH.Rows.Add(drSLBH);
                            }
                        }
                    }
                    else
                    {
                        for (int j = 1; j <= connNumber; j++)
                        {
                            string strColumnName = "DBJH" + j;
                            dtLtjhs = cdu.SelectDatabase("select * from LTK where " + strColumnName + " = '" + dtSJYJH.Rows[0]["sjjh"] + "'");
                            foreach (DataRow drLtjhs in dtLtjhs.Rows)
                            {
                                DataTable dtSMSJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + drLtjhs["jh"] + "'");
                                if (dtSMSJH.Rows.Count > 0)
                                {
                                    double dblCsl = 0;
                                    double dblMsl = 0;
                                    DataTable dtCSZJ = cdu.SelectDatabase("select a.jhy, a.szj, a.k, a.szjnd cnd from T_WELL_TRACER a where a.jhy = '" + dtYJ.Rows[i]["jh"] + "' and a.szj = '" + dtSMSJH.Rows[0]["smjh"] + "' and a.ny = '" + MainForm.strStartDate + "' and a.K = " + dtYJ.Rows[i]["K"]);
                                    DataTable dtMSZJ = cdu.SelectDatabase("select a.jhy, a.szj, a.k, a.szjnd mnd from T_WELL_TRACER a where a.jhy = '" + dtYJ.Rows[i]["jh"] + "' and a.szj = '" + dtSMSJH.Rows[0]["smjh"] + "' and a.ny = '" + MainForm.strEndDate + "' and a.K = " + dtYJ.Rows[i]["K"]);
                                    if (dtCSZJ.Rows.Count > 0)
                                    {
                                        dblCsl = Convert.ToDouble(dtYJ.Rows[i]["ccs"]) * Convert.ToDouble(dtCSZJ.Rows[0]["cnd"]);//初水量
                                    }
                                    if (dtMSZJ.Rows.Count > 0)
                                    {
                                        dblMsl = Convert.ToDouble(dtYJ.Rows[i]["mcs"]) * Convert.ToDouble(dtMSZJ.Rows[0]["mnd"]);//末水量
                                    }
                                    DataRow drSLBH = dtSLBH.NewRow();
                                    drSLBH["JHY"] = dtYJ.Rows[i]["jh"];
                                    drSLBH["SZJ"] = dtSMSJH.Rows[0]["smjh"];
                                    drSLBH["K"] = dtYJ.Rows[i]["K"];
                                    drSLBH["BH"] = dblCsl - dblMsl;
                                    drSLBH["CSL"] = dblCsl;
                                    drSLBH["MSL"] = dblMsl;
                                    dtSLBH.Rows.Add(drSLBH);
                                }
                            }
                        }
                    }


                }
            }


            DataTable dtSLXJ = dtSLBH.Select("BH > 0").CopyToDataTable();//水量下降
            DataView dv = dtSLXJ.DefaultView;
            dv.Sort = "BH  DESC";
            dtSLXJ = dv.ToTable();
            DataTable dtJH = dtSLXJ.DefaultView.ToTable(true, "jhy");
            for (int i = 0; i < dtJH.Rows.Count; i++)
            {
                int flag = 0;
                double comp = 0;
                DataRow[] drSjh = dtSLXJ.Select("jhy = '" + dtJH.Rows[i]["jhy"] + "'");
                double dblSum = Convert.ToDouble(drSjh.CopyToDataTable().Compute("sum(BH)", ""));

                foreach (DataRow dr in drSjh)
                {
                    //dr["下降比例"] = Convert.ToDouble(dr["cz"]) / dblSum;
                    comp += Convert.ToDouble(dr["bh"]) / dblSum;
                    if (comp >= 0.7)
                    {
                        flag++;
                        if (flag >= 2)
                        {
                            dtSLXJ.Rows.Remove(dr);
                        }

                    }
                }
            }
            return dtSLXJ;
        }
    }
}

