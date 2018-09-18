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
