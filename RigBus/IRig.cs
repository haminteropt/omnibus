using System;
using System.Collections.Generic;
using System.Text;

namespace RigBus
{
    public interface IRig
    {
        void setRigState(int rigId, RigState state);
        void setMode(int rigId, string mode);
        void setFreq(int rigId, int freq);
        void setFreqA(int rigId, int freq);
        void setFreqB(int rigId, int freq);
        void setPitch(int rigId, int pitch);
        void setRit(int rigId, string rit);
        void setRitOffset(int rigId, int freq);
        void setVfo(int rigId, string freq);
        void set(int rigId, string xit);
    }
}
