using System;
using System.Collections.Generic;
using System.Text;

namespace OmniRigBus
{
    public interface IRig
    {
        void SetRigState(int rigId, RigStatePacket state);
        void SetMode(int rigId, string mode);
        void SetFreq(int rigId, int freq);
        void SetFreqA(int rigId, int freq);
        void SetFreqB(int rigId, int freq);
        void SetPitch(int rigId, int pitch);
        void SetRit(int rigId, string rit);
        void SetRitOffset(int rigId, int freq);
        void SetVfo(int rigId, string freq);
        void SetXit(int rigId, string xit);
    }
}
