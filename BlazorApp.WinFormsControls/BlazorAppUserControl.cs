using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlazorApp.WinFormsControls
{
    public partial class BlazorAppUserControl: UserControl
    {
        public BlazorAppUserControl()
        {
            InitializeComponent();
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
