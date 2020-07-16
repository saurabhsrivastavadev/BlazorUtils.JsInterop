using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorUtils.JsInterop
{
    public static class JsInterop
    {
        private static IJSRuntime _jsr;
        public static IJSRuntime JSR {
            get
            {
                return _jsr;
            }
            set
            {
                _jsr = value;
                if (value == null)
                {
                    JsInteropTimeUtils.Instance = null;
                }
                else
                {
                    if (JsInteropTimeUtils.Instance == null)
                    {
                        JsInteropTimeUtils.Instance = new JsInteropTimeUtils();
                    }
                    if (JsInteropPwaUtils.Instance == null)
                    {
                        JsInteropPwaUtils.Instance = new JsInteropPwaUtils();
                    }
                    if (JsInteropStorageUtils.Instance == null)
                    {
                        JsInteropStorageUtils.Instance = new JsInteropStorageUtils();
                    }
                }
            }
        }
    }
}
