// Decompiled with JetBrains decompiler
// Type: OmniRig.IOmniRigXEvents_CustomReplyEventHandler
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System.Runtime.InteropServices;

namespace OmniRig
{
    [TypeLibType(16)]
    [ComVisible(false)]
    public delegate void IOmniRigXEvents_CustomReplyEventHandler([In] int RigNumber, [MarshalAs(UnmanagedType.Struct), In] object Command, [MarshalAs(UnmanagedType.Struct), In] object Reply);
}
