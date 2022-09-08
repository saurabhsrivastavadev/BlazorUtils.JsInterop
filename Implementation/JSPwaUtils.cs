using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    internal class JSPwaUtils : IJSPwaUtils
    {
        private readonly Lazy<Task<IJSObjectReference>> _jsinteropModuleTask;

        private ILogger Logger { get; }

        private bool _isPwaInitDone = false;

        internal JSPwaUtils(IJSRuntime jsr, ILogger logger)
        {
            Logger = logger;

            _jsinteropModuleTask = new(() => jsr.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorUtils.JsInterop/pwautils.js").AsTask());
        }

        public async Task PwaInit()
        {
            var module = await _jsinteropModuleTask.Value;
            try
            {
                await module.InvokeVoidAsync("pwaInit");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute showPwaInstallPrompt");
                Logger.LogError(e.Message);
            }
            _isPwaInitDone = true;
        }

        public async Task<bool> ShowPwaInstallPrompt()
        {
            if (!_isPwaInitDone) await PwaInit();

            var module = await _jsinteropModuleTask.Value;
            bool result = false;
            try
            {
                result = await module.InvokeAsync<bool>("showPwaInstallPrompt");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute showPwaInstallPrompt");
                Logger.LogError(e.Message);
            }

            return result;
        }

        public async Task<bool> IsPwaInstalled()
        {
            if (!_isPwaInitDone) await PwaInit();

            var module = await _jsinteropModuleTask.Value;
            bool result = false;
            try
            {
                result = await module.InvokeAsync<bool>("isPwaInstalled");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute isPwaInstalled");
                Logger.LogError(e.Message);
            }

            return result;
        }
    }
}
