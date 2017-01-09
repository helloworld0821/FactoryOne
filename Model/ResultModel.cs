using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorsAnalysis.Model
{
    class ResultModel
    {
        public string 油井 { set; get; }
        public string 日期 { set; get; }
        public int 层位 { set; get; }
        public string 水井 { set; get; }
        public string 注水量 { set; get; }
        public decimal 平均剩余储量 { set; get; }
        public decimal 平均圧力 { set; get; }
        public decimal 平均含油饱和度 { set; get; }
    }
}
