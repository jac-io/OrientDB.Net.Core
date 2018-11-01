using System.Collections.Generic;
using OrientDB.Net.Core.Abstractions;
using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Contracts
{
    public interface IOrientDBCommand
    {
        IEnumerable<T> Execute<T>(string query) where T : OrientDBEntity;

        IOrientDBCommandResult Execute(string query);
    }
}