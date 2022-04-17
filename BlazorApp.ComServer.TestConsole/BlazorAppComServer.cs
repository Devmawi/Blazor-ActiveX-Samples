using BlazorApp.ComContracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp.ComServer
{

    [ComVisible(false)]
    public delegate void IBlazorAppServerEventSource_ControlClickEventHandler(string message);

    [ComImport]
    [Guid(ComContracts.ComGuids.ServerId)]
    [CoClass(typeof(BlazorAppComServer))]
    internal interface IBlazorAppComServer : IBlazorAppServer, IBlazorAppServerEventSource_Event
    {
        
    }

    [ComImport]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IBlazorAppServerEventSource_Import))]
    [Guid(ComContracts.ComGuids.ServerClassId)]
    public class BlazorAppComServer : IBlazorAppServer

    {
        [DispId(5)] 
        public virtual extern string HelloComMessage { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

        public virtual extern event IBlazorAppServerEventSource_ControlClickEventHandler ControlClick;

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(6)]
        public virtual extern void InvokeControlClick(string message);

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(4)]
        public virtual extern void MaximizeWindowSize();

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DispId(3)]
        public virtual extern IntPtr WindowHandle();
    }

    /*
     Example: Assembly Interop.SHDocVw, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
     DWebBrowserEvents2_Event
     
     Example Code:
     var ie = new SHDocVw.InternetExplorer();
     ie.BeforeNavigate2 // Then navigate to interface definition
     */


    [ComEventInterface(typeof(IBlazorAppServerEventSource_Import), typeof(BlazorAppComServerEventSource_EventProvider))]
    //[ComVisible(false)]
    public interface IBlazorAppServerEventSource_Event
    {
        event IBlazorAppServerEventSource_ControlClickEventHandler ControlClick;
    }


    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid(ComGuids.ServerEventSourceId)]
    public interface IBlazorAppServerEventSource_Import : IBlazorAppServerEventSource
    {
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
        [DispId(1)]
        new void ControlClick(string message);
    }

    [TypeLibType(TypeLibTypeFlags.FHidden)]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class BlazorAppComServerEventSource_SinkHelper : IBlazorAppServerEventSource_Import
    {
        public int m_dwCookie=0;
        public IBlazorAppServerEventSource_ControlClickEventHandler m_ControlClickDelegate;
        public void ControlClick(string message)
        {
            if (m_ControlClickDelegate != null)
            {
                m_ControlClickDelegate(message);
            }
        }
    }

    internal sealed class BlazorAppComServerEventSource_EventProvider : IBlazorAppServerEventSource_Event, IDisposable
    {
        private IConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private IConnectionPoint m_ConnectionPoint;
        private bool disposedValue;

        private void Init()
        {
            IConnectionPoint ppCP = null;
            Guid riid = Guid.Parse(ComGuids.ServerEventSourceId);
            m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            m_ConnectionPoint = ppCP;
            m_aEventSinkHelpers = new ArrayList();
        }
        public BlazorAppComServerEventSource_EventProvider(object P_0)
        {
            //Error decoding local variables: Signature type sequence must have at least one element.
            m_ConnectionPointContainer = (IConnectionPointContainer)P_0;
        }

        private event IBlazorAppServerEventSource_ControlClickEventHandler _controlClick;
        public event IBlazorAppServerEventSource_ControlClickEventHandler ControlClick { add {

                bool lockTaken = default(bool);
                try
                {
                    Monitor.Enter(this, ref lockTaken);
                    if (m_ConnectionPoint == null)
                    {
                        Init();
                    }

                    BlazorAppComServerEventSource_SinkHelper blazorAppComServerEventSource_SinkHelper = new BlazorAppComServerEventSource_SinkHelper();
                    int pdwCookie = 0;
                    m_ConnectionPoint.Advise(blazorAppComServerEventSource_SinkHelper, out pdwCookie);
                    blazorAppComServerEventSource_SinkHelper.m_dwCookie = pdwCookie;
                    blazorAppComServerEventSource_SinkHelper.m_ControlClickDelegate = value;
                    m_aEventSinkHelpers.Add(blazorAppComServerEventSource_SinkHelper);
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(this);
                    }
                }
            } remove {
                bool lockTaken = default(bool);
                try
                {
                    _controlClick -= value;
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(this);
                    }
                }
            } 
        }

        private void BlazorAppComServerEventSource_EventProvider__controlClick(string message)
        {
            Console.WriteLine(message);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BlazorAppComServerEventSource_EventProvider()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
