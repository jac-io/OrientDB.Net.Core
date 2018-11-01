using System.Collections.Generic;
using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results
{
    internal class DocumentResult
    {
        public IEnumerable<DictionaryOrientDBEntity> Results { get; }

        public DocumentResult(IEnumerable<DictionaryOrientDBEntity> results)
        {
            Results = results;
        }
    }
}
