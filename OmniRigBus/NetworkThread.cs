﻿using HamBusLib;
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
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            var netThread = NetworkThread.GetInstance();
            rigBusDesc = OmniRigInfo.Instance;
            rigBusDesc.Command = "update";
            rigBusDesc.Id = Guid.NewGuid().ToString();
            rigBusDesc.UdpPort = netThread.rigBusDesc.UdpPort;
            rigBusDesc.TcpPort = netThread.rigBusDesc.TcpPort;
            rigBusDesc.MinVersion = 1;
            rigBusDesc.MaxVersion = 1;
            rigBusDesc.host = hostName;
            rigBusDesc.ip = myIP;
            rigBusDesc.sendSyncInfo = true;
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
                Console.WriteLine("sending data: {0}", rigBusDesc.CurrentTime);
                udpClient.Send(senddata, senddata.Length);
                Thread.Sleep(3000);
            }
        }
    }
}