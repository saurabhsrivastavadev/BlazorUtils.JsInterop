using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public class JsInteropStorageUtils
    {
        // Singleton Instance
        public static JsInteropStorageUtils Instance { get; internal set; }
        internal JsInteropStorageUtils() { }

        public async Task<string> LocalStorageGetItem(string key)
        {
            return await JsInterop.JSR.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task<string> LocalStorageSetItem(string key, string value)
        {
            return await JsInterop.JSR.InvokeAsync<string>("localStorage.setItem", key, value);
        }
    }
}
