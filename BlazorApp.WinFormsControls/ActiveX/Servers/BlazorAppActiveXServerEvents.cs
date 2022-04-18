using BlazorApp.ComContracts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Servers
{
    [ComVisible(true)]
    [Guid(ContractGuids.ActiveXServerEventsId)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface BlazorAppActiveXServerEvents: BlazorAppServerEvents
    {
       // void MessageChanged(string message);
    }
}
