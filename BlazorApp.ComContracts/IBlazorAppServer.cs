using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts
{
    public interface IBlazorAppServer
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
}
