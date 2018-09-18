namespace CropServer
{
    public enum ServerResponses
    {
        None,
        TestConnectionSuccess,
        CommandSuccess,
        CommandFailed,
        BadCommand
    }

    public class CropServerMessage
    {
        public ServerResponses Response = ServerResponses.None;
        public string Message = string.Empty;

        public CropServerMessage() { }

        public override string ToString()
        {
            return Response.ToString() + ":" + Message;
        }
    }
}
