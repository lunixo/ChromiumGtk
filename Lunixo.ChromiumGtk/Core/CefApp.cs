using Lunixo.ChromiumGtk.Handlers;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Core
{
    internal sealed class CefApp : Xilium.CefGlue.CefApp
    {
        private readonly CefRenderProcessHandler _renderProcessHandler = new RenderProcessHandler();
        
        public CefBrowserProcessHandler BrowserProcessHandler { get; set; }
        public CefResourceBundleHandler ResourceBundleHandler { get; set; }
        
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
        }
        
        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return _renderProcessHandler;
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