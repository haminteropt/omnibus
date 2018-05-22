using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocoptNet;

namespace OmniRigBus
{
    class Program
    {
        private const string usage = @"OmniRigBus.
        private string port;

    Usage:
      OmniRigBus.exe

    Options:
      -h --help     Show this screen.
      --version     Show version.
      -p port  Web port [default: 7301].
    ";
        static void Main(string[] args)
        {

            var arguments = new Docopt().Apply(usage, args, version: "OmniRigBus 0.1", optionsFirst: true, exit: true);
            foreach (var argument in arguments)
            {
                Console.WriteLine("{0} = {1}", argument.Key, argument.Value);
            }
            using (WebApp.Start<Startup>("http://localhost:7300"))
            {
                Console.WriteLine("Web Server is running.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}
