using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyChy.Core.Frame.Common.Helper;
using MyChy.Core.Frame.Common.Cache;
using MyChy.Core.Frame.Common;

namespace MyChy.Core.Frame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger = null;
        private readonly ICacheService _iCache = null;

        public HomeController(ILoggerFactory logFactory, ICacheService cacheService)
        {
            this._logger = logFactory.CreateLogger(nameof(HomeController));
            this._iCache = cacheService;
        }

        public IActionResult Index()
        {
           // _ICache.Set("web", "1");
            // var ss = _ICache.Get<string>("web");

            _logger.LogError("1234123123");
           // LogHelper.LogError("asd2");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
       
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
