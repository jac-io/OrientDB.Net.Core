using OrientDB.Net.Core.Abstractions;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Contracts
{
    internal interface IOrientDBConnection
    {
        IOrientDBCommand CreateCommand();
        IOrientDBTransaction CreateTransaction();
    }
}