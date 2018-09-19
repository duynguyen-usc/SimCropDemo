using System;
using System.Text;
using System.Collections.Generic;

namespace CropServer
{
    public class CropServer
    {
        public List<Field> Fields;
        private SimpleTCP.SimpleTcpServer server;

        public CropServer()
        {
            SetupServer();
            CreateFields();
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

        private void CreateFields()
        {
            Fields = new List<Field>();
            const int numFields = 50;
            for(int i = 1; i <= numFields; i++ )
            {
                Fields.Add(new Field("field" + i.ToString()));
            }
        }

        private void SetupServer()
        {
            server = new SimpleTCP.SimpleTcpServer
            {
                StringEncoder = Encoding.UTF8
            };
            server.DataReceived += ServerDataReceived;
        }

        private string ConvertToJson(CropServerMessage cropServerMessage)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(cropServerMessage);
        }

        private CropServerCommand JsonToCommand(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CropServerCommand>(json);
        }

        private void ServerDataReceived(object sender, SimpleTCP.Message e)
        {
            var cmd = JsonToCommand(e.MessageString.TrimEnd('\u0013'));
            var responsMsg = CommandHandler(cmd);
            e.Reply(ConvertToJson(responsMsg));
        }

        private CropServerMessage CommandHandler(CropServerCommand cropServerCommand)
        {   
            switch (cropServerCommand.Command)
            {
                case ServerCommands.TestConnection:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.TestConnectionSuccess
                    };

                case ServerCommands.GetFields:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.CommandSuccess,
                        Fields = Fields
                    };

                case ServerCommands.GetInfoSingleField:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.CommandSuccess,
                        FieldInfo = Fields.Find(x => x.Name == cropServerCommand.Field.Name);
                    };

                case ServerCommands.GetInfoAllFields:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.CommandSuccess
                    };

                case ServerCommands.Harvest:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.CommandSuccess
                    };

                case ServerCommands.Plant:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.CommandSuccess
                    };

                default:
                    return new CropServerMessage
                    {
                        Response = ServerResponses.BadCommand
                    };
            }

        }
    }
}
