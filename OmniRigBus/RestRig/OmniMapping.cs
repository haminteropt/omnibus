
using OmniRigBus.OmniRigCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus.RestRig
{
    public class OmniMapping
    {
        static bool inited = false;
        static public IDictionary<RigParamX, string> ParamStr = new Dictionary<RigParamX, string>();
        static public IDictionary<string, RigParamX> StrParam = new Dictionary<string,RigParamX>();
        //static public RigParamX StringToParam(string str)
        //{
        //}

        static private void init()
        {
            inited = true;
            buildStrParam();
            buildStrParam();

        }
        static private void buildStrParam()
        {
            ParamStr.Add(RigParamX.VFOAA, "VFOAA");
            ParamStr.Add(RigParamX.VFOAB, "VFOAB");
            ParamStr.Add(RigParamX.VFOBA, "VFOBA");
            ParamStr.Add(RigParamX.VFOBB, "VFOBB");
            ParamStr.Add(RigParamX.VFOA, "VFOA");
            ParamStr.Add(RigParamX.VFOB, "VFOB");
            ParamStr.Add(RigParamX.VFOEQUAL, "VFOEqual");
            ParamStr.Add(RigParamX.VFOSWAP, "VFOSwap");
            ParamStr.Add(RigParamX.SPLITOFF, "SplitOff");
            ParamStr.Add(RigParamX.SPLITON, "SplitOn");
            ParamStr.Add(RigParamX.RITOFF, "RitOff");
            ParamStr.Add(RigParamX.RITON, "RitOn");
            ParamStr.Add(RigParamX.XITOFF, "XitOff");
            ParamStr.Add(RigParamX.XITON, "XitOn");
            ParamStr.Add(RigParamX.RX, "RX");
            ParamStr.Add(RigParamX.TX, "TX");
            ParamStr.Add(RigParamX.CW_L, "CW_L");
            ParamStr.Add(RigParamX.CW_U, "CW_U");
            ParamStr.Add(RigParamX.SSB_L, "SSB_L");
            ParamStr.Add(RigParamX.SSB_U, "SSB_U");
            ParamStr.Add(RigParamX.DIG_L, "DIG_L");
            ParamStr.Add(RigParamX.DIG_U, "DIG_U");
            ParamStr.Add(RigParamX.AM, "AM");
            ParamStr.Add(RigParamX.FM, "FM");
        }

        static private void builParamStr()
        {
            StrParam.Add("VFOAA", RigParamX.VFOAA);
            StrParam.Add("VFOAB", RigParamX.VFOAB);
            StrParam.Add("VFOBA", RigParamX.VFOBA);
            StrParam.Add("VFOBB", RigParamX.VFOBB);
            StrParam.Add("VFOA", RigParamX.VFOA);
            StrParam.Add("VFOB", RigParamX.VFOB);
            StrParam.Add("VFOEqual", RigParamX.VFOEQUAL);
            StrParam.Add("VFOSwap", RigParamX.VFOSWAP);
            StrParam.Add("SplitOff", RigParamX.SPLITOFF);
            StrParam.Add("SplitOn", RigParamX.SPLITON);
            StrParam.Add("RitOff", RigParamX.RITOFF);
            StrParam.Add("RitOn", RigParamX.RITON);
            StrParam.Add("XitOff", RigParamX.XITOFF);
            StrParam.Add("XitOn", RigParamX.XITON);
            StrParam.Add("RX", RigParamX.RX);
            StrParam.Add("TX", RigParamX.TX);
            StrParam.Add("CW_L", RigParamX.CW_L);
            StrParam.Add("CW_U", RigParamX.CW_U);
            StrParam.Add("SSB_L", RigParamX.SSB_L);
            StrParam.Add("SSB_U", RigParamX.SSB_U);
            StrParam.Add("DIG_L", RigParamX.DIG_L);
            StrParam.Add("DIG_U", RigParamX.DIG_U);
            StrParam.Add("AM", RigParamX.AM);
            StrParam.Add("FM", RigParamX.FM);
        }
    }
}


