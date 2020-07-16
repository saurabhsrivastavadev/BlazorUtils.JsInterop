using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public class JsInteropTimeUtils
    {
        // Singleton Instance
        public static JsInteropTimeUtils Instance { get; internal set; }
        internal JsInteropTimeUtils() { }

        // Returns the offset from UTC in minutes
        public async Task<int> GetLocalTimezoneOffset()
        {
            int jsTzOffset = await JsInterop.JSR.InvokeAsync<int>("getLocalTimezoneOffset");
            // JS offset and dotnet Timezoneinfo offset have opposite sign
            return jsTzOffset * -1;
        }

        public async Task<string> GetLocalTimezoneName()
        {
            return await JsInterop.JSR.InvokeAsync<string>("getLocalTimezoneName");
        }
    }
}
