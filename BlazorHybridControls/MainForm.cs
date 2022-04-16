using BlazorActiveXControl;
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
        private AppState AppState { get; set; } = new AppState();
        public MainForm()
        {
            InitializeComponent();

            try
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddWindowsFormsBlazorWebView();
                AppState.Click += AppState_Click;
                serviceCollection.AddSingleton(AppState);

                var directory = Path.GetDirectoryName(GetType().Assembly.Location);
                var path = Path.Combine(directory, "wwwroot\\index.html");       

                // See also https://github.com/dotnet/maui/issues/3861               
                var rootDirectory = @"D:\ProgramData";
                var browserExeData = Path.Combine(rootDirectory, GetType().Assembly.GetName().Name ?? "BlazorActiveXControls", "WebView.exe");
                var userData = Path.Combine(rootDirectory, GetType().Assembly.GetName().Name ?? "BlazorActiveXControls", "WebView");

                Directory.CreateDirectory(browserExeData);
                Directory.CreateDirectory(userData);
                var creationProperties = new CoreWebView2CreationProperties()
                {
                    BrowserExecutableFolder = browserExeData,
                    UserDataFolder = userData
                };

                AppState.UserDataPath = userData;
                AppState.BrowserExecutionPath = browserExeData;
                AppState.IndexFile = path;

                // https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.winforms.webview2?view=webview2-dotnet-1.0.1185.39#ensurecorewebview2async
                // https://github.com/MicrosoftEdge/WebView2Feedback/issues/295
                // C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE.WebView2\EBWebView
                blazorWebView1.WebView.CreationProperties = creationProperties;
                blazorWebView1.WebView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
                blazorWebView1.HostPage = path;
                blazorWebView1.Services = serviceCollection.BuildServiceProvider();
                blazorWebView1.RootComponents.Add<App>("#app");


            }
            catch (Exception ex)
            {

                
            }
           
            
        }
        protected void AppState_Click(object sender, EventArgs e)
        {
            
           button1.Text = "Try Debugging, Counter:" +  Counter++;
        }

        private void WebView_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            
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
            var b = blazorWebView1.WebView.CoreWebView2;
        }
    }
}
