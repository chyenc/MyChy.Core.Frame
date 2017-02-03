using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyChy.Core.Frame.Common.Helper;

namespace MyChy.Core.Frame.Common.Extensions
{

    public static class HttpContextExtension
    {
        public static string GetUserIp(this HttpContext context)
        {
            var ip = "0.0.0.0";
            try
            {
                ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = context.Connection.RemoteIpAddress.ToString();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
                ip = "0.0.0.1";
            }
            return ip;
        }
    }
}
