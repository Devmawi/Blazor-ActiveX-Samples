using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.ComContracts.Clients;

namespace BlazorApp.ComServer.TestConsole
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Late binding doesn't work if ComContracts is referenced and used for early binding
            /*
            var server = Type.GetTypeFromProgID("BlazorApp.ComServer.BlazorAppComServer");
            var serverInstance = Activator.CreateInstance(server);

            var members = server.GetMembers();
            var message = server.InvokeMember("HelloComMessage", System.Reflection.BindingFlags.InvokeMethod, null, serverInstance, Array.Empty<Object>());
            server.InvokeMember("HelloComMessage", System.Reflection.BindingFlags.SetProperty, null, serverInstance, new object[] { "Hello from good old .NET Farmework!" });
            message = server.InvokeMember("HelloComMessage", System.Reflection.BindingFlags.InvokeMethod, null, serverInstance, Array.Empty<Object>());
            */

            // Early binding
            var comServer = new BlazorAppServer();
            comServer.MessageChanged += ComServer_MessageChanged;
            var earlyBindMessage = comServer.Message;
            comServer.Message = "Hello from early binding!";
            earlyBindMessage = comServer.Message;
        }

        private static void ComServer_MessageChanged(string newMessage)
        {
            Console.WriteLine($"New message: {newMessage}.");
        }
    }
}
