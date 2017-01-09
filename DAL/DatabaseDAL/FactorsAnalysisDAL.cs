
using FactoryOne.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FactoryOne.DAL.DatabaseDAL
{
    class FactorsAnalysisDAL
    {
        /// <summary>
        /// 油水井距范围内影响因素
        /// </summary>
        /// <param name="path">读取影响因素文件路径</param>
        /// <param name="strJHLocation">目标井</param>
        /// <param name="dbjhLocation">目标连通井</param>
        /// <param name="fipoilAverage">剩余储量</param>
        /// <param name="presAverage">平均压力</param>
        /// <param name="soilAverage">平均含油饱和度</param>
        /// <param name="permxAverage">平均渗透率</param>
        /// <param name="presDiff">注采压差</param>
        

        public InfFactorModel InfluencingFactors(WellModel strJHLocation, WellModel dbjhLocation, List<decimal> lstPressure, List<decimal> lstSoil, List<decimal> lstFipoil/*, List<decimal> lstKX, List<decimal> lstDCXS, List<decimal> lstPORO*/)
        {
            InfFactorModel ifm = new InfFactorModel();

            decimal fipoilTotal = 0, presTotal = 0, soilTotal = 0, kxTotal = 0, dcxsTotal = 0, poroTotal = 0;
            
            List<WellModel> lstSpacingRange = SpacingRange(strJHLocation, dbjhLocation);
            
            int index = 0;
            for (int i = 0; i < lstSpacingRange.Count; i++)
            {
                index = (lstSpacingRange[i].k - 1) * 152 * 223 + ((lstSpacingRange[i].y - 1) * 223 + lstSpacingRange[i].x) - 1;
                soilTotal += lstSoil[index];
                presTotal += lstPressure[index];
                fipoilTotal += lstFipoil[index];
                //kxTotal += lstKX[index];
                //dcxsTotal += lstDCXS[index];
                //poroTotal += lstPORO[index];
            }
            ifm.jhy = strJHLocation.jh;
            ifm.jhs = dbjhLocation.jh;
            ifm.k = strJHLocation.k;
            ifm.presAverage = presTotal / lstSpacingRange.Count;
            ifm.fipoilAverage = fipoilTotal / lstSpacingRange.Count;
            ifm.soilAverage = soilTotal / lstSpacingRange.Count;
            //ifm.wellSpacing = WellSpacing(strJHLocation, dbjhLocation);
            //ifm.kxAverage = kxTotal / lstSpacingRange.Count;
            //ifm.dcxsAverage = dcxsTotal / lstSpacingRange.Count;
            //ifm.poroAverage = poroTotal / lstSpacingRange.Count;

            int jhIndex = 0, dbjhIndex = 0;
            jhIndex = (strJHLocation.k - 1) * 152 * 223 + ((strJHLocation.y - 1) * 223 + strJHLocation.x) - 1;
            dbjhIndex = (dbjhLocation.k - 1) * 152 * 223 + ((dbjhLocation.y - 1) * 223 + dbjhLocation.x) - 1;
            
            //ifm.yy = lstPressure[jhIndex];
            //ifm.sy = lstPressure[dbjhIndex];
            //ifm.presDiff = ifm.sy - ifm.yy;
            return ifm;
        }

        /// <summary>
        /// 计算井距
        /// </summary>
        /// <param name="strJHLocation">目标井</param>
        /// <param name="dbjhLocation">目标连通井</param>
        /// <returns></returns>
        public double WellSpacing(WellModel strJHLocation, WellModel dbjhLocation)
        {
            return Math.Pow(Math.Pow((strJHLocation.y - dbjhLocation.y), 2) + Math.Pow((strJHLocation.x - dbjhLocation.x), 2), 0.5);
        }

        /// <summary>
        /// 计算井距范围
        /// </summary>
        /// <param name="strJHLocation">目标井</param>
        /// <param name="dbjhLocation">目标连通井</param>
        /// <returns></returns>
        private List<WellModel> SpacingRange(WellModel strJHLocation, WellModel dbjhLocation)
        {
            double slope;//斜率

            int x = 0, y = 0;
            List<WellModel> lstSpacingRange = new List<WellModel>();
            WellModel lm = new WellModel();

            WellModel[] array = { strJHLocation, dbjhLocation };
            Sort(array);

            slope = (array[1].y - array[0].y) / (double)(array[1].x - array[0].x);

            if (double.IsInfinity(slope))
            {

                for (int i = 0; i < 3; i++)
                {
                    y = array[0].y;
                    while (y <= array[1].y)
                    {
                        lm = new WellModel();
                        lm.x = array[0].x - 1 + i;
                        lm.y = y;
                        lm.k = array[0].k;
                        if ((lm.x > 0) && (lm.y > 0))
                        {
                            lstSpacingRange.Add(lm);
                        }

                        y++;
                    }
                }
            }
            else
            {
                double[] intercept = new double[3];//截距
                if (slope > 0)
                {
                    intercept[0] = (array[0].y + 1) - slope * (array[0].x - 1);
                    intercept[1] = array[0].y - slope * array[0].x;
                    intercept[2] = (array[0].y - 1) - slope * (array[0].x + 1);
                    for (int i = 0; i < 3; i++)
                    {
                        x = array[0].x;
                        while ((x - 1 + i) <= (array[1].x - 1 + i))
                        {
                            lm = new WellModel();
                            lm.x = x - 1 + i;
                            lm.y = (int)(slope * lm.x + intercept[i]);
                            lm.k = array[0].k;
                            if ((lm.x > 0) && (lm.y > 0))
                            {
                                lstSpacingRange.Add(lm);
                            }
                            x++;
                        }
                    }
                }
                else if (slope < 0)
                {
                    intercept[0] = (array[0].y - 1) - slope * (array[0].x - 1);
                    intercept[1] = array[0].y - slope * array[0].x;
                    intercept[2] = (array[0].y + 1) - slope * (array[0].x + 1);
                    for (int i = 0; i < 3; i++)
                    {
                        x = array[0].x;
                        while ((x - 1 + i) <= (array[1].x - 1 + i))
                        {
                            lm = new WellModel();
                            lm.x = x - 1 + i;
                            lm.y = (int)(slope * lm.x + intercept[i]);
                            lm.k = array[0].k;
                            if ((lm.x > 0) && (lm.y > 0))
                            {
                                lstSpacingRange.Add(lm);
                            }
                            x++;
                        }
                    }
                }
                else if (slope == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        x = array[0].x;
                        while (x <= array[1].x)
                        {
                            lm = new WellModel();
                            lm.x = x;
                            lm.y = array[0].y - 1 + i;
                            lm.k = array[0].k;
                            if ((lm.x > 0) && (lm.y > 0))
                            {
                                lstSpacingRange.Add(lm);
                            }
                            x++;
                        }
                    }
                }
            }

            return lstSpacingRange;
        }

        /// <summary>
        /// 将水井或油井坐标按升序排序
        /// </summary>
        /// <param name="arr">排序数组</param>
        private void Sort(WellModel[] arr)
        {
            if (arr[0].x > arr[1].x)
            {
                WellModel temp = arr[0];
                arr[0] = arr[1];
                arr[1] = temp;
            }
            else if (arr[0].x == arr[1].x)
            {
                if (arr[0].y > arr[1].y)
                {
                    WellModel temp = arr[0];
                    arr[0] = arr[1];
                    arr[1] = temp;
                }
            }
        }
        

    }
}
