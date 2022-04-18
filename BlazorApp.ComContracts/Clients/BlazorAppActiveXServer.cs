using BlazorApp.ComContracts.Servers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Clients
{
    [ComImport]
    [Guid(ContractGuids.ActiveXServerId)]
    [CoClass(typeof(BlazorAppClass))]
    public interface BlazorAppActiveXServer : IBlazorAppActiveXServer, BlazorAppServerEvents_Event
    {

    }

    [ComImport]
    [Guid(ContractGuids.ActiveXServerClassId)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(BlazorAppServerEvents))]
    public class BlazorAppActiveXServerClass
    {
    }
}
