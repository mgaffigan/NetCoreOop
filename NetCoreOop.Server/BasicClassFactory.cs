using static Windows.Win32.PInvoke;
using System.Runtime.InteropServices;

internal class BasicClassFactory<T> : IClassFactory
{
    private readonly Func<T> Ctor;

    public BasicClassFactory(Func<T> ctor)
    {
        if (!typeof(T).IsInterface || typeof(T).GUID == default)
        {
            throw new ArgumentException($"Type {typeof(T)} is not an interface or has no guid assigned");
        }

        this.Ctor = ctor;
    }

    public IntPtr CreateInstance(IntPtr pUnkOuter, Guid riid)
    {
        if (pUnkOuter != IntPtr.Zero) throw Marshal.GetExceptionForHR(CLASS_E_NOAGGREGATION)!;
        if (!(riid == IID_IUnknown || riid == typeof(T).GUID)) throw Marshal.GetExceptionForHR(E_NOINTERFACE)!;

        return Marshal.GetComInterfaceForObject(Ctor()!, typeof(T));
    }
    private static readonly Guid IID_IUnknown = Guid.Parse("00000000-0000-0000-C000-000000000046");

    public void LockServer(bool fLock) { }
}

[ComImport, Guid("00000001-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IClassFactory
{
    IntPtr CreateInstance(IntPtr pUnkOuter, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);
    void LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
}