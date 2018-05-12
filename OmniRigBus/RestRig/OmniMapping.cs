
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
        static public IDictionary<RigParamX, string> ParamToStr = new Dictionary<RigParamX, string>();
        static public IDictionary<string, RigParamX> StrToParam = new Dictionary<string,RigParamX>();
        //static public RigParamX StringToParam(string str)
        //{
        //}

        static private void init()
        {
            
            buildStrParam();
            buildParamStr();
            inited = true;
        }
        static public string ParamToString(OmniRig.RigParamX param)
        {
            OmniMapping.init();
            var rc = OmniMapping.ParamToStr[(OmniRigBus.OmniRigCOM.RigParamX) param];
            return rc;
        }

        static public OmniRigBus.OmniRigCOM.RigParamX StringToParam(string param)
        {
            OmniMapping.init();
            var rc = (OmniRigBus.OmniRigCOM.RigParamX) OmniMapping.StrToParam[param];
            return rc;
        }
        static private void buildStrParam()
        {
            if (inited) return;
            ParamToStr.Add(RigParamX.PM_UNKNOWN, "VFOAA");
            ParamToStr.Add(RigParamX.PM_FREQ, "Freq");
            ParamToStr.Add(RigParamX.PM_FREQA, "FreqA");
            ParamToStr.Add(RigParamX.PM_FREQB, "FreqB");
            ParamToStr.Add(RigParamX.PM_PITCH, "Pitch");
            ParamToStr.Add(RigParamX.PM_RITOFFSET, "RitOffset");
            ParamToStr.Add(RigParamX.PM_RIT0, "Rit0");
            ParamToStr.Add(RigParamX.PM_VFOAA, "VFOAA");
            ParamToStr.Add(RigParamX.PM_VFOAB, "VFOAB");
            ParamToStr.Add(RigParamX.PM_VFOBA, "VFOBA");
            ParamToStr.Add(RigParamX.PM_VFOBB, "VFOBB");
            ParamToStr.Add(RigParamX.PM_VFOA, "VFOA");
            ParamToStr.Add(RigParamX.PM_VFOB, "VFOB");
            ParamToStr.Add(RigParamX.PM_VFOEQUAL, "VFOEqual");
            ParamToStr.Add(RigParamX.PM_VFOSWAP, "VFOSwap");
            ParamToStr.Add(RigParamX.PM_SPLITOFF, "SplitOff");
            ParamToStr.Add(RigParamX.PM_SPLITON, "SplitOn");
            ParamToStr.Add(RigParamX.PM_RITOFF, "RitOff");
            ParamToStr.Add(RigParamX.PM_RITON, "RitOn");
            ParamToStr.Add(RigParamX.PM_XITOFF, "XitOff");
            ParamToStr.Add(RigParamX.PM_XITON, "XitOn");
            ParamToStr.Add(RigParamX.PM_RX, "RX");
            ParamToStr.Add(RigParamX.PM_TX, "TX");
            ParamToStr.Add(RigParamX.PM_CW_L, "CW_L");
            ParamToStr.Add(RigParamX.PM_CW_U, "CW_U");
            ParamToStr.Add(RigParamX.PM_SSB_L, "SSB_L");
            ParamToStr.Add(RigParamX.PM_SSB_U, "SSB_U");
            ParamToStr.Add(RigParamX.PM_DIG_L, "DIG_L");
            ParamToStr.Add(RigParamX.PM_DIG_U, "DIG_U");
            ParamToStr.Add(RigParamX.PM_AM, "AM");
            ParamToStr.Add(RigParamX.PM_FM, "FM");
        }

        static private void buildParamStr()
        {
            if (inited) return;
            StrToParam.Add("Unknown", RigParamX.PM_UNKNOWN);
            StrToParam.Add("Freq", RigParamX.PM_FREQ);
            StrToParam.Add("FreqA", RigParamX.PM_FREQA);
            StrToParam.Add("FreqB", RigParamX.PM_FREQB);
            StrToParam.Add("Pitch", RigParamX.PM_PITCH);
            StrToParam.Add("RitOffSet", RigParamX.PM_RITOFFSET);
            StrToParam.Add("Rit0", RigParamX.PM_RIT0);
            StrToParam.Add("VFOAA", RigParamX.PM_VFOAA);
            StrToParam.Add("VFOAB", RigParamX.PM_VFOAB);
            StrToParam.Add("VFOBA", RigParamX.PM_VFOBA);
            StrToParam.Add("VFOBB", RigParamX.PM_VFOBB);
            StrToParam.Add("VFOA", RigParamX.PM_VFOA);
            StrToParam.Add("VFOB", RigParamX.PM_VFOB);
            StrToParam.Add("VFOEqual", RigParamX.PM_VFOEQUAL);
            StrToParam.Add("VFOSwap", RigParamX.PM_VFOSWAP);
            StrToParam.Add("SplitOff", RigParamX.PM_SPLITOFF);
            StrToParam.Add("SplitOn", RigParamX.PM_SPLITON);
            StrToParam.Add("RitOff", RigParamX.PM_RITOFF);
            StrToParam.Add("RitOn", RigParamX.PM_RITON);
            StrToParam.Add("XitOff", RigParamX.PM_XITOFF);
            StrToParam.Add("XitOn", RigParamX.PM_XITON);
            StrToParam.Add("RX", RigParamX.PM_RX);
            StrToParam.Add("TX", RigParamX.PM_TX);
            StrToParam.Add("CW_L", RigParamX.PM_CW_L);
            StrToParam.Add("CW_U", RigParamX.PM_CW_U);
            StrToParam.Add("SSB_L", RigParamX.PM_SSB_L);
            StrToParam.Add("SSB_U", RigParamX.PM_SSB_U);
            StrToParam.Add("DIG_L", RigParamX.PM_DIG_L);
            StrToParam.Add("DIG_U", RigParamX.PM_DIG_U);
            StrToParam.Add("AM", RigParamX.PM_AM);
            StrToParam.Add("FM", RigParamX.PM_FM);
        }
    }
}


