using HamBusLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus
{

    public class OmniRigInfo : RigBusInfo
    {
        private static OmniRigInfo instance = null;
        public static OmniRigInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OmniRigInfo();
                }
                return instance;
            }
        }
    }
}
