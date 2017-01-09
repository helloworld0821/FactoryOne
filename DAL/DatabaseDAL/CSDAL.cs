using FactoryOne.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOne.DAL.DatabaseDAL
{
    class CSDAL
    {
        /// <summary>
        /// 获得措施
        /// </summary>
        ConnDatabaseUtil cdu = new ConnDatabaseUtil();
        public DataTable GetYJCS(DataTable dtSLBH)
        {
            //如果不能运行在下面语句中的avg()函数前加round保留小数
            DataTable dtYJCS = cdu.SelectDatabase("select b.*, a.*, round(b.平均剩余储量 / a.pjsy, 4) sybl, round(b.平均含油饱和度 / a.pjhy, 4) hybl,round(b.平均圧力 / a.pjyl, 4) ylbl from (select t.层位, avg(t.平均含油饱和度) pjhy, avg(t.平均圧力) pjyl, avg(t.平均剩余储量) pjsy from (select distinct * from T_WELL_ENDFACTOR) t group by t.层位) a,(select distinct * from T_WELL_ENDFACTOR) b where a.层位 = b.层位");
            dtSLBH.Columns.Add("YJCS", System.Type.GetType("System.String"));
            foreach (DataRow dr in dtSLBH.Rows)
            {
                DataRow[] drYJCS = dtYJCS.Select("油井 = '" + dr["JHY"] + "' and 水井 = '" + dr["SZJ"] + "' and K = " + dr["K"]);
                if (drYJCS.Count() > 0)
                {
                    if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "水井调油井堵或油井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["YJCS"] = "油水井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "水井控";
                    }

                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) >= 0.9) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "油井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "水井挖+综合挖潜";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["YJCS"] = "稳";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "水井提压";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["YJCS"] = "稳";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "油井压或油井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "油井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "水井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "水井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "水井挖 + 综合挖潜";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["YJCS"] = "油水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "油井压或油井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["YJCS"] = "油水井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "油井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "厚层水井提，薄层水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["YJCS"] = "厚层水井提，薄层水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["YJCS"] = "厚层油井提，薄层油水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["YJCS"] = "水井挖 + 综合挖潜";
                    }
                }
            }
            return dtYJCS;
        }
        public DataTable GetSJCS(DataTable dtSLBH)
        {
            //如果不能运行在下面语句中的avg()函数前加round保留小数
            DataTable dtSJCS = cdu.SelectDatabase("select b.水井, a.层位, c.zsbl, round(d.平均剩余储量 / b.pjsy, 4) sybl, round(d.平均圧力 / a.pjyl, 4) ylbl from (select 层位, avg(平均圧力) pjyl from (select distinct * from T_WELL_ENDFACTOR)　group by 层位) a, (select 水井, avg(平均剩余储量) pjsy from (select distinct * from T_WELL_ENDFACTOR) group by 水井) b, (select a.jh,a.k, round(a.rzsl/ b.pjzs,4) zsbl from (select jh, ny, avg(rzsl) pjzs from T_WELL_WATER group by jh, ny having ny = '" + MainForm.strEndDate + "') b , (select * from T_WELL_WATER where ny = '" + MainForm.strEndDate+"') a where a.jh = b.jh) c, (select distinct * from T_WELL_ENDFACTOR) d where d.水井=c.jh and d.水井 = b.水井 and a.层位 = d.层位 and d.层位 = c.k");
            dtSLBH.Columns.Add("SJCS", System.Type.GetType("System.String"));
            foreach (DataRow dr in dtSLBH.Rows)
            {
                DataRow[] drSJCS = dtSJCS.Select("油井 = '" + dr["JHY"] + "' and 水井 = '" + dr["SZJ"] + "' and K = " + dr["K"]);
                if (drSJCS.Count() > 0)
                {
                    ///if语句未改
                    if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "水井调油井堵或油井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["SJCS"] = "油水井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "水井控";
                    }

                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) >= 0.9) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "油井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "水井挖+综合挖潜";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) < 0.9) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["SJCS"] = "稳";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "水井提压";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["SJCS"] = "稳";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "油井压或油井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "油井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "水井控";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "水井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) >= 0.9 && Convert.ToDouble(dr["hybl"]) <= 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "水井挖 + 综合挖潜";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["SJCS"] = "油水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) < 0.9) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "油井压或油井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["SJCS"] = "油水井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) >= 0.9 && Convert.ToDouble(dr["sybl"]) <= 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "油井提";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "厚层水井提，薄层水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) < 0.9))
                    {
                        dr["SJCS"] = "厚层水井提，薄层水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) >= 0.9 && Convert.ToDouble(dr["ylbl"]) <= 1.1))
                    {
                        dr["SJCS"] = "厚层油井提，薄层油水井提压结合";
                    }
                    else if ((Convert.ToDouble(dr["hybl"]) > 1.1) && (Convert.ToDouble(dr["sybl"]) > 1.1) && (Convert.ToDouble(dr["ylbl"]) > 1.1))
                    {
                        dr["SJCS"] = "水井挖 + 综合挖潜";
                    }
                }
            }
            return dtSJCS;
        }
    }
}
