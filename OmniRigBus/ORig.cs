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
            var rigList = rigs.RigList;

            rigList[rigNum].Freq = RigX[rigNum].Freq;
            rigList[rigNum].FreqA = RigX[rigNum].FreqA;
            rigList[rigNum].FreqB = RigX[rigNum].FreqB;

            var foo = OmniMapping.ParamStr[RigX[rigNum].Mode];
            rigList[rigNum].Mode = (int) OmniMapping.ParamStr[RigX[rigNum].Mode];
            rigList[rigNum].Pitch = RigX[rigNum].Pitch;
            rigList[rigNum].RigType = RigX[rigNum].RigType;

            rigList[rigNum].Rit = RigX[rigNum].Rit.ToString();
            rigList[rigNum].RitOffset = RigX[rigNum].RitOffset;
            rigList[rigNum].Split = RigX[rigNum].Split.ToString();
            rigList[rigNum].Status = RigX[rigNum].Status.ToString();
            rigList[rigNum].Tx = RigX[rigNum].Tx.ToString();
            rigList[rigNum].Vfo = RigX[rigNum].Vfo.ToString();
            rigList[rigNum].Xit = RigX[rigNum].Xit.ToString();
            return rigList[rigNum];
        }
        public void SetRigState(int rigNum, RigState state)
        {

            var rigs = Rigs.Instance;

            RigX[rigNum].Freq = state.Freq;
            RigX[rigNum].FreqA = state.FreqA;
            RigX[rigNum].FreqB = (int)state.FreqB;

            RigX[rigNum].Mode = (RigParamX) OmniMapping.StrParam[state.Mode];
            RigX[rigNum].Pitch = state.Pitch;

            RigX[rigNum].Rit = (RigParamX) OmniMapping.StrParam[state.Rit];
            RigX[rigNum].RitOffset = state.RitOffset;
            
            var foo = OmniMapping.StrParam[state.Split];
            RigX[rigNum].Split = (OmniRig.RigParamX) OmniMapping.StrParam[state.Split];

            RigX[rigNum].Vfo = (RigParamX)OmniMapping.StrParam[state.Vfo];
            RigX[rigNum].Xit = (RigParamX)OmniMapping.StrParam[state.Xit];
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
