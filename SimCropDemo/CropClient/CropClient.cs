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
    }
}
