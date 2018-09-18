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

    public class CropServerCommand
    {
        public ServerCommands Command = ServerCommands.None;        
        public CropServerCommand() { }
    }
}
