namespace GenericCodes.Core
{
    public interface IDisposable : System.IDisposable
    {
        bool IsDisposed { get; }
    }
}
