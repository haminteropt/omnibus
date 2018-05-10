// Decompiled with JetBrains decompiler
// Type: OmniRig.IOmniRigXEvents_Event
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OmniRig
{
    [ComVisible(false)]
    [TypeLibType(16)]
    [ComEventInterface(typeof(IOmniRigXEvents), typeof(IOmniRigXEvents_EventProvider))]
    public interface IOmniRigXEvents_Event
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_VisibleChange([In] IOmniRigXEvents_VisibleChangeEventHandler obj0);

        event IOmniRigXEvents_VisibleChangeEventHandler VisibleChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_VisibleChange([In] IOmniRigXEvents_VisibleChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_RigTypeChange([In] IOmniRigXEvents_RigTypeChangeEventHandler obj0);

        event IOmniRigXEvents_RigTypeChangeEventHandler RigTypeChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_RigTypeChange([In] IOmniRigXEvents_RigTypeChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_StatusChange([In] IOmniRigXEvents_StatusChangeEventHandler obj0);

        event IOmniRigXEvents_StatusChangeEventHandler StatusChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_StatusChange([In] IOmniRigXEvents_StatusChangeEventHandler obj0);

        event IOmniRigXEvents_ParamsChangeEventHandler ParamsChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_ParamsChange([In] IOmniRigXEvents_ParamsChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_ParamsChange([In] IOmniRigXEvents_ParamsChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void add_CustomReply([In] IOmniRigXEvents_CustomReplyEventHandler obj0);

        event IOmniRigXEvents_CustomReplyEventHandler CustomReply;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void remove_CustomReply([In] IOmniRigXEvents_CustomReplyEventHandler obj0);
    }
}
