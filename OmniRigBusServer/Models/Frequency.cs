using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniRigBusServer.Models
{
    public class RadioTuningInfo
    {
        public string mode;
        public decimal frequency;
        public RadioTuningInfo()
        {
            mode = "USB";
            frequency = 14.213M;
        }
       
    }
}
