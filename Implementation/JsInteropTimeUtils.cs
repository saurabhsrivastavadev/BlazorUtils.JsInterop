using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    internal class JsInteropTimeUtils : IJsInteropTimeUtils
    {
        private readonly Lazy<Task<IJSObjectReference>> _jsinteropModuleTask;

        private ILogger<JsInteropTimeUtils> Logger { get; set; }

        internal JsInteropTimeUtils(IJSRuntime jsr)
        {
            _jsinteropModuleTask = new(() => jsr.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorUtils.JsInterop/jsinterop.js").AsTask());
        }

        // Returns the offset from UTC in minutes
        public async Task<int> GetLocalTimezoneOffset()
        {
            var module = await _jsinteropModuleTask.Value;
            int jsTzOffset = 0;
            try
            {
                jsTzOffset = await module.InvokeAsync<int>("getLocalTimezoneOffset");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute getLocalTimezoneOffset");
                Logger.LogError(e.Message);
            }

            // JS offset and dotnet Timezoneinfo offset have opposite sign
            return jsTzOffset * -1;
        }

        public async Task<string> GetLocalTimezoneName()
        {
            var module = await _jsinteropModuleTask.Value;
            string result = "";
            try
            {
                result = await module.InvokeAsync<string>("getLocalTimezoneName");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute getLocalTimezoneName");
                Logger.LogError(e.Message);
            }
            return result;
        }
    }
}
