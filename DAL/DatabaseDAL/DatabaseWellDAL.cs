using FactorsAnalysis.DAL;
using FactorsAnalysis.Model;
using FactoryOne.DAL.TextDAL;
using FactoryOne.Model;
using FactoryOne.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOne.DAL.DatabaseDAL
{
    class DatabaseWellDAL
    {
        int connNumber = 20;
        LocationDAL ld = new LocationDAL();
        FactorsAnalysisDAL fad = new FactorsAnalysisDAL();
        ConnDatabaseUtil cdu = new ConnDatabaseUtil();
        DataTable dtResult = new DataTable();
        public void GetLTJInf(string strDate)
        {
           
            DataTable dtOil = new DataTable();
            DataTable dtWater = new DataTable();
            List<ResultModel> lstRm = new List<ResultModel>();
            dtResult = ListToDataTableUtil.ListToDataTable(lstRm);

            dtOil = cdu.SelectDatabase("select * from yjjh");
            for (int i = 0; i < dtOil.Rows.Count; i++)
            {
                //DataTable dtSMYJH = ConnDatabaseUtil.SelectDBF("select * from 井号 where 实际井号 = '" + dtOil.Rows[i]["jh"] + "'");
                DataTable dtSMYJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + dtOil.Rows[i]["jh"] + "'");
                if (dtSMYJH.Rows.Count > 0)
                {
                    DataRow[] drJHY = LocationDAL.dtSK.Select("jh = '" + dtSMYJH.Rows[0]["smjh"] + "'");

                    foreach (DataRow dr in drJHY)
                    {
                        DataTable dtLtjhs = cdu.SelectDatabase("select * from ltk where jh = '" + dtOil.Rows[i]["jh"] + "'");
                        if (dtLtjhs.Rows.Count > 0)
                        {
                            int dbjs = Convert.ToInt32(dtLtjhs.Rows[0]["dbjs"]);
                            for (int j = 1; j <= dbjs; j++)
                            {
                                DataTable dtIsSJ = cdu.SelectDatabase("select * from sjjh where jh = '" + dtLtjhs.Rows[0]["dbjh" + j] + "'");
                                if (dtIsSJ.Rows.Count > 0)
                                {
                                    //DataTable dtSMSJH = ConnDatabaseUtil.SelectDBF("select * from 井号 where 实际井号 = '" + dtLtjhs.Rows[0]["dbjh" + j] + "'");
                                    DataTable dtSMSJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + dtLtjhs.Rows[0]["dbjh" + j] + "'");
                                    if (dtSMSJH.Rows.Count > 0)
                                    {

                                        WellModel jhs = ld.GetSingleLocation(dtSMSJH.Rows[0]["smjh"].ToString(), Convert.ToInt32(dr["k"]));
                                        GetLTOilJH(jhs, strDate, dtLtjhs.Rows[0]["dbjh" + j].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 1; j <= connNumber; j++)
                            {
                                string strColumnName = "DBJH" + j;
                                dtLtjhs = cdu.SelectDatabase("select * from LTK where " + strColumnName + " = '" + dtOil.Rows[i]["jh"] + "'");
                                foreach (DataRow drLtjhs in dtLtjhs.Rows)
                                {
                                    DataTable dtIsSJ = cdu.SelectDatabase("select * from sjjh where jh = '" + drLtjhs["jh"] + "'");
                                    if (dtIsSJ.Rows.Count > 0)
                                    {
                                        //DataTable dtSMSJH = ConnDatabaseUtil.SelectDBF("select * from 井号 where 实际井号 = '" + drLtjhs["jh"] + "'");
                                        DataTable dtSMSJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + drLtjhs["jh"] + "'");
                                        if (dtSMSJH.Rows.Count > 0)
                                        {
                                            WellModel jhs = ld.GetSingleLocation(dtSMSJH.Rows[0]["smjh"].ToString(), Convert.ToInt32(dr["k"]));
                                            GetLTOilJH(jhs, strDate, drLtjhs["jh"].ToString());
                                        }

                                    }
                                }

                            }
                        }
                    }
                }
                GC.Collect();
            }


            try
            {
                ConnDatabaseUtil cdu = new ConnDatabaseUtil();

                string strTableName = "T_WELL_ENDFACTOR";

                string strSQL = "select count(*) as count from user_tables where table_name = '" + strTableName.ToUpper() + "'";
                DataTable dtExist = cdu.SelectDatabase(strSQL);
                if (Convert.ToInt32(dtExist.Rows[0]["Count"]) > 0)
                {
                    strSQL = "drop table " + strTableName.ToUpper();
                    cdu.CreateOrDeleteDatabase(strSQL);
                }
                strSQL = "create table " + strTableName.ToUpper() + " (油井    VARCHAR2(16),  日期 VARCHAR2(6),  层位    NUMBER(2),  水井 VARCHAR2(16),  平均剩余储量  NUMBER(17, 10),  平均圧力 NUMBER(17, 10),  平均含油饱和度    NUMBER(17, 10))";
                cdu.CreateOrDeleteDatabase(strSQL);
                cdu.InsertDatabase(dtResult, strTableName.ToUpper());

            }
            catch (Exception)
            {
            }
        }
        private void GetLTOilJH(WellModel jhs, string strDate, string sjjhs)
        {

            if (jhs.jh != null)
            {
                DataTable dtLtjhy = cdu.SelectDatabase("select * from ltk where jh = '" + sjjhs + "'");
                if (dtLtjhy.Rows.Count > 0)
                {
                    int dbjs = Convert.ToInt32(dtLtjhy.Rows[0]["dbjs"]);
                    for (int j = 1; j <= dbjs; j++)
                    {
                        DataTable dtIsYJ = cdu.SelectDatabase("select * from yjjh where jh = '" + dtLtjhy.Rows[0]["dbjh" + j] + "'");
                        if (dtIsYJ.Rows.Count > 0)
                        {
                            // DataTable dtSMYJH = ConnDatabaseUtil.SelectDBF("select * from 井号 where 实际井号 = '" + dtLtjhy.Rows[0]["dbjh" + j] + "'");
                            DataTable dtSMYJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + dtLtjhy.Rows[0]["dbjh" + j] + "'");
                            if (dtSMYJH.Rows.Count > 0)
                            {
                                WellModel Othrjhy = ld.GetSingleLocation(dtSMYJH.Rows[0]["smjh"].ToString(), jhs.k);
                                if (Othrjhy.jh != null)
                                {
                                    InfFactorModel ifm = new InfFactorModel();

                                    ifm = fad.InfluencingFactors(Othrjhy, jhs, ReadFilesDAL.lstPressure, ReadFilesDAL.lstSoil, ReadFilesDAL.lstFipoil/*, ReadFilesDAL.lstKX, ReadFilesDAL.lstDCXS, ReadFilesDAL.lstPORO*/);

                                    DataRow drResult = dtResult.NewRow();
                                    
                                    //DataTable dtSJ = cdu.SelectDatabase("select * from sj where jh = '" + jhs.jh + "' and ny = '" + strDate + "' and k = " + jhs.k);
                                    //if (dtSJ.Rows.Count > 0)
                                    //{
                                    //    drResult["注入量"] = dtSJ.Rows[0]["rzsl"];
                                    //    drResult["水bhp"] = dtSJ.Rows[0]["bhp"];
                                    //}
                                    //DataTable dtYJ = cdu.SelectDatabase("select * from yj where jh = '" + Othrjhy.jh + "' and ny = '" + strDate + "' and k = " + Othrjhy.k);
                                    //if (dtYJ.Rows.Count > 0)
                                    //{
                                    //    drResult["产液"] = dtYJ.Rows[0]["rcyl1"];
                                    //    drResult["含水"] = dtYJ.Rows[0]["HS"];
                                    //    drResult["产油"] = Convert.ToDouble(dtYJ.Rows[0]["rcyl1"]) * (1 - Convert.ToDouble(dtYJ.Rows[0]["HS"]));
                                    //    drResult["油bhp"] = dtYJ.Rows[0]["bhp"];
                                    //}
                                    drResult["日期"] = strDate;
                                    drResult["油井"] = ifm.jhy;
                                    drResult["层位"] = ifm.k;
                                    drResult["水井"] = ifm.jhs;
                                    drResult["平均圧力"] = ifm.presAverage;
                                    drResult["平均含油饱和度"] = ifm.soilAverage;
                                    drResult["平均剩余储量"] = ifm.fipoilAverage;
                                    dtResult.Rows.Add(drResult);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int k = 1; k <= connNumber; k++)
                    {
                        string strColumnOilName = "DBJH" + k;
                        dtLtjhy = cdu.SelectDatabase("select * from LTK where " + strColumnOilName + " = '" + sjjhs + "'");
                        foreach (DataRow drLtjhy in dtLtjhy.Rows)
                        {
                            DataTable dtIsYJ = cdu.SelectDatabase("select * from yjjh where jh = '" + drLtjhy["jh"] + "'");
                            if (dtIsYJ.Rows.Count > 0)
                            {
                                //DataTable dtSMYJH = ConnDatabaseUtil.SelectDBF("select * from 井号 where 实际井号 = '" + drLtjhy["jh"] + "'");
                                DataTable dtSMYJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + drLtjhy["jh"] + "'");
                                if (dtSMYJH.Rows.Count > 0)
                                {
                                    WellModel Othrjhy = ld.GetSingleLocation(dtSMYJH.Rows[0]["smjh"].ToString(), jhs.k);
                                    if (Othrjhy.jh != null)
                                    {
                                        InfFactorModel ifm = new InfFactorModel();

                                        ifm = fad.InfluencingFactors(Othrjhy, jhs, ReadFilesDAL.lstPressure, ReadFilesDAL.lstSoil, ReadFilesDAL.lstFipoil/*, ReadFilesDAL.lstKX, ReadFilesDAL.lstDCXS, ReadFilesDAL.lstPORO*/);

                                        DataRow drResult = dtResult.NewRow();
                                        //DataTable dtSJ = cdu.SelectDatabase("select * from sj where jh = '" + jhs.jh + "' and ny = '" + strDate + "' and k = " + jhs.k);
                                        //if (dtSJ.Rows.Count > 0)
                                        //{
                                        //    drResult["注入量"] = dtSJ.Rows[0]["rzsl"];
                                        //    drResult["水bhp"] = dtSJ.Rows[0]["bhp"];
                                        //}
                                        //DataTable dtYJ = cdu.SelectDatabase("select * from yj where jh = '" + Othrjhy.jh + "' and ny = '" + strDate + "' and k = " + Othrjhy.k);
                                        //if (dtYJ.Rows.Count > 0)
                                        //{
                                        //    drResult["产液"] = dtYJ.Rows[0]["rcyl1"];
                                        //    drResult["含水"] = dtYJ.Rows[0]["HS"];
                                        //    drResult["产油"] = Convert.ToDouble(dtYJ.Rows[0]["rcyl1"]) * (1 - Convert.ToDouble(dtYJ.Rows[0]["HS"]));
                                        //    drResult["油bhp"] = dtYJ.Rows[0]["bhp"];
                                        //}
                                        
                                        drResult["日期"] = strDate;
                                        drResult["油井"] = ifm.jhy;
                                        drResult["层位"] = ifm.k;
                                        drResult["水井"] = ifm.jhs;
                                        drResult["平均圧力"] = ifm.presAverage;
                                        drResult["平均含油饱和度"] = ifm.soilAverage;
                                        drResult["平均剩余储量"] = ifm.fipoilAverage;
                                        dtResult.Rows.Add(drResult);
                                    }
                                }
                            }
                        }
                    }

                }
                GC.Collect();

            }

        }

        public void GetLTOil()
        {
            List<ResultModel> lstRm = new List<ResultModel>();
            dtResult = ListToDataTableUtil.ListToDataTable(lstRm);
            double dblHs = 0;
            double dblSumRcyl = 0;
            double dblSumRcsl = 0;
            DataTable dtNY = cdu.SelectDatabase("select distinct ny from yj where ny >='201412' order by ny");
            for (int m = 0; m < dtNY.Rows.Count; m++)
            {
                DataTable dtWaterJH = cdu.SelectDatabase("select distinct jh from sj where ny = '" + dtNY.Rows[m]["ny"] + "'");
                for (int i = 0; i < dtWaterJH.Rows.Count; i++)
                {
                    DataTable dtSJSJH = cdu.SelectDatabase("select * from dyjh where smjh = '" + dtWaterJH.Rows[i]["jh"] + "'");
                    if (dtSJSJH.Rows.Count > 0)
                    {
                        DataTable dtLtjhy = cdu.SelectDatabase("select * from ltk where jh = '" + dtSJSJH.Rows[0]["sjjh"] + "'");
                        if (dtLtjhy.Rows.Count > 0)
                        {
                            int dbjs = Convert.ToInt32(dtLtjhy.Rows[0]["dbjs"]);
                            for (int j = 1; j <= dbjs; j++)
                            {
                                DataTable dtSMYJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + dtLtjhy.Rows[0]["dbjh" + j] + "'");
                                if (dtSMYJH.Rows.Count > 0)
                                {
                                    DataTable dtSum = cdu.SelectDatabase("select jh, ny, sum(rcyl) as rcyl, sum(rcsl) as rcsl from YJ t group by jh, ny having jh= '" + dtSMYJH.Rows[0]["smjh"] + "' and ny = '" + dtNY.Rows[m]["ny"] + "'");
                                    if (dtSum.Rows.Count > 0)
                                    {
                                        //dblSumRcyl += Convert.ToDouble(dtSum.Rows[0]["rcyl"]);
                                        //dblSumRcsl += Convert.ToDouble(dtSum.Rows[0]["rcsl"]);
                                        dblSumRcyl = Convert.ToDouble(dtSum.Rows[0]["rcyl"]);
                                        dblSumRcsl = Convert.ToDouble(dtSum.Rows[0]["rcsl"]);
                                        if ((dblSumRcsl + dblSumRcyl) != 0)
                                        {
                                            dblHs = dblSumRcsl / (dblSumRcsl + dblSumRcyl);
                                        }
                                        else
                                        {
                                            dblHs = 0;
                                        }
                                        DataRow drResult = dtResult.NewRow();
                                        drResult["油井"] = dtSMYJH.Rows[0]["smjh"];
                                        drResult["水井"] = dtWaterJH.Rows[i]["jh"];
                                        drResult["日期"] = dtNY.Rows[m]["ny"];
                                        drResult["产油"] = dblSumRcyl;
                                        drResult["含水"] = dblHs;
                                        drResult["产液"] = dblSumRcsl + dblSumRcyl;

                                        dtResult.Rows.Add(drResult);
                                        dblSumRcsl = 0;
                                        dblSumRcyl = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 1; j <= connNumber; j++)
                            {
                                string strColumnName = "DBJH" + j;
                                dtLtjhy = cdu.SelectDatabase("select * from LTK where " + strColumnName + " = '" + dtSJSJH.Rows[0]["sjjh"] + "'");
                                foreach (DataRow drLtjhy in dtLtjhy.Rows)
                                {
                                    DataTable dtSMYJH = cdu.SelectDatabase("select * from dyjh where sjjh = '" + drLtjhy["jh"] + "'");
                                    if (dtSMYJH.Rows.Count > 0)
                                    {
                                        DataTable dtSum = cdu.SelectDatabase("select jh, ny, sum(rcyl) as rcyl, sum(rcsl) as rcsl from YJ t group by jh, ny having jh= '" + dtSMYJH.Rows[0]["smjh"] + "' and ny = '" + dtNY.Rows[m]["ny"] + "'");
                                        if (dtSum.Rows.Count > 0)
                                        {
                                            //dblSumRcyl += Convert.ToDouble(dtSum.Rows[0]["rcyl"]);
                                            //dblSumRcsl += Convert.ToDouble(dtSum.Rows[0]["rcsl"]);
                                            dblSumRcyl = Convert.ToDouble(dtSum.Rows[0]["rcyl"]);
                                            dblSumRcsl = Convert.ToDouble(dtSum.Rows[0]["rcsl"]);
                                            if ((dblSumRcsl + dblSumRcyl) != 0)
                                            {
                                                dblHs = dblSumRcsl / (dblSumRcsl + dblSumRcyl);
                                            }
                                            else
                                            {
                                                dblHs = 0;
                                            }
                                            DataRow drResult = dtResult.NewRow();
                                            drResult["水井"] = dtWaterJH.Rows[i]["jh"];
                                            drResult["油井"] = dtSMYJH.Rows[0]["smjh"];
                                            drResult["日期"] = dtNY.Rows[m]["ny"];
                                            drResult["产油"] = dblSumRcyl;
                                            drResult["含水"] = dblHs;
                                            drResult["产液"] = dblSumRcsl + dblSumRcyl;

                                            dtResult.Rows.Add(drResult);
                                            dblSumRcsl = 0;
                                            dblSumRcyl = 0;
                                        }
                                    }
                                }
                            }
                        }


                        dblSumRcsl = 0;
                        dblSumRcyl = 0;
                    }
                }
            }

        }

        public void get()
        {
            List<ResultModel> lstRm = new List<ResultModel>();
            dtResult = ListToDataTableUtil.ListToDataTable(lstRm);
            DataTable dtYJ = cdu.SelectDatabase("select a.jh, a.k, (a.rcyl-b.rcyl) cz from yj a, yj b where a.ny='201412' and b.ny = '201509' and a.jh = b.jh and a.k = b.k and(a.rcyl-b.rcyl)> 0 and a.jh in ('G147-50','G153-543','N1-D1-140','Z9-B42','Z10-B039','Z80-S247','Z80-S249','Z82-246','Z82-S257','Z91-25','Z91-S246','Z91-S22','Z10-B139','Z92-S255','ZD9-39','ZD9-40','ZD9-141','ZD-S137','ZD10-40','ZD10-S37','ZD10-S42','ZD10-S143')");
            DataTable dtNY = cdu.SelectDatabase("select distinct ny from yj where ny >='201412' order by ny");
            for (int m = 0; m < dtNY.Rows.Count; m++)
            {
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
                                    DataTable dtZSL = cdu.SelectDatabase("select jh, ny, k, rzsl from sj where jh= '" + dtSMSJH.Rows[0]["smjh"] + "' and ny = '" + dtNY.Rows[m]["ny"] + "' and K = " + dtYJ.Rows[i]["K"]);
                                    if (dtZSL.Rows.Count > 0)
                                    {
                                        //dblSumRcyl += Convert.ToDouble(dtSum.Rows[0]["rcyl"]);
                                        //dblSumRcsl += Convert.ToDouble(dtSum.Rows[0]["rcsl"]);
                                        
                                        DataRow drResult = dtResult.NewRow();
                                        drResult["油井"] = dtYJ.Rows[i]["jh"];
                                        drResult["水井"] = dtSMSJH.Rows[0]["smjh"];
                                        drResult["日期"] = dtNY.Rows[m]["ny"];
                                        drResult["层位"] = dtYJ.Rows[i]["K"];
                                        drResult["注入量"] = dtZSL.Rows[0]["rzsl"];

                                        dtResult.Rows.Add(drResult);
                                        
                                    }
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
                                        DataTable dtZSL = cdu.SelectDatabase("select jh, ny, k, rzsl from sj where jh= '" + dtSMSJH.Rows[0]["smjh"] + "' and ny = '" + dtNY.Rows[m]["ny"] + "' and K = " + dtYJ.Rows[i]["K"]);
                                        if (dtZSL.Rows.Count > 0)
                                        {
                                            DataRow drResult = dtResult.NewRow();
                                            drResult["油井"] = dtYJ.Rows[i]["jh"];
                                            drResult["水井"] = dtSMSJH.Rows[0]["smjh"];
                                            drResult["日期"] = dtNY.Rows[m]["ny"];
                                            drResult["层位"] = dtYJ.Rows[i]["K"];
                                            drResult["注入量"] = dtZSL.Rows[0]["rzsl"];

                                            dtResult.Rows.Add(drResult);
                                        }
                                    }
                                }
                            }
                        }

                        
                    }
                }
            }
        }
    }
}
