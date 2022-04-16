using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.ComServer.TestConsole
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Console.ReadKey();
            // Late binding
            var server = Type.GetTypeFromProgID("BlazorApp.ComServer.BlazorAppComServer");
            var serverInstance = Activator.CreateInstance(server);
        }
    }
}
