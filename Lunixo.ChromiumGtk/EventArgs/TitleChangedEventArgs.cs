namespace Lunixo.ChromiumGtk.EventArgs
{
    public sealed class TitleChangedEventArgs : System.EventArgs
    {
        private readonly string _title;

        public TitleChangedEventArgs(string title)
        {
            _title = title;
        }

        public string Title => _title;
    }
}
