﻿using HamBusLib;
using HamBusLib.Models;
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
    public class OmniRigInfoThread
    {
        private UdpClient udpClient = new UdpClient();
        private static OmniRigInfoThread Instance = null;
        private Thread infoThread;
        private OmniRigInfo rigBusDesc;
        public static OmniRigInfoThread GetInstance()
        {
            if (Instance == null)
                Instance = new OmniRigInfoThread();

            return Instance;
        }
        private OmniRigInfoThread() { }

        public void StartInfoThread()
        {

            string hostName = NetworkUtils.getHostName();
            // Get the IP  
            string myIP = NetworkUtils.getIpAddress();
            Console.WriteLine("my ip: {0}", myIP);
            var netThread = UdpServer.GetInstance();
            rigBusDesc = OmniRigInfo.Instance;
            rigBusDesc.Command = "update";

            rigBusDesc.UdpPort = netThread.listenUdpPort;
            rigBusDesc.TcpPort = netThread.listenTcpPort;
            rigBusDesc.MinVersion = 1;
            rigBusDesc.MaxVersion = 1;
            rigBusDesc.Host = hostName;
            rigBusDesc.Ip = myIP;
            rigBusDesc.SendSyncInfo = true;
            rigBusDesc.RigType = "Unknown";
            rigBusDesc.Name = "OmniRig RigBus";
            rigBusDesc.Description = "OmniRig RigBus";
            infoThread = new Thread(SendRigBusInfo);
            infoThread.Start();
        }
        //https://stackoverflow.com/questions/22852781/how-to-do-network-discovery-using-udp-broadcast
        public void SendRigBusInfo()
        {
            DirGreetingList dirList = DirGreetingList.Instance; 
            var ServerEp = new IPEndPoint(IPAddress.Any, 0);
            udpClient.EnableBroadcast = true;
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            while (true)
            {
                try
                {
                    ServerEp = SendUpdateResponse(ServerEp);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                }
            }
        }

        private IPEndPoint SendUpdateResponse(IPEndPoint ServerEp)
        {
            Byte[] senddata = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(rigBusDesc));
            rigBusDesc.Time = DateTimeUtils.ConvertToUnixTime(DateTime.Now);

            udpClient.Send(senddata, senddata.Length, new IPEndPoint(IPAddress.Broadcast, 7300));
            Console.WriteLine("Sending Data");
            var ServerResponseData = udpClient.Receive(ref ServerEp);
            var ServerResponse = Encoding.ASCII.GetString(ServerResponseData);
            Console.WriteLine("Recived {0} from {1} port {2}", ServerResponse,
                ServerEp.Address.ToString(), ServerEp.Port);
            var dirService = DirectoryBusGreeting.ParseCommand(ServerResponse);
            DirGreetingList.Instance.Add(dirService);
            Thread.Sleep(3000);
            return ServerEp;
        }
    }
}
