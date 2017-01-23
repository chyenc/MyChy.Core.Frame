using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyChy.Core.Frame.Common;
using MyChy.Core.Frame.Common.Config;
public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           // var demo = new Demo();
            var config = new ConfigHelper();
       // string path = Path.Combine(Directory.GetCurrentDirectory(), "config/MemoryCache.json");
        var ss1 = config.Reader<MemoryCacheConfig>("config/MemoryCache.json");
       // ss1 = config.Reader<MemoryCacheConfig>(path);
        ///var xx=demo.Multi(10, 2);
        // Console.WriteLine("Hello World!"+ xx);
        var ss = Console.ReadLine();

            Console.WriteLine("Hello World2");

            Console.WriteLine("Hello World2"+ ss);

            Console.ReadLine();
        }
    }
