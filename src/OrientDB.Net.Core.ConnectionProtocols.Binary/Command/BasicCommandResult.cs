using System.Collections.Generic;
using OrientDB.Net.Core.Abstractions;
using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Command
{
    public class BasicCommandResult : IOrientDBCommandResult
    {
        public int RecordsAffected { get; set; }

        public IEnumerable<DictionaryOrientDBEntity> UpdatedRecords { get; set; }
    }
}
