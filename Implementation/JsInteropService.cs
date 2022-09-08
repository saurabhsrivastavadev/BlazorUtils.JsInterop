using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.JsInterop
{
    public class JsInteropService : IJsInteropService
    {
        public IJSLocalStorageUtils LocalStorageUtils { get; private set; }
        public IJSPwaUtils PwaUtils { get; private set; }
        public IJSTimeUtils TimeUtils { get; private set; }
        public IJSDocumentUtils DocumentUtils { get; private set; }
        public IJSCacheStorageUtils CacheStorageUtils { get; private set; }

        public JsInteropService(IJSRuntime jsr, ILogger<JsInteropService> logger)
        {
            LocalStorageUtils = new JSLocalStorageUtils(jsr, logger);
            PwaUtils = new JSPwaUtils(jsr, logger);
            TimeUtils = new JSTimeUtils(jsr, logger);
            DocumentUtils = new JSDocumentUtils(jsr, logger);
            CacheStorageUtils = new JSCacheStorageUtils(jsr, logger);
        }
    }
}
