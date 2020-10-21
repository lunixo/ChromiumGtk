namespace Lunixo.ChromiumGtk.EventArgs
{
    public sealed class AddressChangedEventArgs : System.EventArgs
    {
        public AddressChangedEventArgs(string address)
        {
            Address = address;
        }

        public string Address { get; }
    }
}
