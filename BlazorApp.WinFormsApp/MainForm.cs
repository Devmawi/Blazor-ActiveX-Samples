using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using BlazorApp.WinFormsControls;

namespace TestWindowsFormsApp
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            Text = "MainForm";
            this.blazorAppUserControl1.MessageChanged += BlazorAppUserControl1_MessageChanged;
        }

        private void BlazorAppUserControl1_MessageChanged(string newMessage)
        {
            MessageBox.Show($"Greetings from Blazor: {newMessage}");
        }
    }

    
}
