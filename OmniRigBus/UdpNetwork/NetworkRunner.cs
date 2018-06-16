using HamBusLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmniRigBus.UdpNetwork
{
    public class NetworkThreadRunner
    {
        private const int listenPort = 7300;
        private static NetworkThreadRunner netWorkThread = null;
        public Thread serverThread;
        public Thread clientThread;
        public string guid = Guid.NewGuid().ToString();
        public static NetworkThreadRunner StartNetworkThread()
        {
            if (netWorkThread == null)
                netWorkThread = new NetworkThreadRunner();

            return netWorkThread;
        }
        public NetworkThreadRunner()
        {
            ServerInit();
            clientInit();
        }

        private void clientInit()
        {
            serverThread.IsBackground = true;
            clientThread.Start();
        }

        private void ServerInit()
        {
            serverThread = new Thread(ServerStart);
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        private void ServerStart()
        {

            UdpClient udpClient = new UdpClient(listenPort);
            int count = 0;
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine("{0}:recv data {1} address: {2}", count++, returnData,
                    RemoteIpEndPoint.Address.ToString());
                ParseCommand(returnData);
            }
        }

        private static void ParseCommand(string returnData)
        {
            var obj = JsonConvert.DeserializeObject<UdpCmdPacket>(returnData);
            Console.WriteLine("parsed cmd");
        }

        private void SendBroadcast(UdpCmdPacket packet)
        {
            UdpClient udpClient = new UdpClient();
            udpClient.ExclusiveAddressUse = false;
            udpClient.Connect("255.255.255.255", listenPort);
            Byte[] senddata = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(packet));
            udpClient.Send(senddata, senddata.Length);
        }
    }
}
