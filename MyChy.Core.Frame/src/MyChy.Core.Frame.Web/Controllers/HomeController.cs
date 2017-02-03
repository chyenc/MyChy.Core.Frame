using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyChy.Core.Frame.Common.Helper;

namespace MyChy.Core.Frame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger = null;

        public HomeController(ILoggerFactory logFactory)
        {
            this._logger = logFactory.CreateLogger(nameof(HomeController));
        }

        public IActionResult Index()
        {
            _logger.LogError("1234123123");
            LogHelper.LogError("asd2");
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
