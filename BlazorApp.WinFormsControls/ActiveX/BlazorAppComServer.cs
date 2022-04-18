using BlazorApp.ComContracts.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.WinFormsControls.ActiveX
{

    [ComVisible(false)]
    [ComImport]
    [Guid(ComContracts.ContractGuids.ServerId)]
    [CoClass(typeof(BlazorAppComServer))]
    internal interface IBlazorAppComServer: IBlazorAppServer
    {

    }

    [ComVisible(false)]
    [ComImport]
    [Guid(ComContracts.ContractGuids.ServerClassId)]
    public class BlazorAppComServer
    {

    }
}
