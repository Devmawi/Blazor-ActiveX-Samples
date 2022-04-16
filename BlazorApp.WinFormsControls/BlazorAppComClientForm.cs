using BlazorApp.WinFormsControls.ActiveX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazorApp.WinFormsControls
{
    [ComVisible(true)]
    [Guid(ComGuids.BlazorActiveXControlClassId), ClassInterface(ClassInterfaceType.None)]
    public partial class BlazorAppComClientForm : Form, IBlazorActiveXControl
    {
        public IntPtr comServerWindowHandle { get; set; }
        public string Message { get; set; }

        public Type comServer;
        public object comServerInstance;

        public BlazorAppComClientForm()
        {
            InitializeComponent();
            try
            {
                InitializeWebView();
            }
            catch (Exception)
            {
                // Quick and dirty fix of some bugs that ouccurs at design time
            }
        }

        public void InitializeWebView()
        {
            //https://www.c-sharpcorner.com/article/calling-a-com-component-from-C-Sharp-late-binding/
            comServer = Type.GetTypeFromProgID("BlazorApp.ComServer.BlazorAppComServer");
            comServerInstance = Activator.CreateInstance(comServer);

            comServer.InvokeMember("Show", System.Reflection.BindingFlags.InvokeMethod, null, comServerInstance, Array.Empty<Object>());
            var handle = comServer.InvokeMember("WindowHandle", System.Reflection.BindingFlags.InvokeMethod, null, comServerInstance, new object[] { });

            comServerWindowHandle = new IntPtr((int)handle);
            WinHelper.SetWindowLong(comServerWindowHandle, WinHelper.GWL_STYLE, WinHelper.winStyle.WS_VISIBLE);
            var thisWindow = this.Handle;
            WinHelper.SetParent(comServerWindowHandle, thisWindow);

            comServer.InvokeMember("MaximizeWindowSize", System.Reflection.BindingFlags.InvokeMethod, null, comServerInstance, new object[] { });
            ResizeChildWindow();
        }

        private void ResizeChildWindow()
        {
            if (comServerInstance != null)
                comServer?.InvokeMember("MaximizeWindowSize", System.Reflection.BindingFlags.InvokeMethod, null, comServerInstance, new object[] { });
        }

        public void AddToPanel(Panel parentObject)
        {
            if (parentObject != null)
            {
                this.TopLevel = false;
                this.Parent = parentObject;
            }

            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Show();
            this.Visible = true;
        }

        //Some imported functions from user32.dll
        public static class WinHelper
        {
            //Sets a window to be a child window of another window
            [DllImport("user32.dll")]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport("user32.dll")]
            public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

            //Sets window attributes
            [DllImport("user32.dll")]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, winStyle dwNewLong);

            public static int GWL_STYLE = -16;

            [Flags]
            public enum winStyle : int
            {
                WS_VISIBLE = 0x10000000,
                WS_CHILD = 0x40000000, //child window
                WS_BORDER = 0x00800000, //window with border
                WS_DLGFRAME = 0x00400000, //window with double border but no title
                WS_CAPTION = WS_BORDER | WS_DLGFRAME //window with a title bar
            }
        }

        private void BlazorAppComClientForm_Resize(object sender, EventArgs e)
        {
            ResizeChildWindow();
        }

        [ComRegisterFunction]
        public void RegisterControl(Type type)
        {
            ComRegistration.RegisterControl(type);
        }

        [ComUnregisterFunction]
        public void UnregisterControl(Type type)
        {
            ComRegistration.UnregisterControl(type);
        }
    }
}
