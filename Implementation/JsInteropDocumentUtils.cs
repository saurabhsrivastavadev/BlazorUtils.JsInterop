﻿using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public class JsInteropDocumentUtils : IJsInteropDocumentUtils
    {
        private readonly Lazy<Task<IJSObjectReference>> _jsinteropModuleTask;

        private ILogger Logger { get; }

        public IJsInteropDocumentUtils.DocumentVisibilityChangeCallbackType 
            DocumentVisibilityChangeCallback { get; set; }

        // Hold instance for callback invocation from javascript
        private static WeakReference<JsInteropDocumentUtils> Instance { get; set; }

        internal JsInteropDocumentUtils(IJSRuntime jsr, ILogger logger)
        {
            if (Instance != null)
            {
                throw new Exception("Only one instance of FirebaseGoogleAuthService allowed.");
            }

            Instance = new WeakReference<JsInteropDocumentUtils>(this);

            Logger = logger;

            _jsinteropModuleTask = new(() => jsr.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorUtils.JsInterop/jsinterop.js").AsTask());
        }

        public async Task EnableVisibilityChangeEvent()
        {
            var module = await _jsinteropModuleTask.Value;
            try
            {
                await module.InvokeVoidAsync("enableVisibilityChangeEvent",
                    "BlazorUtils.JsInterop", "OnDocumentVisibilityChangedJsCallback");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute enableVisibilityChangeEvent");
                Logger.LogError(e.Message);
            }
        }

        public async Task DisableVisibilityChangeEvent()
        {
            var module = await _jsinteropModuleTask.Value;
            try
            {
                await module.InvokeVoidAsync("disableVisibilityChangeEvent");
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to execute disableVisibilityChangeEvent");
                Logger.LogError(e.Message);
            }
        }

        [JSInvokable]
        public static void OnDocumentVisibilityChangedJsCallback(bool isVisible)
        {
            JsInteropDocumentUtils instance;
            if (Instance.TryGetTarget(out instance))
            {
                instance.DocumentVisibilityChangeCallback.Invoke(isVisible);
            }
            else
            {
                Console.WriteLine("Failed to get auth service weak reference instance");
            }
        }
    }
}
