namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results
{
    public class OpenServerResult
    {
        public int SessionId { get; set; }
        public byte[] Token { get; set; }
    }
}
