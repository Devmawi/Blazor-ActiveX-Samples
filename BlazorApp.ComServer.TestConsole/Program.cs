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
            // Late binding
            var server = Type.GetTypeFromCLSID(Guid.Parse(ComContracts.ComGuids.ServerClassId));
            var serverInstance = Activator.CreateInstance(server);

            var message = server.InvokeMember("HelloComMessage", System.Reflection.BindingFlags.InvokeMethod, null, serverInstance, Array.Empty<Object>());
            server.InvokeMember("HelloComMessage", System.Reflection.BindingFlags.SetProperty, null, serverInstance, new object[] { "Hello from good old .NET Farmework!" });
            message = server.InvokeMember("HelloComMessage", System.Reflection.BindingFlags.InvokeMethod, null, serverInstance, Array.Empty<Object>());

            // Early binding
            var comServer = new IBlazorAppComServer();
            message = comServer.HelloComMessage;
            comServer.HelloComMessage = "Hello from early binding!";
            message = comServer.HelloComMessage;
        }
    }
}
