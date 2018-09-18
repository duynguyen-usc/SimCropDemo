using System;
using System.Text;
using CropServer;

namespace CropClient
{
    public class CropClient: SimpleTCP.SimpleTcpClient
    {
        public CropClient()
        {
            this.StringEncoder = Encoding.UTF8;
        }

        public void TestConnection()
        {
            Send(new CropServerCommand(ServerCommands.TestConnection));
        }

        public void SendGetFieldsCommand()
        {
            var cmd = new CropServerCommand(ServerCommands.GetInfoAllFields);

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

        private void Send(CropServerCommand cmd)
        {
            WriteLineAndGetReply(cmd.ToString(), TimeSpan.FromMilliseconds(500));
        }
        
    }
}
