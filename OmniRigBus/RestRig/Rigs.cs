using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus.RestRig
{
    public class Rigs
    {
        public List<RigState> RigList { get; private set; }

        private static Rigs instance = null;
        private Rigs()
        {
            RigList = new List<RigState>();

        }

        public void PopulateRigs()
        {
            RigList.Add(new RigState());
            RigList.Add(new RigState());
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
