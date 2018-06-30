using HamBusLib;
using HamBusLib.UdpNetwork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmniRigBus
{
    public class NetworkThread
    {
        private UdpClient udpClient = new UdpClient();
        private static NetworkThread Instance = null;
        private Thread infoThread;
        private OmniRigInfo rigBusDesc;
        public static NetworkThread GetInstance()
        {
            if (Instance == null)
                Instance = new NetworkThread();

            return Instance;
        }
        private NetworkThread() { }

        public void StartInfoThread()
        {

            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Console.WriteLine("my ip: {0}", myIP);
            var netThread = NetworkThreadRunner.GetInstance();
            rigBusDesc = OmniRigInfo.Instance;
            rigBusDesc.Command = "update";
            rigBusDesc.Id = Guid.NewGuid().ToString();
            rigBusDesc.UdpPort = netThread.listenUdpPort;
            rigBusDesc.TcpPort = netThread.listenTcpPort;
            rigBusDesc.MinVersion = 1;
            rigBusDesc.MaxVersion = 1;
            rigBusDesc.Host = hostName;
            rigBusDesc.Ip = myIP;
            rigBusDesc.SendSyncInfo = true;
            rigBusDesc.RigType = "Unknown";
            rigBusDesc.Name = "OmniRig";
            infoThread = new Thread(SendRigBusInfo);
            infoThread.Start();
        }

        public void SendRigBusInfo()
        {
            while (true)
            {
                rigBusDesc.CurrentTime = DateTime.Now;
                udpClient.Connect("255.255.255.255", Constants.DirPortUdp);
                Byte[] senddata = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(rigBusDesc));
                udpClient.Send(senddata, senddata.Length);
                Thread.Sleep(3000);
            }
        }
    }
}
