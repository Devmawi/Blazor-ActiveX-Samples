using BlazorActiveXControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.ComContracts;
using BlazorApp.ComContracts.Servers;

namespace BlazorApp.ComServer
{

    [ComVisible(true)]
    [Guid(ContractGuids.ServerClassId)
    , ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(BlazorAppServerEvents))]
    public class BlazorAppComServer: MainForm, IBlazorAppServer, BlazorAppServerEvents_Event
    {   
        public BlazorAppComServer():base()
        {

        }
    }
}
