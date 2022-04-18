﻿using System;
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
using BlazorApp.ComContracts;
using BlazorApp.ComContracts.Servers;

namespace BlazorApp.WinFormsControls
{
    [ComVisible(true)]
    [Guid(ContractGuids.ActiveXServerClassId), ClassInterface(ClassInterfaceType.None)]
    public partial class BlazorAppUserControl: UserControl, IBlazorAppActiveXServer
    {
        public BlazorAppComClientForm BlazorApp { get; set; }
        public BlazorAppUserControl()
        {
            InitializeComponent();    
        }
        public string Message { get => BlazorApp.Message; set => BlazorApp.Message = value; }

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
                BlazorApp = new BlazorAppComClientForm();
                BlazorApp.AddToPanel(mainPanel);
            }
            catch (Exception)
            {

            }
        }
    }
}
