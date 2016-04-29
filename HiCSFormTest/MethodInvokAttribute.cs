using System;
using System.Runtime.Remoting.Messaging;
using HiCSUtil;

namespace HiCSFormTest
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MethodInvokAttribute : HiCSUtil.MethInvokBaseAttribute
    {
        public MethodInvokAttribute()
        {
            this.Handle = ExecuteFunction;
        }

        private static IMethodReturnMessage ExecuteFunction(IMethodCallMessage msg, OnExecuteHandle evt)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("method {0} start", msg.MethodName));
            IMethodReturnMessage retMsg = evt();
            System.Diagnostics.Trace.WriteLine(string.Format("method {0} finish", msg.MethodName));
            return retMsg;
        }
    }
}
