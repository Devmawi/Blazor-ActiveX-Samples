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
    public partial class MainForm : Form
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
            var browserExeData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), GetType().Assembly.GetName().Name ?? "BlazorActiveXControls", "WebView.exe");
            var userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), GetType().Assembly.GetName().Name ?? "BlazorActiveXControls", "WebView");
            Directory.CreateDirectory(browserExeData);
            Directory.CreateDirectory(userData);
            var creationProperties = new CoreWebView2CreationProperties()
            {
                BrowserExecutableFolder = browserExeData,
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
