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
            RigState rigState = SetRigState(RigNumber);
            var json = JsonConvert.SerializeObject(rigState);


        }

        public RigState SetRigState(int rigNum)
        {

            var rigs = Rigs.Instance;
            var rigList = rigs.RigList;

            rigList[rigNum].Freq = RigX[rigNum].Freq;
            rigList[rigNum].FreqA = RigX[rigNum].FreqA;
            rigList[rigNum].FreqB = RigX[rigNum].FreqB;
 
            rigList[rigNum].Mode = RigX[rigNum].Mode.ToString();
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
