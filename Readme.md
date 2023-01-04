# Example .net core COM OOP server and client

Builds upon [Out-of-process COM Server Demo](https://learn.microsoft.com/en-us/samples/dotnet/samples/out-of-process-com-server/) 
but avoids risks of manually maintaining IDL files.

## Key steps

1. Contract library (NetCoreOop.Common in this sample) has `AssemblyInfo.cs` with `GuidAttribute` to specify tlb id.  ([Doesn't appear](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#generateassemblyinfo) to be able to be specified in `csproj`)
2. Interfaces and structs in contract library are marked `ComVisible(true)` and have a `Guid` assigned to them
3. `dscom` is added to the contract library csproj to export a tlb
4. Add references to contract library as neccesary for managed callers.  Add imports to the exported tlb for unmanaged callers.
5. Create a server, class factory, and registration
6. Create a client, call to `CoCreateInstance`

## Run

1. Register the tlb with `dscom` or some other means (a setup project)<br/>`PS NetCoreOop.Common\bin\Debug\net7.0-windows> dscom tlbregister (dir .\NetCoreOop.Common.tlb).FullName` in an administrator terminal<br/>**Note:** You must provide `dscom` the full path the TLB
2. Optional: register the Server CLSID to allow COM to start the server if it is not already running
3. Run the server
4. Run the client
