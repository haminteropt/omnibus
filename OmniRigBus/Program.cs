using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.ServiceConfigurators;

namespace OmniRigBus
{
    class Program
    {
        static int Main(string[] args)
        {
            {
                var exitCode = HostFactory.Run(c =>
                {
                    c.Service<OmniRigService>(service =>
                    {
                        ServiceConfigurator<OmniRigService> s = service;
                        s.ConstructUsing(() => new OmniRigService());
                        s.WhenStarted(a => a.Start());
                        s.WhenStopped(a => a.Stop());
                    });
                    c.SetServiceName("OmniRigHamBus");
                    c.SetDisplayName("OmniRig HamBus server");
                    c.SetDescription("Web server for OmniRig and hambus");
                });
                return (int)exitCode;
            }
            /*
            using (WebApp.Start<Startup>("http://localhost:7300"))
            {
                Console.WriteLine("Web Server is running.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
            */
        }
    }
}
