using BlazorActiveXControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.ComContracts;

namespace BlazorApp.ComServer
{

    [ComVisible(true)]
    [Guid(ComGuids.ServerId)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IBlazorAppComServer: IBlazorAppServer
    {
    
    }

    [ComVisible(true)]
    [Guid(ComGuids.ServerClassId)
    , ClassInterface(ClassInterfaceType.None)]
    public class BlazorAppComServer: MainForm, IBlazorAppComServer
    {

      
        public BlazorAppComServer():base()
        {

        }

        [DispId(5)]
        public string HelloComMessage { get; set; } = "Hello COM!";

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
