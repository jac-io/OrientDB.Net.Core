using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OrientDB.Net.Core.Abstractions;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Command;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Contracts;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Operations;
using OrientDB.Net.Core.Models;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Core
{
    public class OrientDBCommand : IOrientDBCommand
    {
        private readonly OrientDBBinaryConnectionStream _stream;
        private readonly IOrientDBRecordSerializer<byte[]> _serializer;
        private readonly ICommandPayloadConstructorFactory _payloadFactory;
        private readonly ILogger _logger;

        internal OrientDBCommand(OrientDBBinaryConnectionStream stream, IOrientDBRecordSerializer<byte[]> serializer, ICommandPayloadConstructorFactory payloadFactory, ILogger logger)
        {
            _stream = stream ?? throw new ArgumentNullException($"{nameof(stream)} cannot be null.");
            _serializer = serializer ?? throw new ArgumentNullException($"{nameof(serializer)} cannot be null");
            _payloadFactory = payloadFactory ?? throw new ArgumentNullException($"{nameof(payloadFactory)} cannot be null");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannt be null.");            
        }

        public IEnumerable<T> Execute<T>(string query) where T : OrientDBEntity
        {
            return _stream.Send(new DatabaseCommandOperation<T>(_payloadFactory, _stream.ConnectionMetaData, _serializer, _logger, query)).Results;
        }

        public IOrientDBCommandResult Execute(string query)
        {
            //var results = _stream.Send(new DatabaseCommandOperation<T>(_payloadFactory, _stream.ConnectionMetaData, _serializer, _logger, query)).Results;
            var results = _stream.Send(new DocumentResultDatabaseCommandOperation(_payloadFactory, _stream.ConnectionMetaData, _serializer, query));
            return new BasicCommandResult()
            {
                RecordsAffected = results.Results.Count(),
                UpdatedRecords = results.Results
            };
        }
    }
}
