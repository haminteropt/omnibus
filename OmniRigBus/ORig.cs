using HamBusLib;
using Newtonsoft.Json;
using OmniRig;
using OmniRigBus;
using OmniRigBus.OmniRigCOM;
using OmniRigBus.RestRig;
using HamBusLib.UdpNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;



namespace OmniRigBus
{
    public class OmniRigInterface : IRig
    {
        private static OmniRigInterface instance = null;
        private UdpServer netRunner = UdpServer.GetInstance();
        private OmniRigX OmniRig;
        private List<RigX> RigX = new List<RigX>();

        private Rigs rigState = Rigs.Instance;
        private RigOperatingState optState = RigOperatingState.Instance;

        private OmniRigInterface()
        {

            OmniRig = new OmniRigX();
            OmniRig.ParamsChange += ParamsChangeEvent;
            RigX.Add(OmniRig.Rig1);
            RigX.Add(OmniRig.Rig2);
            RigState rigState = GetRigState(1);
            sendRigBusState(rigState);
            var rigBusInfo = OmniRigInfo.Instance;
            rigBusInfo.Command = "update";
            rigBusInfo.RigType = OmniRig.Rig1.RigType;
            rigBusInfo.TcpPort = netRunner.listenTcpPort;
            rigBusInfo.UdpPort = netRunner.listenUdpPort;
            rigBusInfo.Type = "RigBusDesc";
            rigBusInfo.Id = Guid.NewGuid().ToString();
            rigBusInfo.SendSyncInfo = true;
            rigBusInfo.MaxVersion = 1;
            rigBusInfo.MinVersion = 1;
            rigBusInfo.SendSyncInfo = true;
            rigBusInfo.Name = "OmniRigBus";
            rigBusInfo.Time = DateTimeUtils.ConvertToUnixTime(DateTime.Now);
            optState.newStateDelegate = SetRigOptState;

        }
        private void ParamsChangeEvent(int RigNumber, int Params)
        {
            if (RigNumber != 1 && RigNumber != 2) return;
            Console.WriteLine(String.Format("Param: {0}", Params));
            RigState rigState = GetRigState(RigNumber - 1);
            Console.WriteLine("param event");
            sendRigBusState(rigState);
        }

        private void sendRigBusState(RigState rigState)
        {
            var netRunniner = UdpServer.GetInstance();
            var net = OmniRigInfoThread.GetInstance();

            var state = RigOperatingState.Instance;
            var rigBusDesc = OmniRigInfo.Instance;
            state.Id = rigBusDesc.Id;
            state.Type = "RigOperatingState";
            state.Command = "StateUpdate";
            state.Freq = rigState.Freq;
            state.FreqA = rigState.Freq;
            state.Mode = rigState.Mode;
            Console.WriteLine("Freq: {0} - Mode: {1}", state.Freq,
                state.Mode);
            netRunner.SendBroadcast(state, 7300);
        }

        public RigState GetRigState(int rigNum)
        {

            var rigs = Rigs.Instance;
            rigs.PopulateRigs();
            var rigList = rigs.RigList;


            rigList[rigNum].Freq = RigX[rigNum].Freq;
            rigList[rigNum].FreqA = RigX[rigNum].FreqA;
            rigList[rigNum].FreqB = RigX[rigNum].FreqB;


            rigList[rigNum].Pitch = RigX[rigNum].Pitch;
            rigList[rigNum].RigType = RigX[rigNum].RigType;


            rigList[rigNum].RitOffset = RigX[rigNum].RitOffset;
            //
            rigList[rigNum].Mode = OmniMapping.ParamToString(RigX[rigNum].Mode);
            rigList[rigNum].Pitch = RigX[rigNum].Pitch;
            rigList[rigNum].RigType = RigX[rigNum].RigType;
            rigList[rigNum].RitOffset = RigX[rigNum].RitOffset;

            rigList[rigNum].Rit = OmniMapping.ParamToString(RigX[rigNum].Rit);
            rigList[rigNum].Split = OmniMapping.ParamToString(RigX[rigNum].Split);

            // todo fix
            //rigList[rigNum].Status = OmniMapping.ParamToString((OmniRig.RigParamX)RigX[rigNum].Status);
            rigList[rigNum].Tx = OmniMapping.ParamToString(RigX[rigNum].Tx);
            rigList[rigNum].Vfo = OmniMapping.ParamToString(RigX[rigNum].Vfo);
            rigList[rigNum].Xit = OmniMapping.ParamToString(RigX[rigNum].Xit);
            return rigList[rigNum];
        }

