using Microsoft.Owin.Hosting;
using OmniRigBus.UdpNetwork;
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
            NetworkThreadRunner.GetInstance();
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);

                    Console.WriteLine("\n\nCould not open COM object! Exiting");


                    return -1;
                }
            }
            return 0;
            Console.ReadKey();
        }
    }
}
