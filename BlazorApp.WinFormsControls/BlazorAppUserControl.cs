using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BlazorApp.WinFormsControls.ActiveX;

namespace BlazorApp.WinFormsControls
{
    [ComVisible(true)]
    [Guid(ComGuids.BlazorActiveXControlClassId), ClassInterface(ClassInterfaceType.None)]
    public partial class BlazorAppUserControl: UserControl, IBlazorActiveXControl
    {
        public BlazorAppUserControl()
        {
            InitializeComponent();
            
         
        }

        public string Message { get; set; } = String.Empty;

        [ComRegisterFunction]
        public static void RegisterControl(Type type)
        {
            ComRegistration.RegisterControl(type);
        }

        [ComUnregisterFunction]
        public static void UnregisterControl(Type type)
        {
            ComRegistration.UnregisterControl(type);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var f = new BlazorAppComClientForm();
                f.AddToPanel(mainPanel);
            }
            catch (Exception)
            {

            }
        }
    }
}
