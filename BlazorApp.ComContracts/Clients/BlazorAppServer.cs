using BlazorApp.ComContracts.Servers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Clients
{
    [ComImport]
    [Guid(ContractGuids.ServerId)]
    [CoClass(typeof(BlazorAppClass))]
    public interface BlazorAppServer : IBlazorAppServer, BlazorAppServerEvents_Event
    {

    }

    [ComImport]
    [Guid(ContractGuids.ServerClassId)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(BlazorAppServerEvents))]
    public class BlazorAppClass
    {
    }
}
