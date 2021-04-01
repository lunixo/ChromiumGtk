using System;
using System.IO;
using Xilium.CefGlue;
using DateTime = System.DateTime;

namespace Lunixo.ChromiumGtk.Core
{
    public class Runtime
    {
        private static bool _initialized;
        
        private readonly CefSettings _cefSettings;
        private readonly string[] _commandLineArgs;

        public Runtime(CefSettings cefSettings = null, string[] commandLineArgs = null)
        {
            _cefSettings = cefSettings ?? CreateDefaultSettings();
            _commandLineArgs = commandLineArgs ?? Environment.GetCommandLineArgs();
        }
        
        public void Initialize(Xilium.CefGlue.CefApp customApp = null)
        {
            if (_initialized)
            {
                throw new Exception("Only one runtime can be initialized.");
            }
            
            _initialized = true;
            
            CefRuntime.Load();
            var mainArgs = new CefMainArgs(_commandLineArgs);
            CefRuntime.Initialize(mainArgs, _cefSettings, customApp ?? new CefApp(), IntPtr.Zero);
        }

        public void RunMessageLoop()
        {
            CefRuntime.RunMessageLoop();
        }

        public void QuitMessageLoop()
        {
            CefRuntime.QuitMessageLoop();
        }

        public static CefSettings CreateDefaultSettings()
        {
            return new CefSettings
            {
                MultiThreadedMessageLoop = false,
                LogSeverity = CefLogSeverity.Verbose,
                LogFile = $"logs_{DateTime.Now:yyyyMMdd}.log",
                RemoteDebuggingPort = 20480,
                LocalesDirPath = Path.Combine(Environment.CurrentDirectory, "locales"),
                BrowserSubprocessPath = Path.Combine(Environment.CurrentDirectory, "cefsimple"),
                ResourcesDirPath = Path.Combine(Environment.CurrentDirectory),
                NoSandbox = true,
                BackgroundColor = new CefColor(0,0, 0,0),
                WindowlessRenderingEnabled = false,
                ExternalMessagePump = false,
                Locale = "en-US"
            };
        }

        public void Shutdown()
        {
            CefRuntime.Shutdown();
        }
    }
}