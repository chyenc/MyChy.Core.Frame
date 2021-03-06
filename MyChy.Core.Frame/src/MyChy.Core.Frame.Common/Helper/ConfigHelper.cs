﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyChy.Core.Frame.Common.Helper;

namespace MyChy.Core.Frame.Common.Helper
{
    public class ConfigHelper
    {
        public T Reader<T>(string fileConfig) where T : class, new()
        {
            var configurationBuilder = new ConfigurationBuilder();
            try
            {
                var file = FileHelper.GetFileMapPath(fileConfig);
                configurationBuilder.AddJsonFile(file);
                return configurationBuilder.Build().Get<T>();
            }
            catch (Exception exception)
            {
                LogHelper.Log(exception);
                return default(T);
            }
        }
    }
}
