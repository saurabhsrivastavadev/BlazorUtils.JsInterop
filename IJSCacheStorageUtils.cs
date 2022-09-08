using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public interface IJSCacheStorageUtils
    {
        /// <summary>
        /// Delete all requests matching the regex from the specified cache.
        /// </summary>
        /// <param name="cacheName"></param>
        /// <param name="requestUrlRegex">
        /// string representing the regex pattern to match request url.
        /// </param>
        /// <returns></returns>
        public Task<bool> DeleteRequestsFromCache(string cacheName, string requestUrlRegex);
    }
}
