﻿using System;

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

        public CropServerMessage(string messageString)
        {
            Enum.TryParse(messageString.TrimEnd(';'), out Response);
        }

        public override string ToString()
        {
            return Response.ToString() + ";" + Message;
        }
    }
}
