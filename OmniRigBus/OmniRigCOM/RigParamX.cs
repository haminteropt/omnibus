using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus.OmniRigCOM
{
    public enum RigParamX
    {
        PM_UNKNOWN = 1,
        PM_FREQ = 2,
        PM_FREQA = 4,
        PM_FREQB = 8,
        PM_PITCH = 16, // 0x00000010
        PM_RITOFFSET = 32, // 0x00000020
        PM_RIT0 = 64, // 0x00000040
        PM_VFOAA = 128, // 0x00000080
        PM_VFOAB = 256, // 0x00000100
        PM_VFOBA = 512, // 0x00000200
        PM_VFOBB = 1024, // 0x00000400
        PM_VFOA = 2048, // 0x00000800
        PM_VFOB = 4096, // 0x00001000
        PM_VFOEQUAL = 8192, // 0x00002000
        PM_VFOSWAP = 16384, // 0x00004000
        PM_SPLITON = 32768, // 0x00008000
        PM_SPLITOFF = 65536, // 0x00010000
        PM_RITON = 131072, // 0x00020000
        PM_RITOFF = 262144, // 0x00040000
        PM_XITON = 524288, // 0x00080000
        PM_XITOFF = 1048576, // 0x00100000
        PM_RX = 2097152, // 0x00200000
        PM_TX = 4194304, // 0x00400000
        PM_CW_U = 8388608, // 0x00800000
        PM_CW_L = 16777216, // 0x01000000
        PM_SSB_U = 33554432, // 0x02000000
        PM_SSB_L = 67108864, // 0x04000000
        PM_DIG_U = 134217728, // 0x08000000
        PM_DIG_L = 268435456, // 0x10000000
        PM_AM = 536870912, // 0x20000000
        PM_FM = 1073741824, // 0x40000000
    }
    public enum RigParamBus
    {
        UNKNOWN = 1,
        FREQ = 2,
        FREQA = 4,
        FREQB = 8,
        PITCH = 16, // 0x00000010
        RITOFFSET = 32, // 0x00000020
        RIT0 = 64, // 0x00000040
        VFOAA = 128, // 0x00000080
        VFOAB = 256, // 0x00000100
        VFOBA = 512, // 0x00000200
        VFOBB = 1024, // 0x00000400
        VFOA = 2048, // 0x00000800
        VFOB = 4096, // 0x00001000
        VFOEQUAL = 8192, // 0x00002000
        VFOSWAP = 16384, // 0x00004000
        SPLITON = 32768, // 0x00008000
        SPLITOFF = 65536, // 0x00010000
        RITON = 131072, // 0x00020000
        RITOFF = 262144, // 0x00040000
        XITON = 524288, // 0x00080000
        XITOFF = 1048576, // 0x00100000
        RX = 2097152, // 0x00200000
        TX = 4194304, // 0x00400000
        CW_U = 8388608, // 0x00800000
        CW_L = 16777216, // 0x01000000
        SSB_U = 33554432, // 0x02000000
        SSB_L = 67108864, // 0x04000000
        DIG_U = 134217728, // 0x08000000
        DIG_L = 268435456, // 0x10000000
        AM = 536870912, // 0x20000000
        FM = 1073741824, // 0x40000000
    }
}
