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
    class LocationDAL 
    {
        public static DataTable dtSK = new DataTable();
        public WellModel GetSingleLocation(string strJH, int k)
        {
            WellModel wm = new WellModel();
            DataRow[] rows = dtSK.Select("JH = '" + strJH + "' and K = " + k);
            if (rows.Count() > 0)
            {
                wm.jh = strJH;
                wm.x = (Int32)rows[0]["x"];
                wm.y = (Int32)rows[0]["y"];
                wm.k = k;
            }

            return wm;
        }
        public static void GetAllLocation(string path)
        {
            string strReadLine;
            WellModel wm = new WellModel();
            List<WellModel> lstWM = new List<WellModel>();
            dtSK = ListToDataTableUtil.ListToDataTable(lstWM);
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            strReadLine = sr.ReadLine();
            while (strReadLine != null)
            {
               if (strReadLine.Equals("COMPDAT"))
                {
                    strReadLine = sr.ReadLine();
                    string[] strArray = Regex.Split(strReadLine, @"\s+");
                    if (strArray[5].Equals("'OPEN'"))
                    {
                        DataRow dr = dtSK.NewRow();
                        wm = new WellModel();
                        dr["jh"] = strArray[0].Substring(1, strArray[0].Length - 2);
                        dr["x"] = Convert.ToInt32(strArray[1]);
                        dr["y"] = Convert.ToInt32(strArray[2]);
                        dr["k"] = Convert.ToInt32(strArray[3]);
                        dtSK.Rows.Add(dr);
                    }
                    
                }
                strReadLine = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }


    }
}
