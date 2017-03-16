using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MyChy.Core.Frame.Common.Cache;
using MyChy.Core.Frame.Common.EfData.Config;
using MyChy.Core.Frame.Common.Helper;

namespace MyChy.Core.Frame.Common.EfData
{
    public class EntityFrameworkHelper
    {
         public static EntityFrameworkConfig ReadConfiguration(string file= "config/EntityFramework.config")
        {
            var config = new ConfigHelper();
            var entityconfig = new EntityFrameworkConfig();
            try
            {
                entityconfig = config.Reader<EntityFrameworkConfig>(file);
                switch (entityconfig.BaseType.ToLower())
                {
                    case "mssql":
                        entityconfig.SqlType = EntityFrameworkType.MsSql;
                        break;
                    case "mysql":
                        entityconfig.SqlType = EntityFrameworkType.MySql;
                        break;
                    case "oracle":
                        entityconfig.SqlType = EntityFrameworkType.Oracle;
                        break;
                    case "sqlite":
                        entityconfig.SqlType = EntityFrameworkType.Sqlite;
                        break;
                    case "":
                        entityconfig.SqlType = EntityFrameworkType.Null;
                        break;
                    default:
                        entityconfig.SqlType = EntityFrameworkType.MsSql;
                        break;
                }
                if (string.IsNullOrEmpty(entityconfig.Connect))
                {
                    entityconfig.SqlType = EntityFrameworkType.Null;
                }
            }
            catch (Exception exception)
            {
                entityconfig.SqlType = EntityFrameworkType.Null;
                LogHelper.Log(exception);
            }
             return entityconfig;
             //finally
             //{
             //    Config.IsCache = false;
             //    IsCacheError = true;
             //}

        }
    }
}
