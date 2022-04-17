using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorActiveXControls
{
    public class AppState
    {
        public string UserDataPath { get; set; }
        public string BrowserExecutionPath { get; set; }
        public string IndexFile { get; set; }

        public delegate void ClickHandler (object sender, EventArgs e);

        public event ClickHandler Click;

        public void InvokeClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        public string Message { get; set; } = "Hello from Blazor";
    }
}
