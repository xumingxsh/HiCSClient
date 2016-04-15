using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCSModel
{
    /// <summary>
    /// 物料对象类
    /// XuminRong 2016.04.15
    /// </summary>
    public sealed class Material
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID { set; get; }

        /// <summary>
        /// 工序编号
        /// </summary>
        public string ProcessId { set; get; }

        /// <summary>
        /// 物料编号
        /// </summary>
        public string MaterialID { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public ProvidEnum.MaterialType MType { set; get; }

        /// <summary>
        /// 物料规格
        /// </summary>
        public string Model { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { set; get; }
    }
}
