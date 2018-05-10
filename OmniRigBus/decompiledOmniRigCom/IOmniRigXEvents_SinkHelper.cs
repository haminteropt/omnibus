// Decompiled with JetBrains decompiler
// Type: OmniRig.IOmniRigXEvents_SinkHelper
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System.Runtime.InteropServices;

namespace OmniRig
{
    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class IOmniRigXEvents_SinkHelper : IOmniRigXEvents
    {
        public IOmniRigXEvents_VisibleChangeEventHandler m_VisibleChangeDelegate;
        public IOmniRigXEvents_RigTypeChangeEventHandler m_RigTypeChangeDelegate;
        public IOmniRigXEvents_StatusChangeEventHandler m_StatusChangeDelegate;
        public IOmniRigXEvents_ParamsChangeEventHandler m_ParamsChangeDelegate;
        public IOmniRigXEvents_CustomReplyEventHandler m_CustomReplyDelegate;
        public int m_dwCookie;

        public virtual void VisibleChange()
        {
            if (this.m_VisibleChangeDelegate == null)
                return;
            this.m_VisibleChangeDelegate();
        }

        public virtual void RigTypeChange([In] int obj0)
        {
            if (this.m_RigTypeChangeDelegate == null)
                return;
            this.m_RigTypeChangeDelegate(obj0);
        }

        public virtual void StatusChange([In] int obj0)
        {
            if (this.m_StatusChangeDelegate == null)
                return;
            this.m_StatusChangeDelegate(obj0);
        }

        public virtual void ParamsChange([In] int obj0, [In] int obj1)
        {
            if (this.m_ParamsChangeDelegate == null)
                return;
            this.m_ParamsChangeDelegate(obj0, obj1);
        }

        public virtual void CustomReply([In] int obj0, [In] object obj1, [In] object obj2)
        {
            if (this.m_CustomReplyDelegate == null)
                return;
            this.m_CustomReplyDelegate(obj0, obj1, obj2);
        }

        internal IOmniRigXEvents_SinkHelper()
        {
            this.m_dwCookie = 0;
            this.m_VisibleChangeDelegate = (IOmniRigXEvents_VisibleChangeEventHandler)null;
            this.m_RigTypeChangeDelegate = (IOmniRigXEvents_RigTypeChangeEventHandler)null;
            this.m_StatusChangeDelegate = (IOmniRigXEvents_StatusChangeEventHandler)null;
            this.m_ParamsChangeDelegate = (IOmniRigXEvents_ParamsChangeEventHandler)null;
            this.m_CustomReplyDelegate = (IOmniRigXEvents_CustomReplyEventHandler)null;
        }
    }
}
