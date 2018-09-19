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
            Send(new CropServerCommand(ServerCommands.GetFields));
        }

        public void SendGetInfoAllFiends()
        {
            Send(new CropServerCommand(ServerCommands.GetInfoAllFields));
        }

        public void SendGetInfoSingleFieldCommand(string fieldName)
        {
            var cmd = new CropServerCommand(ServerCommands.GetInfoSingleField);
            cmd.Field.Name = fieldName;
            Send(cmd);
        }

        public void SendPlantCommand(Field fieldInfo)
        {
            var cmd = new CropServerCommand(ServerCommands.Plant);
            cmd.Field.Name = fieldInfo.Name;
            cmd.Field.Crop = fieldInfo.Crop;
            Send(cmd);
        }

        public void SendHarvestCommand(Field fieldInfo)
        {
            var cmd = new CropServerCommand(ServerCommands.Harvest);
            cmd.Field.Name = fieldInfo.Name;
            Send(cmd);
        }

        private void Send(CropServerCommand cmd)
        {
            WriteLineAndGetReply(cmd.ToJson(), TimeSpan.FromMilliseconds(500));
        }
        
    }
}
