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
    internal interface IBlazorAppComServer
    {
        [DispId(1)]
        void Start();
        [DispId(2)]
        void Show();

        [DispId(3)]
        IntPtr WindowHandle();

        [DispId(4)]
        void MaximizeWindowSize();

        [DispId(5)]
        string HelloComMessage { get; set; }
    }

    [ComImport]
    [Guid(ComContracts.ComGuids.ServerClassId)]
    public class BlazorAppComServer
    {

    }
}
