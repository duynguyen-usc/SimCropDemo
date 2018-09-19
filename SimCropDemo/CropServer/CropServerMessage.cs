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

        public void Clear()
        {
            Response = ServerResponses.None;
            Fields.Clear();
            FieldInfo.Harvest();
        }
    }
}
