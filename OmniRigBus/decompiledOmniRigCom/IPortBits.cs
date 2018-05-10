// Decompiled with JetBrains decompiler
// Type: OmniRig.IPortBits
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OmniRig
{
    [Guid("3DEE2CC8-1EA3-46E7-B8B4-3E7321F2446A")]
    [TypeLibType(4160)]
    [ComImport]
    public interface IPortBits
    {
        [DispId(1)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        bool Lock();

        [DispId(2)]
        bool Rts { [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(2), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

        [DispId(3)]
        bool Dtr { [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(3), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

        [DispId(4)]
        bool Cts { [DispId(4), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        [DispId(5)]
        bool Dsr { [DispId(5), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

        [DispId(6)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Unlock();
    }
}
