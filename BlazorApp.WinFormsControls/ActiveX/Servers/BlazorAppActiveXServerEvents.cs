using BlazorApp.ComContracts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Servers
{
    [ComVisible(true)]
    [Guid(ContractGuids.ActiveXServerEventsId)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)] // Dual interface doesn't work in VBA
    public interface BlazorAppActiveXServerEvents
    {
       void MessageChanged(string message);
    }
}
