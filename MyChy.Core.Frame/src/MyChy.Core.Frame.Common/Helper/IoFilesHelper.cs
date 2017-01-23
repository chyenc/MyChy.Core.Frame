using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyChy.Core.Frame.Common.Helper
{
    public class IoFilesHelper
    {
        /// <summary>
        /// 判断文件是否存在 真 存在
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static bool IsFile(string files)
        {
            return files.Length != 0 && File.Exists(files);
        }


        /// <summary>
        /// 返回文件的物理地址
        /// </summary>
        /// <param name="file"></param>
        public static string GetFileMapPath(string file)
        {
            //var context = HttpContext.Current;
            //string filename;
            //if (context != null)
            //{
            //    filename = context.Server.MapPath(file);
            //    if (!IsFile(filename))
            //    {
            //        filename = context.Server.MapPath("/" + file);
            //    }
            //}
            //else
            //{
              var  filename = Path.Combine(Directory.GetCurrentDirectory(), file);
          //  }
            return filename;
        }

    }
}
