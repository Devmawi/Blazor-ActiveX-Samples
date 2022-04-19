using BlazorApp.ComContracts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Servers
{
    [ComVisible(true)]
    [Guid(ContractGuids.ServerEventsId)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface BlazorAppServerEvents
    {
        [DispId(1)] // Display Id is critical if you embed it in VBA, because VBA uses late Binding: https://docs.microsoft.com/de-de/dotnet/standard/native-interop/com-callable-wrapper#avoid-caching-dispatch-identifiers-dispids
        void MessageChanged(string message);
    }
}
