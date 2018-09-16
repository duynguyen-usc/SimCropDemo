using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropServer
{
    public enum ServerCommands
    {
        TestConnection,
        Plant,
        Harvest
    }

    public class CropServer
    {
        private SimpleTCP.SimpleTcpServer server;

        public CropServer()
        {
            SetupServer();
        }

        public void Start()
        {
            System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            int port = 8910;

            Console.WriteLine("ipAddress: {0}", ipAddress);
            Console.WriteLine("port: {0}", port);
            Console.WriteLine("Starting Server...");

            server.Start(ipAddress, port);
            if (server.IsStarted)
                Console.WriteLine("Server started.");
            else
                Console.WriteLine("Server start failed");
        }

        public void Stop()
        {
            if (server.IsStarted)
            {
                Console.WriteLine("Stopping server");
                server.Stop();
                Console.WriteLine("Server stopped.");
            }
                
        }

        public bool IsStarted()
        {
            return server.IsStarted;
        }

        private void SetupServer()
        {
            server = new SimpleTCP.SimpleTcpServer
            {
                StringEncoder = Encoding.UTF8,
                Delimiter = 0x3b // semi-colon
            };
            server.DataReceived += ServerDataReceived;
        }

        private void ServerDataReceived(object sender, SimpleTCP.Message e)
        {
            Console.WriteLine(e.MessageString);
            e.ReplyLine("Received: " + e.MessageString);
        }
    }
}
