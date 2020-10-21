using Lunixo.ChromiumGtk.Core;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Handlers
{
    internal sealed class DisplayHandler : CefDisplayHandler
    {
        private readonly WebBrowser _core;

        public DisplayHandler(WebBrowser core)
        {
            _core = core;
        }

        protected override void  OnTitleChange(CefBrowser browser, string title)
        {
            _core.OnTitleChanged(title);
        }

        protected override void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
        {
            if (frame.IsMain)
            {
                _core.OnAddressChanged(url);
            }
        }

        protected override void OnStatusMessage(CefBrowser browser, string value)
        {
            _core.OnTargetUrlChanged(value);
        }
    }
}
