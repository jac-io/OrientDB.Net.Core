using OrientDB.Net.Core.ConnectionProtocols.Binary.Core;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Command
{
    internal interface ICommandPayloadConstructorFactory
    {
        ICommandPayload CreatePayload(string query, string fetchPlan, ConnectionMetaData metaData);
    }
}
