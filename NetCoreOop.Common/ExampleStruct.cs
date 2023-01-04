using System.Runtime.InteropServices;

namespace NetCoreOop.Common
{
    [Guid("62C246E2-B9C7-492C-B0F9-0B8D4D75A40E")]
    public struct ExampleStruct
    {
        public int LongField;
        [MarshalAs(UnmanagedType.BStr)]
        public string? StringField;
    }
}