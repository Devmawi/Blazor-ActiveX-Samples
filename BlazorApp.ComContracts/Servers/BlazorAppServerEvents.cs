﻿using BlazorApp.ComContracts;
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
        void MessageChanged(string message);
    }
}