﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public interface IJSLocalStorageUtils
    {
        public Task<string> LocalStorageGetItem(string key);
        public Task LocalStorageSetItem(string key, string value);
        public Task LocalStorageDeleteItem(string key);
    }
}
