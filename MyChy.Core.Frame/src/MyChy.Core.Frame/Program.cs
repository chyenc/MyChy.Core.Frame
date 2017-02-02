using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChy.Core.Frame.Common;
using MyChy.Core.Frame.Common.Cache;
using MyChy.Core.Frame.Common.Config;
using MyChy.Core.Frame.Common.Helper;

public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        // var demo = new Demo();
        XmlTest();
            //ToTest();
       // ss1 = config.Reader<MemoryCacheConfig>(path);
        ///var xx=demo.Multi(10, 2);
        // Console.WriteLine("Hello World!"+ xx);
        var ss = Console.ReadLine();

            Console.WriteLine("Hello World2");

            Console.WriteLine("Hello World2"+ ss);

            Console.ReadLine();
        }

    private static void ToTest()
    {
        string xx = "1.1";

        var x1 = xx.To<double>();

        xx = "3";
        var x2 = xx.To<EnumTest>();

        var sb=new StringBuilder("222");
        sb.Append("serwe");

        var x3 = xx.To<StringBuilder>();
    }

    public static void ConfigHelper()
    {
        var config = new ConfigHelper();
        // string path = Path.Combine(Directory.GetCurrentDirectory(), "config/MemoryCache.json");
        var ss1 = config.Reader<MemoryCacheConfig>("config/MemoryCache.json");
    }

    public static void SafeSecurityTest()
    {
  
        var sss = "asdfa";

        var yy = SafeSecurityHelper.Sha1(sss);
        sss = "我的";
        yy = SafeSecurityHelper.Sha1(sss);
        sss = "我的";
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        yy = SafeSecurityHelper.Md5Encrypt(sss, Encoding.GetEncoding("GB2312"));


    }

    public static void XmlTest()
    {
        string ss = @"
<xml>
  <return_code><![CDATA[SUCCESS]]></return_code>
  <return_msg><![CDATA[OK]]></return_msg>
</xml>
";
        var yy = StringHelper.XmlToIDictionary(ss);
    }

    }

public enum EnumTest
{
    A1=1,
    A2=2,
    A3=3,
    A4=4,

}
