using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.WinFormsControls.ActiveX
{
    [ComVisible(true)]
    [Guid(ComGuids.BlazorActiveXControlId)]
    internal interface IBlazorActiveXControl
    {
        string Message { get; set; }
    }
}
