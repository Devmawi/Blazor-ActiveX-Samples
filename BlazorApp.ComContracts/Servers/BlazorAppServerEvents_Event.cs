using BlazorApp.ComContracts.Clients;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Servers
{

    [ComEventInterface(typeof(BlazorAppServerEvents), typeof(BlazorAppServerEvents_EventProvider))]
    [ComVisible(false)]
    public interface BlazorAppServerEvents_Event
    {
        event BlazorAppServerEvents_MessageChangedEventHandler MessageChanged;
    }
}
