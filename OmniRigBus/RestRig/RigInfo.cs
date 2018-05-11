using OmniRig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus.RestRig
{
    public class RigInfo
    {
        public static RigInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RigInfo();
                }
                return instance;
            }
        }

        private static RigInfo instance = null;
        public int InterfaceVersion { get; set; }
        public int SoftwareVersion { get; set; }
        public bool DialogVisible { get; set; }
        public string RigType { get; set; }
        public int ReadableParams { get; set; }
        public int WriteableParams { get; set; }
    }
}
