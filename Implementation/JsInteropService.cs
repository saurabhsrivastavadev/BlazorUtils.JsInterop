using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.JsInterop
{
    public class JsInteropService : IJsInteropService
    {
        public IJsInteropStorageUtils StorageUtils { get; private set; }
        public IJsInteropPwaUtils PwaUtils { get; private set; }
        public IJsInteropTimeUtils TimeUtils { get; private set; }
        public IJsInteropDocumentUtils DocumentUtils { get; private set; }

        public JsInteropService(IJSRuntime jsr, ILogger<JsInteropService> logger)
        {
            StorageUtils = new JsInteropStorageUtils(jsr, logger);
            PwaUtils = new JsInteropPwaUtils(jsr, logger);
            TimeUtils = new JsInteropTimeUtils(jsr, logger);
            DocumentUtils = new JsInteropDocumentUtils(jsr, logger);
        }
    }
}
