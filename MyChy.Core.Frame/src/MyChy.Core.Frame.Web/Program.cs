using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyChy.Core.Frame.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UseUrl();
            //UseUrlArgs(args);
        }

        public static void Null()
        {

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }


        public static void UseUrl()
        {

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseUrls("http://192.168.16.164:5000")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public static void UseUrlArgs(string[] args)
        {
            var config = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                //.UseUrls("http://192.168.16.164:5000")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
