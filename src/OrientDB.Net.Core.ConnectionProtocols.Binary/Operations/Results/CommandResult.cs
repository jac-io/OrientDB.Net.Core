using System.Collections.Generic;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results
{
    internal class CommandResult<T>
    {
        public IEnumerable<T> Results { get; }

        public CommandResult(IEnumerable<T> results)
        {
            Results = results;
        }
    }
}