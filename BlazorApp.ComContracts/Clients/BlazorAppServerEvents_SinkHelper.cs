using BlazorApp.ComContracts.Servers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BlazorApp.ComContracts.Clients
{
    [ClassInterface(ClassInterfaceType.None)]
    public class BlazorAppServerEvents_SinkHelper : BlazorAppServerEvents // Interface implementation is necessary for  m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
    {
        public BlazorAppServerEvents_MessageChangedEventHandler m_MessageChangedDelegate;
        public int m_dwCookie;

        public void MessageChanged(string message)
        {
            if (m_MessageChangedDelegate != null)
            {
                m_MessageChangedDelegate(message);
            };
        }
    }
}
