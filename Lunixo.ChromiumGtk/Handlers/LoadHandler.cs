using Lunixo.ChromiumGtk.Core;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Handlers
{
    internal sealed class LoadHandler : CefLoadHandler
    {
        private readonly WebBrowser _core;

        public LoadHandler(WebBrowser core)
        {
            _core = core;
        }

        protected override void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack, bool canGoForward)
        {
            _core.OnLoadingStateChanged(isLoading, canGoBack, canGoForward);
        }
    }
}
