// Decompiled with JetBrains decompiler
// Type: OmniRig.OmniRigXClass
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OmniRig
{
    [Guid("0839E8C6-ED30-4950-8087-966F970F0CAE")]
    [ClassInterface(0)]
    [TypeLibType(2)]
    [ComSourceInterfaces("OmniRig.IOmniRigXEvents")]
    [ComImport]
    public class OmniRigXClass : IOmniRigX, OmniRigX, IOmniRigXEvents_Event
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern OmniRigXClass();

        [DispId(1)]
        public virtual extern int InterfaceVersion { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        [DispId(2)]
        public virtual extern int SoftwareVersion { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        [DispId(3)]
        public virtual extern RigX Rig1 { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(4)]
        public virtual extern RigX Rig2 { [DispId(4), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(5)]
        public virtual extern bool DialogVisible { [DispId(5), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(5), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void add_VisibleChange([In] IOmniRigXEvents_VisibleChangeEventHandler obj0);

        public virtual extern event IOmniRigXEvents_VisibleChangeEventHandler VisibleChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void remove_VisibleChange([In] IOmniRigXEvents_VisibleChangeEventHandler obj0);

        public virtual extern event IOmniRigXEvents_RigTypeChangeEventHandler RigTypeChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void add_RigTypeChange([In] IOmniRigXEvents_RigTypeChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void remove_RigTypeChange([In] IOmniRigXEvents_RigTypeChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void add_StatusChange([In] IOmniRigXEvents_StatusChangeEventHandler obj0);

        public virtual extern event IOmniRigXEvents_StatusChangeEventHandler StatusChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void remove_StatusChange([In] IOmniRigXEvents_StatusChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void add_ParamsChange([In] IOmniRigXEvents_ParamsChangeEventHandler obj0);

        public virtual extern event IOmniRigXEvents_ParamsChangeEventHandler ParamsChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void remove_ParamsChange([In] IOmniRigXEvents_ParamsChangeEventHandler obj0);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void add_CustomReply([In] IOmniRigXEvents_CustomReplyEventHandler obj0);

        public virtual extern event IOmniRigXEvents_CustomReplyEventHandler CustomReply;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void remove_CustomReply([In] IOmniRigXEvents_CustomReplyEventHandler obj0);
    }
}
