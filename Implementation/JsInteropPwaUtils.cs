using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    internal class JsInteropPwaUtils : IJsInteropPwaUtils
    {
        private IJSRuntime _jsr;
        internal JsInteropPwaUtils(IJSRuntime jsr)
        {
            _jsr = jsr;
        }

        public async Task<bool> ShowPwaInstallPrompt()
        {
            return await _jsr.InvokeAsync<bool>("showPwaInstallPrompt");
        }

        public async Task<bool> IsPwaInstalled()
        {
            return await _jsr.InvokeAsync<bool>("isPwaInstalled");
        }
    }
}
