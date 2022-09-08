using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUtils.JsInterop
{
    public interface IJSDocumentUtils
    {
        /// <summary>
        /// Start listening for document visibility change.
        /// All callbacks added to DocumentVisibilityChangeCallback will be invoked on a 
        /// visibility change event.
        /// Document is deemed invisible when user switches focus to another application or tab.
        /// </summary>
        public Task EnableVisibilityChangeEvent();

        /// <summary>
        /// Stop listening for document visibility change.
        /// Callbacks added to DocumentVisibilityChangeCallback would no longer be invoked.
        /// </summary>
        public Task DisableVisibilityChangeEvent();

        /// <summary>
        /// Delegate for document visibility event callback.
        /// </summary>
        /// <param name="isVisible"></param>
        delegate void DocumentVisibilityChangeCallbackType(bool isVisible);

        /// <summary>
        /// Add callbacks here to receive document visibility change events.
        /// </summary>
        DocumentVisibilityChangeCallbackType DocumentVisibilityChangeCallback { get; set; }
    }
}
