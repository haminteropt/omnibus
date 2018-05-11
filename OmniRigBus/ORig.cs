using Newtonsoft.Json;
using OmniRig;
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
        private RigX Rig;
        private RigState rigState = RigState.Instance;

        private ORig()
        {
            OmniRig = new OmniRigX();
            OmniRig.ParamsChange += ParamsChangeEvent;
            Rig = OmniRig.Rig1;
        }
        private void ParamsChangeEvent(int RigNumber, int Params)
        {
            if (RigNumber != 1) return;

            var rigState = RigState.Instance;

            rigState.Freq = Rig.Freq;
            rigState.FreqA = Rig.FreqA;
            rigState.FreqB = Rig.FreqB;

            rigState.Mode = Rig.Mode.ToString();
            rigState.Pitch = Rig.Pitch;
            rigState.RigType = Rig.RigType;

            rigState.Rit = Rig.Rit.ToString();
            rigState.RitOffset = Rig.RitOffset;
            rigState.Split = Rig.Split.ToString();
            rigState.Status = Rig.Status.ToString();
            rigState.Tx = Rig.Tx.ToString();
            rigState.Vfo = Rig.Vfo.ToString();
            rigState.Xit = Rig.Xit.ToString();

            Console.WriteLine( Rig.FreqA.ToString());
            Console.WriteLine(Rig.Mode.ToString());
            var json = JsonConvert.SerializeObject(rigState);
            Console.Write(json);

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
