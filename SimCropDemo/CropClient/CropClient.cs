using System;
using System.Text;
using CropServer;

namespace CropClient
{
    public class CropClient: SimpleTCP.SimpleTcpClient
    {
        public CropServerMessage LastServerMessage = new CropServerMessage();

        public CropClient() : base()
        {
            this.StringEncoder = Encoding.UTF8;
            base.DataReceived += CropClient_DataReceived;
        }

        public void TestConnection()
        {
            Send(new CropServerCommand(ServerCommands.TestConnection));
        }

        public void SendGetInfoAllFieldsCommand()
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

        private void CropClient_DataReceived(object sender, SimpleTCP.Message e)
        {
            LastServerMessage = JsonToMessage(e.MessageString.TrimEnd('\u0013'));
        }

        private void Send(CropServerCommand cmd)
        {
            WriteLineAndGetReply(ConvertToJson(cmd), TimeSpan.FromMilliseconds(500));
        }

        private string ConvertToJson(CropServerCommand cropServerCommand)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(cropServerCommand);
        }

        private CropServerMessage JsonToMessage(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CropServerMessage>(json);
        }
    }
}
