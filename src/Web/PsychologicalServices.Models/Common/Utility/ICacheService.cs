using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface ICacheService
    {
        T Get<T>(string key, Func<T> getValue, DateTime absoluteExpiration);

        void Set(string key, object value, DateTime absoluteExpiration);

        object Remove(string key);

        bool Contains(string key);

        IDictionary<string, object> GetCachedItemsList();
    }
}
