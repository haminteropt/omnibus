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
            app = WebApp.Start("http://localhost:7301/");
        }
        public void Stop()
        {
            app.Dispose();
        }
    }
}
