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
        public int Freq { get; set; }
        public int FreqA { get; set; }
        public int FreqB { get; set; }
        public string Mode { get; set; }
        public int Pitch { get; set; }
        public string RigType { get; set; }
        public string Rit { get; set; }
        public int RitOffset { get; set; }
        public string Status { get; set; }
        public string StatusStr { get; set; }
        public string Split { get; set; }
        public string Tx { get; set; }
        public string Vfo { get; set; }
        public string Xit { get; set; }
    }
}
