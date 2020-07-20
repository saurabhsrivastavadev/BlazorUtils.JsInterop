﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public interface IJsInteropPwaUtils
    {
        public Task<bool> ShowPwaInstallPrompt();
        public Task<bool> IsPwaInstalled();
    }
}
