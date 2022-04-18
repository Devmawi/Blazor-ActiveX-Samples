using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Servers
{
    [ComVisible(true)]
    [Guid(ContractGuids.ActiveXServerId)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBlazorAppActiveXServer
    {
        string Message { get; set; }
    }
}
