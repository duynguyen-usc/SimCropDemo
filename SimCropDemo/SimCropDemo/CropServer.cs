using System;
using System.Text;

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
        CommandFailed,
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
            Console.WriteLine("Received: " + e.MessageString);
            var result = CommandHandler(e.MessageString.Trim());
            e.Reply(result.ToString());
        }

        private ServerResponses CommandHandler(string command)
        {
            Enum.TryParse(command.TrimEnd('\u0013'), out ServerCommands serverCommand);
            switch (serverCommand)
            {
                case ServerCommands.TestConnection:
                    return ServerResponses.TestConnectionSuccess;

                case ServerCommands.GetFields:
                    return ServerResponses.CommandSuccess;

                case ServerCommands.GetInfoSingleField:
                    return ServerResponses.CommandSuccess;

                case ServerCommands.GetInfoAllFields:
                    return ServerResponses.CommandSuccess;

                case ServerCommands.Harvest:
                    return ServerResponses.CommandSuccess;

                case ServerCommands.Plant:
                    return ServerResponses.CommandSuccess;

                default:
                    return ServerResponses.BadCommand;
            }

        }
    }
}
