using Lunixo.ChromiumGtk.Handlers;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Core
{
    internal sealed class CefApp : Xilium.CefGlue.CefApp
    {
        private readonly CefBrowserProcessHandler _browserProcessHandler = new BrowserProcessHandler();
        private readonly CefRenderProcessHandler _renderProcessHandler = new RenderProcessHandler();

        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
        }

        protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        {
            return _browserProcessHandler;
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return _renderProcessHandler;
        }
    }
}