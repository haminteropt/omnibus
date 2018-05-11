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
        public RigParamX Mode { get; set; }
        public int Pitch { get; set; }
        public string RigType { get; set; }
        public RigParamX Rit { get; set; }
        public int RitOffset { get; set; }
        public RigStatusX Status { get; set; }
        public string StatusStr { get; set; }
        public RigParamX Split { get; set; }
        public RigParamX Tx { get; set; }
        public RigParamX Vfo { get; set; }
        public RigParamX Xit { get; set; }
    }
}
