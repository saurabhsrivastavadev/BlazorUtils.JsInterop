using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public interface IJsInteropStorageUtils
    {
        public Task<string> LocalStorageGetItem(string key);
        public Task<string> LocalStorageSetItem(string key, string value);
    }
}
