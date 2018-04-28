using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus
{
    public class OmniRigOle
    {
        static public OmniRigOle instance = null;
        private Type rigOle;
        public Type RigOle { get => rigOle; set => rigOle = value; }
        public OmniRigOle()
        {
            if (instance == null)
            {
                instance = this;
                RigOle = Type.GetTypeFromProgID("OmniRig.OmniRigX");
            }
        }
    }

}
