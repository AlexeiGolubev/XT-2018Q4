using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;

namespace Epam.Task7.BLL
{
    public class CacheLogic : ICacheLogic
    {
        private static Dictionary<string, object> data = new Dictionary<string, object>();

        public bool Add<T>(string key, T value)
        {
            if (data.ContainsKey(key))
            {
                return false;
            }

            data.Add(key, value);

            return true;
        }

        public T Get<T>(string key)
        {
            if (!data.ContainsKey(key))
            {
                return default(T);
            }

            return (T)data[key];
        }

        public bool Delete(string key)
        {
            return data.Remove(key);
        }
    }
}
