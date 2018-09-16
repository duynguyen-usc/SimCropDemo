using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropServer
{
    public enum ServerCommands
    {
        None,
        TestConnection,
        GetFields,
        GetInfoSingleField,
        GetInfoAllFields,
        Plant,
        Harvest
    }

    public enum ServerResponses
    {
        TestConnectionSuccess,
        CommandSuccess,
        CommandSuccessCropPlanted,
        CommandSuccessCropHarvested,
        BadCommand
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

            Console.WriteLine("Starting Server on {0}:{1}", ipAddress, port);
            server.Start(ipAddress, port);
            if (server.IsStarted)
                Console.WriteLine("Server started.");
            else
                Console.WriteLine("Server start failed.");
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
                StringEncoder = Encoding.UTF8
            };
            server.DataReceived += ServerDataReceived;
        }

        private void ServerDataReceived(object sender, SimpleTCP.Message e)
        {
            string receivedCmd = "Received: " + e.MessageString;
            Console.WriteLine(receivedCmd);
            e.ReplyLine(receivedCmd);

            CommandHandler(e.MessageString.Trim());
        }

        private string CommandHandler(string command)
        {
            string cmdReply = "";
            Enum.TryParse(command, out ServerCommands serverCommand);
            switch (serverCommand)
            {
                case ServerCommands.TestConnection:
                    break;
                case ServerCommands.GetFields:
                    break;
                case ServerCommands.GetInfoSingleField:
                    break;
                case ServerCommands.GetInfoAllFields:
                    break;
                case ServerCommands.Harvest:
                    break;
                case ServerCommands.Plant:
                    break;
                default:
                    break;
            }

            return cmdReply;
        }
    }
}
