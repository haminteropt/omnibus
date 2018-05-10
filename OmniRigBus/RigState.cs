using OmniRig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus
{
    public class RigState
    {
        public static RigState Instance
        {
            get {
                if (instance == null)
                {
                    instance = new RigState();
                }
                return instance;
            }
        }
        private static RigState instance = null;

        public int Freq { get; set; }
        public int FreqA { get; set; }
        public int FreqB { get; set; }
        public int Mode { get; set; }
        public int Pitch { get; set; }
        public int Rit { get; set; }
        public int RitOffset { get; set; }
        public int RigType { get; set; }
        public int Status { get; set; }
        public string StatusStr { get; set; }
    }
}
