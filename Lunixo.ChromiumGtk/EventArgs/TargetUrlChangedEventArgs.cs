namespace Lunixo.ChromiumGtk.EventArgs
{
    public sealed class TargetUrlChangedEventArgs : System.EventArgs
    {
        public TargetUrlChangedEventArgs(string targetUrl)
        {
            TargetUrl = targetUrl;
        }

        public string TargetUrl { get; }
    }
}
