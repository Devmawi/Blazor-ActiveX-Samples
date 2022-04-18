using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Servers
{
    [ComVisible(true)]
    [Guid(ContractGuids.ServerId)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBlazorAppServer
    {
        IntPtr WindowHandle();
        void MaximizeWindowSize();
        string Message { get; set; }
    }
}
