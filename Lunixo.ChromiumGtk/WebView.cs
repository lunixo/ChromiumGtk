#nullable enable
using System;
using Gtk;
using Lunixo.ChromiumGtk.Core;
using Xilium.CefGlue;
using InteropLinux = Lunixo.ChromiumGtk.Interop.InteropLinux;

namespace Lunixo.ChromiumGtk
{
    public class WebView : Bin
    {
        private bool _initialized;
        private bool _created;
        private string? _startUrl;
        private readonly Bin _container;
        
        public WebView(CefBrowserSettings? browserSettings = null)
        {
            _container = new EventBox()
            {
                Halign = Align.Fill,
                Valign = Align.Fill
            };
            
            _container.Realized += OnRealized;
            
            Add(_container);
            
            Browser = new WebBrowser(browserSettings ?? CreateDefaultBrowserSettings());
            Browser.Created += BrowserOnCreated;
            SizeAllocated += OnSizeAllocated;
        }
        
        public WebBrowser Browser { get; }

        public static CefBrowserSettings CreateDefaultBrowserSettings()
        {
            return new CefBrowserSettings
            {
                DefaultEncoding = "UTF-8",
            };
        }

        private void BrowserOnCreated(object? sender, System.EventArgs e)
        {
            Browser.Created -= BrowserOnCreated;
            _created = true;

            if (_startUrl != null)
            {
                LoadUrl(_startUrl);
            }
        }

        private void OnSizeAllocated(object o, SizeAllocatedArgs args)
        {
            if (Handle != IntPtr.Zero && _initialized)
            {
                ResizeBrowser(args.Allocation.Width, args.Allocation.Height);
            }
        }

        protected virtual void ResizeBrowser(int width, int height)
        {
            if (!_created)
            {
                return;
            }
            
            var browserWindow = Browser.CefBrowser.GetHost().GetWindowHandle();
            var gdkDisplay = InteropLinux.gtk_widget_get_display(_container.Handle);
            var x11Display = InteropLinux.gdk_x11_display_get_xdisplay(gdkDisplay);
            InteropLinux.XMoveResizeWindow(x11Display, browserWindow, 0, 0, width, height);
        }

        private void OnRealized(object sender, System.EventArgs e)
        {
            CreateBrowser();
        }

        private void CreateBrowser()
        {
            var windowInfo = CefWindowInfo.Create();
            var windowHandle = InteropLinux.gtk_widget_get_window(_container.Handle);
            var xid = InteropLinux.gdk_x11_window_get_xid(windowHandle);

            windowInfo.SetAsChild(xid, new CefRectangle(0, 0, AllocatedWidth, AllocatedHeight));
            Browser.Create(windowInfo, _startUrl);
            _initialized = true;
            _startUrl = null;
        }

        public void LoadUrl(string url)
        {
            if (_created)
            {
                Browser.CefBrowser.StopLoad();
                Browser.CefBrowser.GetMainFrame().LoadUrl(url);
            }
            else
            {
                _startUrl = url;
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Browser.Dispose();
        }
    }
}