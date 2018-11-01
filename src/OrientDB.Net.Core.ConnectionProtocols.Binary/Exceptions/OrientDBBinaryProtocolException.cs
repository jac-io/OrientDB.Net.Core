using System;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Exceptions
{
    public class OrientDBBinaryProtocolException : Exception
    {
        public OrientDBBinaryProtocolExceptionType Type { get; }

        public OrientDBBinaryProtocolException()
        {

        }

        public OrientDBBinaryProtocolException(OrientDBBinaryProtocolExceptionType type, string message) : base(message)
        {
            Type = type;
        }

        public OrientDBBinaryProtocolException(OrientDBBinaryProtocolExceptionType type, string message, Exception innerException) : base(message, innerException)
        {
            Type = type;
        }
    }
}
