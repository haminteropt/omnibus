using HamBusLib;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniRigBus
{
    public class OmniRigService
    {
        private IDisposable app;
        public void Start()
        {
            int httpPort = IpPorts.TcpPort;
            var url = string.Format("http://+:{0}/", httpPort);
            app = WebApp.Start(url);
        }
        public void Stop()
        {
            app.Dispose();
        }
    }
}
