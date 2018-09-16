using System;
using System.Text;
using CropServer;

namespace CropClient
{
    public class CropClient: SimpleTCP.SimpleTcpClient
    {
        public int Port = 8910;
        public string IpAddress = "127.0.0.1";

        public CropClient()
        {
            this.StringEncoder = Encoding.UTF8;
        }

        public void ConnectToServer()
        {
            this.Connect(IpAddress, Port);
            Write(ServerCommands.TestConnection.ToString());
        }
    }
}
