using System;

using HiCSModel;

namespace HiCSModel
{
    /// <summary>
    /// 工序信息
    /// XuminRong 2016.04.15
    /// </summary>
    public sealed class ProcessInfo
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
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 类型
        /// </summary>
        public ProvidEnum.ProcessType Type { set; get; }

        /// <summary>
        /// 开始,结束标识
        /// </summary>
        public ProvidEnum.PreocessOper StartState { set; get; }
    }
}
