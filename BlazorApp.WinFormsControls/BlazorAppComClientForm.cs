using BlazorApp.ComContracts.Clients;
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
  
    public partial class BlazorAppComClientForm : Form
    {
        public IntPtr comServerWindowHandle { get; set; }
        public string Message { get; set; }
        private BlazorAppServer blazorAppComServer { get; set; }

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
            
            blazorAppComServer = new BlazorAppServer();
            comServerWindowHandle = blazorAppComServer.WindowHandle();

            /* Set blazor app as child window by a handle */
            WinHelper.SetWindowLong(comServerWindowHandle, WinHelper.GWL_STYLE, WinHelper.winStyle.WS_VISIBLE);
            var thisWindow = Handle;
            WinHelper.SetParent(comServerWindowHandle, thisWindow);

            ResizeChildWindow();
        }

        private void ResizeChildWindow()
        {
            if (blazorAppComServer != null)
                blazorAppComServer.MaximizeWindowSize();
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

       
    }
}
