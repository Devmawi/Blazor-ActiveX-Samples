using BlazorApp.ComContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.WinFormsControls.ActiveX
{

    [ComImport]
    [Guid(ComContracts.ComGuids.ServerId)]
    [CoClass(typeof(BlazorAppComServer))]
    internal interface IBlazorAppComServer: IBlazorAppServer
    {

    }

    [ComImport]
    [Guid(ComContracts.ComGuids.ServerClassId)]
    public class BlazorAppComServer
    {

    }
}
