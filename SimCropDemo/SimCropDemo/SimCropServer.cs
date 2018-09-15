using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropDemo
{
    public class SimCropServer
    {
        private SimpleTCP.SimpleTcpServer server;

        public SimCropServer()
        {
            SetupServer();
        }

        public void Start()
        {
            int port = 8910;
            System.Net.IPAddress ipAddress = new System.Net.IPAddress(long.Parse("127.0.0.1"));

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
                server.Stop();
        }

        public bool IsStarted()
        {
            return server.IsStarted;
        }

        private void SetupServer()
        {
            server = new SimpleTCP.SimpleTcpServer();
            server.StringEncoder = Encoding.UTF8;
            server.Delimiter = 0x13; // enter
            server.DataReceived += ServerDataReceived;
        }

        private void ServerDataReceived(object sender, SimpleTCP.Message message)
        {
            Console.WriteLine(message.MessageString);
        }
    }
}
