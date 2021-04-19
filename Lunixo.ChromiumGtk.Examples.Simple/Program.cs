using System;
using System.IO;
using Lunixo.ChromiumGtk.Core;
using Lunixo.ChromiumGtk.Interop;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Examples.Simple
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine();
            var runtime = new Runtime(CreateDefaultSettings(), new string[] { });
            Gtk.Application.Init();

            runtime.Initialize();

            using var window = new Gtk.Window("ChromiumGTK Demo")
            {
                WidthRequest = 1200,
                HeightRequest = 800
            };
            
            window.Destroyed += (sender, args) => runtime.QuitMessageLoop();
            InteropLinux.SetDefaultWindowVisual(window.Handle);

            using var webView = new WebView();
            webView.LoadUrl("https://dotnet.microsoft.com/");
            window.Add(webView);
            window.ShowAll();
            runtime.RunMessageLoop();
            runtime.Shutdown();
        }
        
        public static CefSettings CreateDefaultSettings() => new CefSettings()
        {
            MultiThreadedMessageLoop = false,
            // LogSeverity = CefLogSeverity.Verbose,
            // LogFile = string.Format("logs_{0:yyyyMMdd}.log", (object) DateTime.Now),
            // RemoteDebuggingPort = 20480,
            LocalesDirPath = Path.Combine(Environment.CurrentDirectory, "locales"),
            BrowserSubprocessPath = Path.Combine(Environment.CurrentDirectory, "cefsimple"),
            ResourcesDirPath = Path.Combine(Environment.CurrentDirectory),
            NoSandbox = true, 
            BackgroundColor = new CefColor((byte) 0, (byte) 0, (byte) 0, (byte) 0),
            WindowlessRenderingEnabled = false,
            ExternalMessagePump = false,
            Locale = "en-US"
        };
    }
}