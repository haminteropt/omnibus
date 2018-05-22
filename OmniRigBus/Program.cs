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
        private const string usage = @"Naval Fate.

    Usage:
      OmniRigBus.exe ship new <name>...
      OmniRigBus.exe ship <name> move <x> <y> [--speed=<kn>]
      OmniRigBus.exe ship shoot <x> <y>
      OmniRigBus.exe mine (set|remove) <x> <y> [--moored | --drifting]
      OmniRigBus.exe (-h | --help)
      OmniRigBus.exe --version

    Options:
      -h --help     Show this screen.
      --version     Show version.
      --speed=<kn>  Speed in knots [default: 10].
      --moored      Moored (anchored) mine.
      --drifting    Drifting mine.

    ";
        static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "OmniRigBus 0.1", exit: true);
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
