using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    internal class JsInteropTimeUtils : IJsInteropTimeUtils
    {
        private IJSRuntime _jsr;
        internal JsInteropTimeUtils(IJSRuntime jsr)
        {
            _jsr = jsr;
        }

        // Returns the offset from UTC in minutes
        public async Task<int> GetLocalTimezoneOffset()
        {
            int jsTzOffset = await _jsr.InvokeAsync<int>("getLocalTimezoneOffset");
            // JS offset and dotnet Timezoneinfo offset have opposite sign
            return jsTzOffset * -1;
        }

        public async Task<string> GetLocalTimezoneName()
        {
            return await _jsr.InvokeAsync<string>("getLocalTimezoneName");
        }
    }
}
