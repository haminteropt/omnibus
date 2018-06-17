using HamBusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus
{

    public class RigBusInfo : RigBusDesc
    {
        private static RigBusInfo instance = null;
        public static RigBusInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RigBusInfo();
                }
                return instance;
            }
        }
    }
}
