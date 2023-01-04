using static Windows.Win32.PInvoke;
using Windows.Win32.System.Com;
using NetCoreOop.Common;

var CLSID_Server = Guid.Parse("3E24F9CD-55D4-4633-BE83-1CD90F632E54");
CoRegisterClassObject(CLSID_Server, new BasicClassFactory<IServer>(() => new Server()),
    CLSCTX.CLSCTX_LOCAL_SERVER, (uint)REGCLS.REGCLS_SINGLEUSE, out var cookie)
    .ThrowOnFailure();
try
{
    Console.WriteLine("Server registered to ROT.  Press enter to end");
    Console.ReadLine();
}
finally
{
    CoRevokeClassObject(cookie).ThrowOnFailure();
}

class Server : IServer
{
    public int ExampleCall(ExampleStruct[] data)
    {
        Console.WriteLine($"Call with {data.Length} records");
        foreach (var d in data)
        {
            Console.WriteLine($"   {d.LongField} {d.StringField}");
        }
        return data.Length;
    }
}