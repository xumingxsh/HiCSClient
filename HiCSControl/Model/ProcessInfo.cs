using System;

using HiCSModel;

namespace HiCSControl.Model
{
    /// <summary>
    /// 工序信息
    /// </summary>
    public sealed class ProcessInfo
    {
        public string ProductID { set; get; }
        public string ProcessId { set; get; }
        public string Name { set; get; }
        public ProvidEnum.ProcessType Type { set; get; }
        public ProvidEnum.PreocessOper StartState { set; get; }
    }
}
