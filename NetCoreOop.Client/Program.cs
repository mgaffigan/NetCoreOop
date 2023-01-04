using static Windows.Win32.PInvoke;
using Windows.Win32.System.Com;
using NetCoreOop.Common;

var CLSID_Server = Guid.Parse("3E24F9CD-55D4-4633-BE83-1CD90F632E54");
CoCreateInstance(CLSID_Server, null, CLSCTX.CLSCTX_LOCAL_SERVER, out IServer server)
    .ThrowOnFailure();

var result = server.ExampleCall(new[] {
    new ExampleStruct { StringField = "Example text" },
    new ExampleStruct { LongField = 53 } 
});

Console.WriteLine($"Call returned {result}");
