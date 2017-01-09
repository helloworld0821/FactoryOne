using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOne.Model
{
    class WellModel
    {
        /// <summary>
        /// 油井坐标信息
        /// mncy - 模拟产油
        /// sumcy - 模拟分层产油求和
        /// mncs - 模拟产水
        /// sumcs - 模拟分层产水求和
        /// cye - 产液
        /// sumcye - 模拟分层产液求和
        /// 
        /// </summary>
        public string jh { set; get; }
        public int x { set; get; }
        public int y { set; get; }
        public int k { set; get; }
    }
}
