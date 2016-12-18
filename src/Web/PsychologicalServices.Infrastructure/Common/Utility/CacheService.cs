using PsychologicalServices.Models.Common.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class CacheService : ICacheService
    {
        private readonly ObjectCache _Cache;

        public CacheService(ObjectCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException("cache");
            }

            _Cache = cache;
        }

        public T Get<T>(string key, Func<T> getValue, DateTime absoluteExpiration)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            var value = _Cache.Get(key);
            if ((getValue != null) && (value == null || !(value is T)))
            {
                value = getValue();
                _Cache.Add(key, value, absoluteExpiration);
            }
            return (value != null) ? (T)value : default(T);
        }

        public void Set(string key, object value, DateTime absoluteExpiration)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            _Cache.Set(key, value, absoluteExpiration);
        }

        public object Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            return _Cache.Remove(key);
        }

        public IDictionary<string, object> GetCachedItemsList()
        {
            var dict = new Dictionary<string, object>();

            foreach (var kvp in _Cache)
            {
                dict.Add(kvp.Key, kvp.Value);
            }

            return dict;
        }
    }
}
