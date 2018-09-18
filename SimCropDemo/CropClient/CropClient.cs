using System;
using System.Text;
using CropServer;

namespace CropClient
{
    public class CropClient: SimpleTCP.SimpleTcpClient
    {
        private readonly TimeSpan Timeout = TimeSpan.FromMilliseconds(500);

        public CropClient()
        {
            this.StringEncoder = Encoding.UTF8;
        }

        public void TestConnection()
        {
            var cmd = new CropServerCommand(ServerCommands.TestConnection);
            WriteLineAndGetReply(cmd.ToString(), Timeout);
        }

        public void SendGetFieldsCommand()
        {
            Write(ServerCommands.GetFields.ToString());
        }

        public void SendGetInfoAllFiends()
        {
            Write(ServerCommands.GetInfoAllFields.ToString());
        }

        public void SendGetInfoSingleFieldCommand(string fieldName)
        {
            Write(ServerCommands.TestConnection.ToString() + "," + fieldName);
        }

        public void SendPlantCommand(string fieldName)
        {
            Write(ServerCommands.Plant.ToString() + "," + fieldName);
        }

        public void SendHarvestCommand(string fieldName)
        {
            Write(ServerCommands.Plant.ToString() + "," + fieldName);
        }
        
    }
}
