using Lunixo.ChromiumGtk.Core;
using Lunixo.ChromiumGtk.Interop;

namespace Lunixo.ChromiumGtk.Examples.Simple
{
    class Program
    {
        static void Main()
        {
            using var runtime = new Runtime();
            runtime.Initialize();
            Gtk.Application.Init();
    
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
        }
    }
}