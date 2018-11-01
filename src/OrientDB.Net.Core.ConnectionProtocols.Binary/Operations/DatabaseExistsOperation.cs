﻿using System.IO;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Constants;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Contracts;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Core;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Extensions;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Operations.Results;
using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Operations
{
    internal class DatabaseExistsOperation : IOrientDBOperation<DatabaseExistsResult>
    {
        private readonly string _database;
        private readonly ConnectionMetaData _metaData;
        private readonly ServerConnectionOptions _options;
        private readonly StorageType _storageType;

        public DatabaseExistsOperation(string database, StorageType storageType, ConnectionMetaData metaData, ServerConnectionOptions options)
        {
            _database = database;
            _metaData = metaData;
            _options = options;
            _storageType = storageType;
        }

        public Request CreateRequest(int sessionId, byte[] token)
        {
            Request request = new Request(OperationMode.Synchronous, sessionId);

            request.AddDataItem((byte)OperationType.DB_EXIST);
            request.AddDataItem(request.SessionId);

            if (DriverConstants.ProtocolVersion > 26 && _metaData.UseTokenBasedSession)
            {
                request.AddDataItem(token);
            }

            request.AddDataItem(_database);
            if (_metaData.ProtocolVersion >= 16) //since 1.5 snapshot but not in 1.5
                request.AddDataItem(_storageType.ToString().ToLower());

            return request;
        }

        internal byte[] ReadToken(BinaryReader reader)
        {
            var size = reader.ReadInt32EndianAware();
            var token = reader.ReadBytesRequired(size);

            // Will need to set this.
            // if token renewed
           // if (token.Length > 0)
            //    _database.GetConnection().Token = token;

            return token;
        }

        public DatabaseExistsResult Execute(BinaryReader reader)
        {
            if (_metaData.ProtocolVersion > 26 && _metaData.UseTokenBasedSession)
                ReadToken(reader);

            // operation specific fields
            byte existByte = reader.ReadByte();

            if (existByte == 0)
            {
                return new DatabaseExistsResult(false);
            }
            else
            {
                return new DatabaseExistsResult(true);
            }
        }
    }
}
