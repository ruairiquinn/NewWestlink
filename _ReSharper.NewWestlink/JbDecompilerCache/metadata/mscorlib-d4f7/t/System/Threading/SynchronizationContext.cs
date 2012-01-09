// Type: System.Threading.SynchronizationContext
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
    [SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.ControlEvidence | SecurityPermissionFlag.ControlPolicy | SecurityPermissionFlag.NoFlags)]
    public class SynchronizationContext
    {
        public static SynchronizationContext Current { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        get; }

        [SecuritySafeCritical]
        protected void SetWaitNotificationRequired();

        public bool IsWaitNotificationRequired();
        public virtual void Send(SendOrPostCallback d, object state);
        public virtual void Post(SendOrPostCallback d, object state);
        public virtual void OperationStarted();
        public virtual void OperationCompleted();

        [PrePrepareMethod]
        [SecurityCritical]
        [CLSCompliant(false)]
        public virtual int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout);

        [SecurityCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [PrePrepareMethod]
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.InternalCall)]
        protected static int WaitHelper(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout);

        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecurityCritical]
        public static void SetSynchronizationContext(SynchronizationContext syncContext);

        public virtual SynchronizationContext CreateCopy();
    }
}
