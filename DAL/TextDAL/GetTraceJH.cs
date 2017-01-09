
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
    class GetTraceJH
    {
        /// <summary>
        /// 读取示踪剂对应井号文件
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <returns></returns>
        public DataTable GetTraceJHMethod(string strPath)
        {
            List<TracerJHModel> lstTJM = new List<TracerJHModel>();
            DataTable dtTJM = ListToDataTableUtil.ListToDataTable(lstTJM);
           FileStream fs = new FileStream(strPath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string strReadLine = sr.ReadLine();
            while (strReadLine != null)
            {
                string[] strArray = Regex.Split(strReadLine, @"\s+");
                DataRow drTJM = dtTJM.NewRow();
                drTJM["smjh"] = strArray[0].Substring(1, strArray[0].Length - 2);
                drTJM["trace"] = strArray[1].Substring(1, strArray[1].Length - 2);
                dtTJM.Rows.Add(drTJM);

                strReadLine = sr.ReadLine();
            }



            sr.Close();
            fs.Close();
            return dtTJM;
        }
    }
}
