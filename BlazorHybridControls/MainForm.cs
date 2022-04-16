using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.WinForms;
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

namespace BlazorActiveXControls
{
    [ComVisible(true)]
    [Guid("b4e7f571-72eb-4e38-a351-d92d0e8a9f25")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ICounterUserControl
    {
        [DispId(1)]
        int Counter { get; set; }

        [DispId(2)]
        public void Show();

        [DispId(3)]
        public IntPtr WindowHandle();

        [DispId(4)]
        public void MaximizeWindowSize();

        [DispId(5)]
        public void ResizeWindow();
    }

    [ComVisible(true)]
    [Guid("c5c5c30c-97c0-4ed5-8bc8-1507d0a4bd48"), ClassInterface(ClassInterfaceType.None)]
    public partial class MainForm : Form, ICounterUserControl
    {
        public MainForm()
        {
            InitializeComponent();


            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWindowsFormsBlazorWebView();

            var directory = Path.GetDirectoryName(GetType().Assembly.Location);
            var path = Path.Combine(directory, "wwwroot\\index.html");
            button1.Text = path;
            blazorWebView1.HostPage = path;
            blazorWebView1.Services = serviceCollection.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
            
            // See also https://github.com/dotnet/maui/issues/3861
            var userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), GetType().Assembly.GetName().Name ?? "BlazorActiveXControls", "WebView");
            Directory.CreateDirectory(userData);
            var creationProperties = new CoreWebView2CreationProperties()
            {
                UserDataFolder = userData
            };
            blazorWebView1.WebView.CreationProperties = creationProperties;
        }

        public int Counter { get; set; }

        public IntPtr WindowHandle()
        {
            return this.Handle;
        }

        public void MaximizeWindowSize()
        {
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        public void ResizeWindow()
        {
           Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
