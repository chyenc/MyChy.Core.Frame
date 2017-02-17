using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChy.Core.Frame.Web.Controllers
{
    public interface IFoo
    {
        string ToRead();
    }

    public class Foo : IFoo
    {
        public string ToRead()
        {
            return "Foo";
        }

    }

    public class Fii : IFoo
    {
        public string ToRead()
        {
            return "Fii";
        }

    }
}
