using FactoryOne.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOne.DAL.DatabaseDAL
{
    /// <summary>
    /// 判断油井产量下降 采用最后一月减第一月的方式
    /// </summary>
    class ClxjDAL
    {
        ConnDatabaseUtil cdu = new ConnDatabaseUtil();
        public DataTable GetDeWell()
        {
            int flag = 0;
            DataTable dtOil = cdu.SelectDatabase("select a.jh, a.k, a.rcsl ccs, b.rcsl mcs, a.rcyl1 ccye, b.rcyl1 mcye, a.hs chs, b.hs mhs, (a.rcyl-b.rcyl) cz from T_WELL_OIL a, T_WELL_OIL b where a.ny = '" + MainForm.strStartDate + "' and b.ny = '" + MainForm.strEndDate + "' and a.jh = b.jh and a.k = b.k and(a.rcyl-b.rcyl)> 0 order by jh,cz desc");
            //DataTable dtDeLayer = dtOil.Clone();
            dtOil.Columns.Add("Reason", System.Type.GetType("System.String"));
            DataTable dtJH = dtOil.DefaultView.ToTable(true, "jh");
            for (int i = 0; i < dtJH.Rows.Count; i++)
            {
                double comp = 0;
                flag = 0;
                DataRow[] drOilDeK = dtOil.Select("jh = '" + dtJH.Rows[i]["JH"] + "'");
                double dblSum = Convert.ToDouble(drOilDeK.CopyToDataTable().Compute("sum(cz)", ""));

                foreach (DataRow dr in drOilDeK)
                {
                    //dr["下降比例"] = Convert.ToDouble(dr["cz"]) / dblSum;
                    comp += Convert.ToDouble(dr["cz"]) / dblSum;
                    if (comp >= 0.7)
                    {
                        flag++;
                        if (flag == 2)
                        {
                            break;
                        }

                    }

                    double dblM = (Convert.ToDouble(dr["ccye"]) - Convert.ToDouble(dr["mcye"])) / (1 - Convert.ToDouble(dr["chs"]));
                    double dblN = Convert.ToDouble(dr["ccye"]) * (Convert.ToDouble(dr["mhs"]) - Convert.ToDouble(dr["chs"]));


                    if (dblM > dblN)
                    {
                        dr["Reason"] = "供液不足";
                    }
                    else
                    {
                        dr["Reason"] = "含水上升";
                    }

                }

            }
            DataTable dtDeK = dtOil.Select("Reason is not Null").CopyToDataTable();
            return dtDeK;
        }
    }
}
