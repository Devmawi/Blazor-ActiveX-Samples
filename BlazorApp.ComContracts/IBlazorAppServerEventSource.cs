using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts
{
    public interface IBlazorAppServerEventSource
    {
        [DispId(1)]
        void ControlClick(string message);
    }
}
