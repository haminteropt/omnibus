using Newtonsoft.Json;
using OmniRig;
using OmniRigBus;
using OmniRigBus.OmniRigCOM;
using OmniRigBus.RestRig;
using RigBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

//{
//    "Freq": 14313000,
//    "FreqA": 14313000,
//    "FreqB": 7000000,
//    "Mode": "USB",
//    "Pitch": 0,
//    "RigType": "PowerSDR",
//    "Rit": "RitOff",
//    "RitOffset": 0,
//    "Status": null,
//    "StatusStr": null,
//    "Split": "SplitOff",
//    "Tx": "RX",
//    "Vfo": "VFOAA",
//    "Xit": "XitOff"
//}

namespace OmniRigBus
{
    public class ORig: IRig
    {
        private static ORig instance = null;
        private OmniRigX OmniRig;
        private List<RigX> RigX = new List<RigX>();

        private Rigs rigState = Rigs.Instance;

        private ORig()
        {

                OmniRig = new OmniRigX();
                OmniRig.ParamsChange += ParamsChangeEvent;
                RigX.Add(OmniRig.Rig1);
                RigX.Add(OmniRig.Rig2);

            
        }
        private void ParamsChangeEvent(int RigNumber, int Params)
        {
            if (RigNumber != 1 && RigNumber != 2) return;
            Console.WriteLine(String.Format("Param: {0}", Params));
            RigState rigState = GetRigState(RigNumber);
            var json = JsonConvert.SerializeObject(rigState);
        }

        public RigState GetRigState(int rigNum)
        {

            var rigs = Rigs.Instance;
            rigs.PopulateRigs();
            var rigList = rigs.RigList;


            rigList[rigNum].Freq = RigX[rigNum].Freq;
            rigList[rigNum].FreqA = RigX[rigNum].FreqA;
            rigList[rigNum].FreqB = RigX[rigNum].FreqB;


            rigList[rigNum].Pitch = RigX[rigNum].Pitch;
            rigList[rigNum].RigType = RigX[rigNum].RigType;


            rigList[rigNum].RitOffset = RigX[rigNum].RitOffset;
            //
            rigList[rigNum].Mode = OmniMapping.ParamToString(RigX[rigNum].Mode);
            rigList[rigNum].Pitch = RigX[rigNum].Pitch;
            rigList[rigNum].RigType = RigX[rigNum].RigType;
            rigList[rigNum].RitOffset = RigX[rigNum].RitOffset;

            rigList[rigNum].Rit = OmniMapping.ParamToString(RigX[rigNum].Rit);
            rigList[rigNum].Split = OmniMapping.ParamToString(RigX[rigNum].Split);

            // todo fix
            //rigList[rigNum].Status = OmniMapping.ParamToString((OmniRig.RigParamX)RigX[rigNum].Status);
            rigList[rigNum].Tx = OmniMapping.ParamToString(RigX[rigNum].Tx);
            rigList[rigNum].Vfo = OmniMapping.ParamToString(RigX[rigNum].Vfo);
            rigList[rigNum].Xit = OmniMapping.ParamToString(RigX[rigNum].Xit);
            return rigList[rigNum];
        }

        public void setMode(int rigId, string mode)
        {
            string omniMode = "undefine";
            mode = mode.ToUpper();
            omniMode = ModeToOmniMode(mode);
            Console.WriteLine("mode: {0} omnimode: {1}", mode, omniMode);
            if (mode != "undefine")
                RigX[rigId].Mode = (OmniRig.RigParamX)OmniMapping.StringToParam(omniMode);
        }

        private static string ModeToOmniMode(string mode)
        {
            string omniMode = "undefined"; ;
            switch (mode)
            {
                case "USB":
                    omniMode = "SSB_U";
                    break;
                case "LSB":
                    omniMode = "SSB_L";
                    break;
                case "AM":
                    omniMode = "AM";
                    break;
                case "FM":
                    omniMode = "FM";
                    break;
                case "DSB":
                    omniMode = "SSB_U";
                    break;
                case "CWL":
                    omniMode = "CW_L";
                    break;
                case "CWU":
                    omniMode = "CW_U";
                    break;
                case "SAM":
                    omniMode = "SSB_U";
                    break;
                case "SPEC":
                    omniMode = "SSB_U";
                    break;
                case "DIGL":
                    omniMode = "DIG_L";
                    break;
                case "DIGU":
                    omniMode = "DIG_U";
                    break;
            }

            return omniMode;
        }
        private static string OmniModeToMode(string omniMode)
        {
            string mode = "undefined";
            switch (omniMode)
            {
                case "SSB_U":
                    mode = "USB";
                    break;
                case "SSB_L":
                    mode = "LSB";
                    break;
                case "AM":
                    mode = "AM";
                    break;
                case "FM":
                    mode = "FM";
                    break;
                case "CW_L":
                    mode = "CWL";
                    break;
                case "CW_U":
                    mode = "CWU";
                    break;
                case "DIG_L":
                    mode = "DIGL";
                    break;
                case "DIG_U":
                    mode = "DIGU";
                    break;
            }

            return omniMode;
        }
        public void setFreq(int v, int freq)
        {
            Console.WriteLine("setting rig: {0} to {1}", v, freq);
            RigX[v].Freq = freq;
            RigX[v].FreqA = freq;
        }

        public void SetRigState(int rigNum, RigState state)
        {

            var rigs = Rigs.Instance;

            RigX[rigNum].Freq = state.Freq;
            setFreq(rigNum, state.Freq);
            setFreqA(rigNum, state.FreqA);
            setFreqB(rigNum, state.FreqB);

            if (state.Mode != null)
            {
                string mode = ModeToOmniMode(state.Mode);
                if (mode == "undefined")
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                RigX[rigNum].Mode = (OmniRig.RigParamX)OmniMapping.StringToParam(ModeToOmniMode(state.Mode));
                
            }

            setPitch(rigNum, state.Pitch);

            setRit(rigNum, state.Rit);
            setRitOffset(rigNum, state.RitOffset);
            // todo
            if (state.Split != null)
                RigX[rigNum].Split = (OmniRig.RigParamX)OmniMapping.StringToParam(state.Split);

            if (state.Vfo != null)
                RigX[rigNum].Vfo = (OmniRig.RigParamX)OmniMapping.StringToParam(state.Vfo);

            if (state.Xit != null)
                RigX[rigNum].Xit = (OmniRig.RigParamX)OmniMapping.StringToParam(state.Xit);
        }

        public void setRigState(int rigId, RigState state)
        {
            throw new NotImplementedException();
        }

        public void setFreqA(int rigId, int freq)
        {
            RigX[rigId].FreqA = freq;
        }

        public void setFreqB(int rigId, int freq)
        {
            RigX[rigId].FreqB = freq;
        }

        public void setPitch(int rigId, int pitch)
        {
            RigX[rigId].Pitch = pitch;
        }

        public void setRit(int rigId, string rit)
        {
            if (string.IsNullOrWhiteSpace(rit)) return;

            RigX[rigId].Rit = (OmniRig.RigParamX)OmniMapping.StringToParam(rit);
        }

        public void setRitOffset(int rigId, int ritOffset)
        {
            RigX[rigId].RitOffset = ritOffset;
        }
        // todo
        public void setVfo(int rigId, string split)
        {
            if (split != null)
                RigX[rigId].Split = (OmniRig.RigParamX)OmniMapping.StringToParam(split);
        }

        public void set(int rigId, string xit)
        {
            throw new NotImplementedException();
        }

        public static ORig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ORig();
                }
                return instance;
            }
        }
    }
}
