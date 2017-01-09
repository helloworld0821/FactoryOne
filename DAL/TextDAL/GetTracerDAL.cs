using FactoryOne.Model;
using FactoryOne.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FactoryOne.DAL.TextDAL
{
    class GetTracerDAL
    {
        /// <summary>
        /// 读取示踪剂文件
        /// </summary>
        public void GetTracer(string strPath, string strTrace)
        {

            FileStream fs = new FileStream(strPath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            try
            {
                GetTraceJH gtj = new GetTraceJH();

                DataTable dtTracerJH = gtj.GetTraceJHMethod(strTrace);

                DateUtil du = new DateUtil();
                //string strStartDate = du.DateTimeCovertToString(DateTime.ParseExact((MainForm.strStartDate), "yyyyMM", null));
                //string strEndDate = du.DateTimeCovertToString(DateTime.ParseExact((MainForm.strEndDate), "yyyyMM", null).AddMonths(1));

                string strReadLine;
                string strJH = string.Empty;
                string strDate = string.Empty;
                string strTracer = string.Empty;
                bool isWell = false;
                bool isRead = false;
                bool isWater = false;
                bool isDate = false;


                List<TracerModel> lstTM = new List<TracerModel>();
                List<OilModel> lstOilM = new List<OilModel>();
                List<WaterModel> lstWaterM = new List<WaterModel>();
                DataTable dtOil = ListToDataTableUtil.ListToDataTable(lstOilM);
                DataTable dtWater = ListToDataTableUtil.ListToDataTable(lstWaterM);
                DataTable dtTracer = ListToDataTableUtil.ListToDataTable(lstTM);
                strReadLine = sr.ReadLine().Replace(":", " ").Replace(",", " ");
                string trim = strReadLine.Trim();
                while (strReadLine != null)
                {
                    trim = strReadLine.Trim();

                    string[] strArray = Regex.Split(trim, @"\s+");

                    if (((strArray.Length == 12) && (strArray[0].Equals("STEP")) && (strArray[8].Equals("REPT"))) || ((strArray.Length == 11) && (strArray[0].Equals("STEP")) && (strArray[7].Equals("REPT"))))
                    {
                        strDate = strArray[strArray.Length - 1];
                        //isDate = true;
                        //if (strDate.Equals(strStartDate))
                        //{
                        //    isDate = true;
                        //}
                        if (strDate.Equals("(1-NOV-2014)"))
                        {
                            isDate = true;
                        }
                        //if (strDate.Equals(strEndDate))
                        //{
                        //    isDate = false;
                        //    break;

                        //}
                    }
                    if (isDate)
                    {
                        if (strArray[0].Equals("TRACER") && strArray.Count() == 6 && strArray[5].Equals("PASSIVE") && strArray[3].Equals("WATER") && strArray[4].Equals("PHASE"))
                        {
                            DataRow[] drTracer = dtTracerJH.Select("trace = '" + strArray[2] + "'");
                            {
                                if (drTracer.Count() > 0)
                                {
                                    strTracer = drTracer[0]["smjh"].ToString();
                                }
                            }

                        }


                        if (((strArray.Count() == 11) && strArray[3].Equals("PROD")) || ((strArray.Count() == 11) && strArray[3].Equals("WINJ")) || ((strArray.Count() == 10) && strArray[0].Equals("BLOCK")))
                        {
                            if ((strArray.Count() == 11) && strArray[3].Equals("PROD"))
                            {
                                isWater = false;
                            }
                            else if ((strArray.Count() == 11) && strArray[3].Equals("WINJ"))
                            {
                                isWater = true;
                            }
                            if (!strArray[0].Equals("BLOCK"))
                            {
                                strJH = strArray[0];
                            }
                            isWell = true;
                            while (isWell)
                            {
                                strArray = Regex.Split(trim, @"\s+");
                                if (strArray[0].Equals("BLOCK"))
                                {
                                    
                                    if (isWater)
                                    {
                                        /*
                                        if (!strArray[4].Equals("SHUT"))
                                        {
                                            //if (Convert.ToDouble(strArray[4]) > 0)
                                            //{
                                            DataRow drTracer = dtTracer.NewRow();
                                            drTracer["jhy"] = "";
                                            drTracer["jhs"] = strJH;

                                            drTracer["mncs"] = Convert.ToDouble(strArray[4]);
                                            drTracer["szj"] = strTracer;
                                            drTracer["szjnd"] = Convert.ToDouble(strArray[7]);
                                            drTracer["ny"] = du.TextDateStringCovertToDateTime(strDate).ToString("yyyyMM");
                                            drTracer["x"] = Convert.ToInt32(strArray[1]);
                                            drTracer["y"] = Convert.ToInt32(strArray[2]);
                                            drTracer["k"] = Convert.ToInt32(strArray[3]);
                                            dtTracer.Rows.Add(drTracer);
                                            // }
                                        }
                                        else
                                        {
                                            DataRow drTracer = dtTracer.NewRow();
                                            drTracer["jhy"] = "";
                                            drTracer["jhs"] = strJH;

                                            drTracer["mncs"] = Convert.ToDouble(strArray[5]);
                                            drTracer["szj"] = strTracer;
                                            drTracer["szjnd"] = Convert.ToDouble(strArray[8]);
                                            drTracer["ny"] = du.TextDateStringCovertToDateTime(strDate).ToString("yyyyMM");
                                            drTracer["x"] = Convert.ToInt32(strArray[1]);
                                            drTracer["y"] = Convert.ToInt32(strArray[2]);
                                            drTracer["k"] = Convert.ToInt32(strArray[3]);
                                            dtTracer.Rows.Add(drTracer);
                                        }
                                        */
                                    }
                                    
                                    else
                                    
                                    {
                                        if (!strArray[4].Equals("SHUT"))
                                        {
                                            //if (Convert.ToDouble(strArray[5]) > 0)
                                            //{
                                            DataRow drTracer = dtTracer.NewRow();
                                            drTracer["jhy"] = strJH;
                                            drTracer["jhs"] = "";

                                            drTracer["mncs"] = Convert.ToDouble(strArray[5]);
                                            drTracer["szj"] = strTracer;
                                            drTracer["szjnd"] = Convert.ToDouble(strArray[7]);
                                            drTracer["ny"] = du.TextDateStringCovertToDateTime(strDate).ToString("yyyyMM");
                                            drTracer["x"] = Convert.ToInt32(strArray[1]);
                                            drTracer["y"] = Convert.ToInt32(strArray[2]);
                                            drTracer["k"] = Convert.ToInt32(strArray[3]);
                                            dtTracer.Rows.Add(drTracer);
                                            //}
                                        }
                                        else
                                        {
                                            DataRow drTracer = dtTracer.NewRow();
                                            drTracer["jhy"] = strJH;
                                            drTracer["jhs"] = "";

                                            drTracer["mncs"] = Convert.ToDouble(strArray[6]);
                                            drTracer["szj"] = strTracer;
                                            drTracer["szjnd"] = Convert.ToDouble(strArray[8]);
                                            drTracer["ny"] = du.TextDateStringCovertToDateTime(strDate).ToString("yyyyMM");
                                            drTracer["x"] = Convert.ToInt32(strArray[1]);
                                            drTracer["y"] = Convert.ToInt32(strArray[2]);
                                            drTracer["k"] = Convert.ToInt32(strArray[3]);
                                            dtTracer.Rows.Add(drTracer);
                                        }

                                    }

                                    strReadLine = sr.ReadLine();
                                    if (strReadLine != null)
                                    {
                                        strReadLine = strReadLine.Replace(":", " ").Replace(",", " ");
                                        trim = strReadLine.Trim();
                                    }
                                }

                                else
                                {
                                    isWell = false;
                                }

                            }
                        
                        }
                        
                        else
                        {
                            if (trim.Equals("INJECTION  REPORT"))
                            {
                                isRead = true;
                                isWater = true;
                            }
                            else if (trim.Equals("PRODUCTION REPORT"))
                            {
                                isRead = true;
                                isWater = false;
                            }
                            else if (trim.Equals("CUMULATIVE PRODUCTION/INJECTION TOTALS"))
                            {
                                isRead = false;
                            }

                            if (isRead)
                            {

                                trim = strReadLine.Trim();

                                strArray = Regex.Split(trim, @"\s+");
                                if (isWater)
                                {
                                    if ((strArray.Count() >= 12) && (strArray.Count() <= 13))
                                    {
                                        if (strArray.Count() == 12 || strArray[4].Equals("SHUT"))
                                        {
                                            if (strArray[0].Length > 0)
                                            {
                                                if (!strArray[0].Equals("BLOCK"))
                                                {
                                                    strJH = strArray[0];
                                                }
                                                isWell = true;
                                                if (strArray[1].Equals("GROUP") || strArray[0].Equals("REPORT"))
                                                {
                                                    isWell = false;
                                                }
                                                while (isWell)
                                                {
                                                    strArray = Regex.Split(trim, @"\s+");
                                                    if (strArray[0].Equals("BLOCK"))
                                                    {
                                                        if (!strArray[4].Equals("SHUT"))
                                                        {
                                                            DataRow drWater = dtWater.NewRow();
                                                            drWater["jh"] = strJH;
                                                            if (Convert.ToDouble(strArray[5]) < 0)
                                                            {
                                                                drWater["rzsl"] = 0;
                                                            }
                                                            else
                                                            {
                                                                drWater["rzsl"] = Convert.ToDouble(strArray[5]);
                                                            }
                                                            drWater["ny"] = du.TextDateStringCovertToDateTime(strDate).ToString("yyyyMM");
                                                            drWater["x"] = Convert.ToInt32(strArray[1]);
                                                            drWater["y"] = Convert.ToInt32(strArray[2]);
                                                            drWater["bhp"] = Convert.ToDouble(strArray[8]);
                                                            drWater["k"] = Convert.ToInt32(strArray[3]);
                                                            dtWater.Rows.Add(drWater);
                                                        }
                                                        strReadLine = sr.ReadLine().Replace(":", " ").Replace(",", " ");
                                                        trim = strReadLine.Trim();
                                                    }

                                                    else
                                                    {
                                                        isWell = false;
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (strArray.Count() >= 16)
                                    {
                                        if (strArray.Count() == 16 || strArray[4].Equals("SHUT"))
                                        {
                                            if (strArray[0].Length > 0)
                                            {
                                                if (!strArray[0].Equals("BLOCK"))
                                                {
                                                    strJH = strArray[0];
                                                }
                                                isWell = true;
                                                if (strArray[1].Equals("GROUP") || strArray[0].Equals("REPORT"))
                                                {
                                                    isWell = false;
                                                }
                                                while (isWell)
                                                {
                                                    strArray = Regex.Split(trim, @"\s+");
                                                    if (strArray[0].Equals("BLOCK"))
                                                    {
                                                        if (!strArray[4].Equals("SHUT"))
                                                        {
                                                            DataRow drOil = dtOil.NewRow();
                                                            drOil["jh"] = strJH;
                                                            if (Convert.ToDouble(strArray[7]) < 0)
                                                            {
                                                                drOil["rcyl1"] = 0;
                                                            }
                                                            else
                                                            {
                                                                drOil["rcyl1"] = Convert.ToDouble(strArray[7]);
                                                            }
                                                            drOil["hs"] = Convert.ToDouble(strArray[8]);
                                                            drOil["rcsl"] = Convert.ToDouble(strArray[8]) * Convert.ToDouble(drOil["rcyl1"]);
                                                            drOil["rcyl"] = Convert.ToDouble(drOil["rcyl1"]) * (1 - Convert.ToDouble(strArray[8]));
                                                            drOil["ny"] = du.TextDateStringCovertToDateTime(strDate).ToString("yyyyMM");
                                                            drOil["x"] = Convert.ToInt32(strArray[1]);
                                                            drOil["y"] = Convert.ToInt32(strArray[2]);
                                                            drOil["bhp"] = Convert.ToDouble(strArray[11]);
                                                            drOil["k"] = Convert.ToInt32(strArray[3]);
                                                            dtOil.Rows.Add(drOil);
                                                        }
                                                        strReadLine = sr.ReadLine().Replace(":", " ").Replace(",", " ");
                                                        trim = strReadLine.Trim();
                                                    }
                                                    else
                                                    {
                                                        isWell = false;
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    strReadLine = sr.ReadLine();
                    if (strReadLine != null)
                    {
                        strReadLine = strReadLine.Replace(":", " ").Replace(",", " ");
                    }
                    //break;
                }



                ConnDatabaseUtil cdu = new ConnDatabaseUtil();

                string strTableName = "T_WELL_OIL";

                string strSQL = "select count(*) as count from user_tables where table_name = '" + strTableName.ToUpper() + "'";
                DataTable dtExist = cdu.SelectDatabase(strSQL);
                if (Convert.ToInt32(dtExist.Rows[0]["Count"]) > 0)
                {
                    strSQL = "drop table " + strTableName.ToUpper();
                    cdu.CreateOrDeleteDatabase(strSQL);
                }
                strSQL = "create table " + strTableName.ToUpper() + " (jh    VARCHAR2(16),  ny VARCHAR2(6),  x     NUMBER(3),  y     NUMBER(3),  k     NUMBER(2),  rcsl  NUMBER(17, 2),  rcyl  NUMBER(17, 2),  rcyl1 NUMBER(17, 2),  hs    NUMBER(17, 3),  bhp   NUMBER(17, 2))";
                cdu.CreateOrDeleteDatabase(strSQL);
                cdu.InsertDatabase(dtOil, strTableName.ToUpper());



                strTableName = "T_WELL_WATER";

                strSQL = "select count(*) as count from user_tables where table_name = '" + strTableName.ToUpper() + "'";
                dtExist = cdu.SelectDatabase(strSQL);
                if (Convert.ToInt32(dtExist.Rows[0]["Count"]) > 0)
                {
                    strSQL = "drop table " + strTableName.ToUpper();
                    cdu.CreateOrDeleteDatabase(strSQL);
                }
                strSQL = "create table " + strTableName.ToUpper() + " (jh    VARCHAR2(16),  ny VARCHAR2(6),  x     NUMBER(3),  y     NUMBER(3),  k     NUMBER(2),  rzsl  NUMBER(17, 2),  bhp   NUMBER(17, 2))";
                cdu.CreateOrDeleteDatabase(strSQL);
                cdu.InsertDatabase(dtWater, strTableName.ToUpper());

                strTableName = "T_WELL_TRACER";

                strSQL = "select count(*) as count from user_tables where table_name = '" + strTableName.ToUpper() + "'";
                dtExist = cdu.SelectDatabase(strSQL);
                if (Convert.ToInt32(dtExist.Rows[0]["Count"]) > 0)
                {
                    strSQL = "drop table " + strTableName.ToUpper();
                    cdu.CreateOrDeleteDatabase(strSQL);
                }
                strSQL = "create table " + strTableName.ToUpper() + " (jhy    VARCHAR2(16), jhs    VARCHAR2(16),szj    VARCHAR2(16), szjnd  NUMBER(17, 5), ny VARCHAR2(6),  x     NUMBER(3),  y     NUMBER(3),  k     NUMBER(2),  mncs  NUMBER(17, 2))";
                cdu.CreateOrDeleteDatabase(strSQL);
                cdu.InsertDatabase(dtTracer, strTableName.ToUpper());
            }
            catch (Exception)
            {
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }
}
