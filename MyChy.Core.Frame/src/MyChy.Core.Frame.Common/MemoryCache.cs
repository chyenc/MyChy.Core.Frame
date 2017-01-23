using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MyChy.Core.Frame.Common.Config;

namespace MyChy.Core.Frame.Common
{
    public class MemoryCache
    {
        private static readonly MemoryCacheConfig Config = null;

        public static readonly bool IsCache;
        // private MDictionary<string, object> theCache = new MDictionary<string, object>(2048, StringComparer.OrdinalIgnoreCase);
        //  MemcachedClient client;
        private IMemoryCache _cache;

        static MemoryCache()
        {
            // CacheManage
            if (Config != null) return;
            var config = new ConfigHelper();
            Config = config.Reader<MemoryCacheConfig>("config/MemoryCache.json");
            if (Config == null || Config.Second == 0)
            {
                Config = new MemoryCacheConfig { IsCache = false };
            }
            IsCache = Config.IsCache;
        }

        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (!IsCache) return false;
            if (key == null)
            {
                return false;
                // throw new ArgumentNullException(nameof(key));
            }
            object cached;
            return _cache.TryGetValue(key, out cached);
        }

        #region 添加缓存
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public void Set(string key, object value)
        {
            Set(key, value, Config.Second);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="second">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        public void Set(string key, object value, int second)
        {
            Set(key, value, second, DateTime.Now.AddDays(1).Date);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="second">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressTime">绝对过期时长</param>
        public void Set(string key, object value, int second, DateTime expiressTime)
        {
            var expiresSliding = DateTime.Now.AddSeconds(second) - DateTime.Now;
            var expiressAbsoulte = expiressTime - DateTime.Now;
            Set(key, value, expiresSliding, expiressAbsoulte);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        private void Set(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (!IsCache) return;
            if (key == null || value == null)
            {
                return;
            }
            //if (key == null)
            //{
            //    throw new ArgumentNullException(nameof(key));
            //}
            //if (value == null)
            //{
            //    throw new ArgumentNullException(nameof(value));
            //}
            _cache.Set(key, value,
                new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(expiresSliding)
                    .SetAbsoluteExpiration(expiressAbsoulte)
            );

        }
        #endregion

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public void Remove(string key)
        {
            if (!IsCache) return;
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            _cache.Remove(key);
        }
        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public void RemoveAll(IEnumerable<string> keys)
        {
            if (!IsCache) return;
            if (keys == null || !keys.Any())
            {
                return;
            }
            keys.ToList().ForEach(item => _cache.Remove(item));
        }

    }
}
