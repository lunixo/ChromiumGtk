namespace Lunixo.ChromiumGtk.EventArgs
{
    public sealed class StatusMessageEventArgs : System.EventArgs
    {
        public StatusMessageEventArgs(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}