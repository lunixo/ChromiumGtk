using Lunixo.ChromiumGtk.Handlers;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Core
{
    internal sealed class CefApp : Xilium.CefGlue.CefApp
    {
        public CefRenderProcessHandler RenderProcessHandler { get; set; } = new RenderProcessHandler();
        public CefBrowserProcessHandler BrowserProcessHandler { get; set; }
        public CefResourceBundleHandler ResourceBundleHandler { get; set; }
        
        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return RenderProcessHandler;
        }

        protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        {
            return BrowserProcessHandler;
        }

        protected override CefResourceBundleHandler GetResourceBundleHandler()
        {
            return ResourceBundleHandler;
        }
    }
}