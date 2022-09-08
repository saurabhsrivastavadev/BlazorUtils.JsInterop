using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    internal class JSCacheStorageUtils : IJSCacheStorageUtils
    {
        private readonly Lazy<Task<IJSObjectReference>> _jsinteropModuleTask;

        private ILogger Logger { get; }

        internal JSCacheStorageUtils(IJSRuntime jsr, ILogger logger)
        {
            Logger = logger;

            _jsinteropModuleTask = new(() => jsr.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorUtils.JsInterop/cachestorageutils.js").AsTask());
        }

        // Returns the offset from UTC in minutes
        public async Task<bool> DeleteRequestsFromCache(string cacheName, string requestUrlRegex)
        {
            var module = await _jsinteropModuleTask.Value;

            bool result = false;
            try
            {
                result = await module.InvokeAsync<bool>(
                    "deleteRequestsFromCache", cacheName, requestUrlRegex);
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute deleteRequestsFromCache");
                Logger.LogError(e.Message);
            }

            return result;
        }
    }
}
