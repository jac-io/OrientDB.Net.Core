using System.IO;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Core;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Contracts
{
    internal interface IOrientDBRequest
    {
        Request CreateRequest(int sessionId, byte[] token);
    }

    internal interface IOrientDBOperation<T> : IOrientDBRequest
    {        
        T Execute(BinaryReader reader);
    }
}