        public void SetMode(int rigId, string mode)
        {
            string omniMode = "undefine";
            mode = mode.ToUpper();
            omniMode = ModeToOmniMode(mode);
            Console.WriteLine("mode: {0} omnimode: {1}", mode, omniMode);
            if (mode != "undefine")
                RigX[rigId].Mode = (OmniRig.RigParamX)OmniMapping.StringToParam(omniMode);
        }

        private static string ModeToOmniMode(string mode)
        {
            string omniMode = "undefined"; ;
            switch (mode)
            {
                case "USB":
                    omniMode = "SSB_U";
                    break;
                case "LSB":
                    omniMode = "SSB_L";
                    break;
                case "AM":
                    omniMode = "AM";
                    break;
                case "FM":
                    omniMode = "FM";
                    break;
                case "DSB":
                    omniMode = "SSB_U";
                    break;
                case "CWL":
                    omniMode = "CW_L";
                    break;
                case "CWU":
                    omniMode = "CW_U";
                    break;
                case "SAM":
                    omniMode = "SSB_U";
                    break;
                case "SPEC":
                    omniMode = "SSB_U";
                    break;
                case "DIGL":
                    omniMode = "DIG_L";
                    break;
                case "DIGU":
                    omniMode = "DIG_U";
                    break;
            }

            return omniMode;
        }
        private static string OmniModeToMode(string omniMode)
        {
            string mode = "undefined";
            switch (omniMode)
            {
                case "SSB_U":
                    mode = "USB";
                    break;
                case "SSB_L":
                    mode = "LSB";
                    break;
                case "AM":
                    mode = "AM";
                    break;
                case "FM":
                    mode = "FM";
                    break;
                case "CW_L":
                    mode = "CWL";
                    break;
                case "CW_U":
                    mode = "CWU";
                    break;
                case "DIG_L":
                    mode = "DIGL";
                    break;
                case "DIG_U":
                    mode = "DIGU";
                    break;
            }

            return omniMode;
        }
        public void SetFreq(int v, int freq)
        {
            Console.WriteLine("setting rig: {0} to {1}", v, freq);
            RigX[v].Freq = freq;
            RigX[v].FreqA = freq;
        }

        public void SetRigOptState(OperatingState state)
        {
            var newState = new RigState();
            newState.FromOperatingState(state);
            SetRigState(0, newState);
        }
        public void SetRigState(int rigNum, RigState state)
        {

            var rigs = Rigs.Instance;

            RigX[rigNum].Freq = state.Freq;
            SetFreq(rigNum, state.Freq);
            SetFreqA(rigNum, state.FreqA);
            SetFreqB(rigNum, state.FreqB);

            if (state.Mode != null)
            {
                string mode = ModeToOmniMode(state.Mode);
                if (mode == "undefined")
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                RigX[rigNum].Mode = (OmniRig.RigParamX)OmniMapping.StringToParam(ModeToOmniMode(state.Mode));

            }

            SetPitch(rigNum, state.Pitch);

            SetRit(rigNum, state.Rit);
            SetRitOffset(rigNum, state.RitOffset);
            // todo
            if (state.Split != null)
                RigX[rigNum].Split = (OmniRig.RigParamX)OmniMapping.StringToParam(state.Split);

            if (state.Vfo != null)
                RigX[rigNum].Vfo = (OmniRig.RigParamX)OmniMapping.StringToParam(state.Vfo);

            if (state.Xit != null)
                RigX[rigNum].Xit = (OmniRig.RigParamX)OmniMapping.StringToParam(state.Xit);
        }

        public void SetFreqA(int rigId, int freq)
        {
            RigX[rigId].FreqA = freq;
        }

        public void SetFreqB(int rigId, int freq)
        {
            RigX[rigId].FreqB = freq;
        }

        public void SetPitch(int rigId, int pitch)
        {
            RigX[rigId].Pitch = pitch;
        }

        public void SetRit(int rigId, string rit)
        {
            if (string.IsNullOrWhiteSpace(rit)) return;

            RigX[rigId].Rit = (OmniRig.RigParamX)OmniMapping.StringToParam(rit);
        }

        public void SetRitOffset(int rigId, int ritOffset)
        {
            RigX[rigId].RitOffset = ritOffset;
        }
        // todo
        public void SetVfo(int rigId, string split)
        {
            if (split != null)
                RigX[rigId].Split = (OmniRig.RigParamX)OmniMapping.StringToParam(split);
        }

        public void SetXit(int rigId, string xit)
        {
            throw new NotImplementedException();
        }

        public static OmniRigInterface Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OmniRigInterface();
                }
                return instance;
            }
        }
    }
}
