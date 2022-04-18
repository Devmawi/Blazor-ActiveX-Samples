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
using BlazorApp.ComContracts.Servers;

namespace BlazorActiveXControls
{
    public partial class MainForm : Form
    {
        public string UserDataPath { get; set; }
        public string BrowserExecutionPath { get; set; }
        public string IndexFile { get; set; }

        private string _message = "Blazor and WinForms greet you from .NET 6.0";
        public string Message
        {
            get { return _message; }
            set { _message = value; MessageChanged?.Invoke(_message); }
        }

        public event BlazorAppServerEvents_MessageChangedEventHandler MessageChanged;

        public MainForm()
        {
            InitializeComponent();

            try
            {
                MessageChanged += MainForm_MessasgeChanged;
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddWindowsFormsBlazorWebView();
                serviceCollection.AddSingleton(this);

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

                UserDataPath = userData;
                BrowserExecutionPath = browserExeData;
                IndexFile = path;

                // https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.winforms.webview2?view=webview2-dotnet-1.0.1185.39#ensurecorewebview2async
                // https://github.com/MicrosoftEdge/WebView2Feedback/issues/295
                // C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE.WebView2\EBWebView
                blazorWebView1.WebView.CreationProperties = creationProperties;             
                blazorWebView1.HostPage = path;
                blazorWebView1.Services = serviceCollection.BuildServiceProvider();
                blazorWebView1.RootComponents.Add<App>("#app");
            }
            catch (Exception ex)
            {                
            }          
        }

        private void MainForm_MessasgeChanged(string newMessage)
        {
            button1.Text = newMessage;
        }

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
            // var b = blazorWebView1.WebView.CoreWebView2;
            Message = "Button clicked in Forms!";
        }
    }
}
