using System;
using Lunixo.ChromiumGtk.EventArgs;
using Xilium.CefGlue;

namespace Lunixo.ChromiumGtk.Core
{
    public sealed class WebBrowser : IDisposable
    {
        private readonly CefBrowserSettings _settings;

        public WebBrowser(CefBrowserSettings settings)
        {
            _settings = settings;
            Client = new WebClient(this);
        }
        
        public CefBrowser CefBrowser { get; private set; }
        public WebClient Client { get; }

        public void Create(CefWindowInfo windowInfo, string startUrl)
        {
            CefBrowserHost.CreateBrowser(windowInfo, Client, _settings, startUrl);
        }

        public event EventHandler Created;

        internal void OnCreated(CefBrowser browser)
        {
            CefBrowser = browser;
            var handler = Created;
            handler?.Invoke(this, new System.EventArgs());
        }
        
        public event EventHandler<TitleChangedEventArgs> TitleChanged;

        internal void OnTitleChanged(string title)
        {
            var handler = TitleChanged;
            handler?.Invoke(this, new TitleChangedEventArgs(title));
        }

        public event EventHandler<AddressChangedEventArgs> AddressChanged;

        internal void OnAddressChanged(string address)
        {
            var handler = AddressChanged;
            handler?.Invoke(this, new AddressChangedEventArgs(address));
        }

        public event EventHandler<TargetUrlChangedEventArgs> TargetUrlChanged;

        internal void OnTargetUrlChanged(string targetUrl)
        {
            var handler = TargetUrlChanged;
            handler?.Invoke(this, new TargetUrlChangedEventArgs(targetUrl));
        }

        public event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;

        internal void OnLoadingStateChanged(bool isLoading, bool canGoBack, bool canGoForward)
        {
            var handler = LoadingStateChanged;
            handler?.Invoke(this, new LoadingStateChangedEventArgs(isLoading, canGoBack, canGoForward));
        }

        public void Dispose()
        {
            if (CefBrowser != null)
            {
                var host = CefBrowser.GetHost();
                host.CloseBrowser(true);
                host.Dispose();
                CefBrowser.Dispose();
                CefBrowser = null;
            }
        }
    }
}
