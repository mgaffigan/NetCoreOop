using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreOop.Common
{
    [ComVisible(true), Guid("33B3E8C2-6DF0-465E-80BA-2486AEFC60AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServer
    {
        int ExampleCall(ExampleStruct[] data);
    }
}
