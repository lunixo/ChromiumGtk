using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Handlers
{
    internal sealed class BrowserProcessHandler : CefBrowserProcessHandler
    {
        protected override void OnBeforeChildProcessLaunch(CefCommandLine commandLine)
        {
        }
    }
}