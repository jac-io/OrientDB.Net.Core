namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results
{
    public class CloseDatabaseResult
    {
        public bool IsSuccess { get; }

        public CloseDatabaseResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
