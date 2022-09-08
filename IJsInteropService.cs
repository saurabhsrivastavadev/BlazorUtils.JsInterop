using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.JsInterop
{
    public interface IJsInteropService
    {
        public IJSLocalStorageUtils LocalStorageUtils { get; }
        public IJSPwaUtils PwaUtils { get;  }
        public IJSTimeUtils TimeUtils { get;  }
        public IJSDocumentUtils DocumentUtils { get; }
        public IJSCacheStorageUtils CacheStorageUtils { get; }
    }
}
