namespace Lunixo.ChromiumGtk.EventArgs
{
    public sealed class LoadingStateChangedEventArgs : System.EventArgs
    {
        public LoadingStateChangedEventArgs(bool isLoading, bool canGoBack, bool canGoForward)
        {
            Loading = isLoading;
            CanGoBack = canGoBack;
            CanGoForward = canGoForward;
        }

        public bool Loading { get; }

        public bool CanGoBack { get; }

        public bool CanGoForward { get; }
    }
}
