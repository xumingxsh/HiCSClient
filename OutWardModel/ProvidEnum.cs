using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutWardModel
{
    /// <summary>
    /// 生产相关枚举
    /// </summary>
    public static class ProvidEnum
    {
        /// <summary>
        /// 工序类型
        /// </summary>
        public enum ProcessType
        {
            Production = 1, // 生产
            QC,             // 包装
            Package         // 捆扎
        }

        /// <summary>
        /// 工序操作类型
        /// </summary>
        public enum PreocessOper
        {
            Normal = 0, // 普通
            Start,      // 第一道工序
            Finish      // 最后一道工序
        }

        /// <summary>
        /// 物料类型
        /// </summary>
        public enum MaterialType
        {
            All = 0,
            Main,   // 主料
            Line,        // 电线
            Sub        // 辅料
        }

        /// <summary>
        /// 输入项
        /// </summary>
        public enum InputType
        {
            Write = 1,
            Read
        }

        /// <summary>
        /// 初始化类型
        /// </summary>
        public enum InputInit
        {
            None = 0,   // 不适用
            Old ,       // 根据此前的值填写新值
            Plus1,      // 自动加1
            Empty,       // 清空重新填写
            Other       // 其他，需要用户自行处理，一般为只读信息
        }
    }
}
