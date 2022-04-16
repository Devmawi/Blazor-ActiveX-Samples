using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.ComServer
{

    //[ComVisible(true)]
    //[Guid("6030a647-3e6b-4eaf-af9b-a14550afee12")]
    //[InterfaceType(ComInterfaceType.InterfaceIsDual)]

    [ComImport]
    [Guid("6030a647-3e6b-4eaf-af9b-a14550afee12")]
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
    }

    [ComImport]
    [Guid("9243b788-413a-413a-8b8c-dfb5db79a2a5")]
    public class BlazorAppComServer
    {

    }
}
