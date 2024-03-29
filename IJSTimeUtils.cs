﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public interface IJSTimeUtils
    {
        public Task<int> GetLocalTimezoneOffset();
        public Task<string> GetLocalTimezoneName();
    }
}
