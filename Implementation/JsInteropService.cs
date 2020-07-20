using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.JsInterop
{
    public class JsInteropService : IJsInteropService
    {
        private IJSRuntime _jsr;

        public IJsInteropStorageUtils StorageUtils { get; private set; }
        public IJsInteropPwaUtils PwaUtils { get; private set; }
        public IJsInteropTimeUtils TimeUtils { get; private set; }

        public JsInteropService(IJSRuntime jsr)
        {
            _jsr = jsr;
            StorageUtils = new JsInteropStorageUtils(jsr);
            PwaUtils = new JsInteropPwaUtils(jsr);
            TimeUtils = new JsInteropTimeUtils(jsr);
        }
    }
}
