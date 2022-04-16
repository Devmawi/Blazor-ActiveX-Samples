using BlazorActiveXControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.ComServer
{

    [ComVisible(true)]
    [Guid("6030a647-3e6b-4eaf-af9b-a14550afee12")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBlazorAppComServer
    {
        [DispId(1)]
        public void Start();
        [DispId(2)]
        public void Show();

        [DispId(3)]
        public IntPtr WindowHandle();

        [DispId(4)]
        public void MaximizeWindowSize();
    }

    [ComVisible(true)]
    [Guid("9243b788-413a-413a-8b8c-dfb5db79a2a5")
    , ClassInterface(ClassInterfaceType.None)]
    public class BlazorAppComServer: MainForm, IBlazorAppComServer
    {

      
        public BlazorAppComServer():base()
        {

        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
