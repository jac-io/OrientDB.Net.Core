using System.IO;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Contracts;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Core;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations
{
	internal class ServerShutdownOperation : IOrientDBOperation<VoidResult>
	{
		private readonly ConnectionMetaData _connectionMetaData;
		private readonly string _username;
		private readonly string _password;

		public ServerShutdownOperation(ConnectionMetaData connectionMetaData, string username, string password)
		{
			this._connectionMetaData = connectionMetaData;
			this._username = username;
			this._password = password;
		}

		public Request CreateRequest(int sessionId, byte[] token)
		{
			Request request = new Request(OperationMode.Synchronous);

			// standard request fields
			request.AddDataItem((byte)OperationType.SHUTDOWN);
			request.AddDataItem(request.SessionId);

			request.AddDataItem(_username);
			request.AddDataItem(_password);

			return request;
		}

		public VoidResult Execute(BinaryReader reader)
		{
			return new VoidResult();
		}
	}
}