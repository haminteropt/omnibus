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
            //if (RigNumber == null) return;
            Console.WriteLine( Rig.FreqA.ToString());
            Console.WriteLine(Rig.Mode.ToString());

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
