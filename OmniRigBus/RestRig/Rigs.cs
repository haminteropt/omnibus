using OmniRigBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus.RestRig
{
    public class Rigs
    {
        public List<RigStatePacket> RigList { get; private set; }

        private static Rigs instance = null;
        private Rigs()
        {
            RigList = new List<RigStatePacket>();

        }

        public void PopulateRigs()
        {
            if (RigList.Count != 0) return;
            RigList.Add(new RigStatePacket());
            RigList.Add(new RigStatePacket());
        }

        public static Rigs Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Rigs();
                }
                return instance;
            }
        }
    }
}
