using System;
using log4net.Config;
using Topshelf;

namespace TvZappr.Web
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\r\nSTARTING TVZAPPR WEB SERVICE\r\n");

            HostFactory.Run(x =>
            {
                x.Service<Bootstrapper>(b =>
                {
                    b.ConstructUsing(_ => new Bootstrapper());
                    b.WhenStarted(bs =>
                    {
                        XmlConfigurator.Configure();
                        bs.Run();
                    });
                    b.WhenStopped(bs => bs.Dispose());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("TvZappr.Web");
                x.SetDisplayName("TvZappr.Web");
            });

            Console.ReadLine();
        }
    }
}
