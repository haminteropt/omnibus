using Newtonsoft.Json;
using OmniRig;
using OmniRigBus.RestRig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OmniRigBus
{
    public class ORig
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

        internal void setMode(int rigId, string mode)
        {
            string omniMode = "undefine";
            mode = mode.ToUpper();
            switch(mode)
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
            Console.WriteLine("mode: {0} omnimode: {1}", mode,omniMode);
            if (mode != "undefine")
                RigX[rigId].Mode = (RigParamX)OmniMapping.StringToParam(omniMode);
        }

        internal void setFreq(int v, int freq)
        {
            Console.WriteLine("setting rig: {0} to {1}", v, freq);
            RigX[v].Freq = freq;
            RigX[v].FreqA = freq;
        }

        public void SetRigState(int rigNum, RigState state)
        {

            var rigs = Rigs.Instance;

            RigX[rigNum].Freq = state.Freq;
            RigX[rigNum].FreqA = state.FreqA;
            RigX[rigNum].FreqB = (int)state.FreqB;

            if (state.Mode != null)
                RigX[rigNum].Mode = (RigParamX)OmniMapping.StringToParam(state.Mode);


            RigX[rigNum].Pitch = state.Pitch;

            if (state.Rit != null)
                RigX[rigNum].Rit = (RigParamX)OmniMapping.StringToParam(state.Rit);

            RigX[rigNum].RitOffset = state.RitOffset;

            if (state.Split != null)
                RigX[rigNum].Split = (RigParamX)OmniMapping.StringToParam(state.Split);

            if (state.Vfo != null)
                RigX[rigNum].Vfo = (RigParamX)OmniMapping.StringToParam(state.Vfo);

            if (state.Xit != null)
                RigX[rigNum].Xit = (RigParamX)OmniMapping.StringToParam(state.Xit);
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
