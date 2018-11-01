using OrientDB.Net.Core.ConnectionProtocols.Binary.Core;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Command
{
    internal interface ICommandPayload
    {
        Request CreatePayloadRequest(int sessionId, byte[] token);
    }
}
