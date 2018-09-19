using System;
using System.Collections.Generic;

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
        public Field FieldInfo;
        public List<Field> Fields;

        public CropServerMessage() { }

        public CropServerMessage(string messageString)
        {
            var parsedMsg = messageString.Split(';');
            Enum.TryParse(parsedMsg[0], out Response);
        }

        public void Clear()
        {
            Response = ServerResponses.None;

        }
    }
}
