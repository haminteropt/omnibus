// Decompiled with JetBrains decompiler
// Type: OmniRig.IOmniRigXEvents
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OmniRig
{
    [Guid("2219175F-E561-47E7-AD17-73C4D8891AA1")]
    [TypeLibType(4096)]
    [InterfaceType(2)]
    [ComImport]
    public interface IOmniRigXEvents
    {
        [DispId(1)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void VisibleChange();

        [DispId(2)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RigTypeChange([In] int RigNumber);

        [DispId(3)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StatusChange([In] int RigNumber);

        [DispId(4)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ParamsChange([In] int RigNumber, [In] int Params);

        [DispId(5)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CustomReply([In] int RigNumber, [MarshalAs(UnmanagedType.Struct), In] object Command, [MarshalAs(UnmanagedType.Struct), In] object Reply);
    }
}
