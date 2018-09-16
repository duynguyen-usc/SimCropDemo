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
            Write(ServerCommands.TestConnection.ToString());
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

        public void SendHarvestcommand(string fieldName)
        {
            Write(ServerCommands.Plant.ToString() + "," + fieldName);
        }
    }
}
