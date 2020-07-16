using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public class JsInteropPwaUtils
    {
        // Singleton Instance
        public static JsInteropPwaUtils Instance { get; internal set; }
        internal JsInteropPwaUtils() { }

        public async Task<bool> ShowPwaInstallPrompt()
        {
            return await JsInterop.JSR.InvokeAsync<bool>("showPwaInstallPrompt");
        }

        public async Task<bool> IsPwaInstalled()
        {
            return await JsInterop.JSR.InvokeAsync<bool>("isPwaInstalled");
        }
    }
}
