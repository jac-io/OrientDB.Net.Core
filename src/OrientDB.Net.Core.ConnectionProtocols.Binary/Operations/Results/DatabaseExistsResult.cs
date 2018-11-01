namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results
{
    class DatabaseExistsResult
    {
        public bool Exists { get; }
        public DatabaseExistsResult(bool databaseExists)
        {
            Exists = databaseExists;
        }
    }
}
