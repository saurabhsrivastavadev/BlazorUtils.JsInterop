using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.JsInterop
{
    public interface IJsInteropService
    {
        public IJsInteropStorageUtils StorageUtils { get; }
        public IJsInteropPwaUtils PwaUtils { get;  }
        public IJsInteropTimeUtils TimeUtils { get;  }
    }
}
