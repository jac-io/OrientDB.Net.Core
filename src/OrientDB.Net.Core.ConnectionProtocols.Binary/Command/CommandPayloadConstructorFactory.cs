﻿using System;
using Microsoft.Extensions.Logging;
using OrientDB.Net.Core.ConnectionProtocols.Binary.Core;

namespace OrientDB.Net.Core.ConnectionProtocols.Binary.Command
{
    internal class CommandPayloadConstructorFactory : ICommandPayloadConstructorFactory
    {
        private readonly ILogger _logger;

        public CommandPayloadConstructorFactory(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannt be null.");
        }

        public ICommandPayload CreatePayload(string query, string fetchPlan, ConnectionMetaData metaData)
        {
            if (query.ToLower().StartsWith("select"))
                return new SelectCommandPayload(query, fetchPlan, metaData, _logger);
            if (query.ToLower().StartsWith("insert"))
                return new InsertCommandPayload(query, fetchPlan, metaData, _logger);
            if(query.ToLower().StartsWith("create")) // Maybe we really don't need a bunch of different types here.
                return new InsertCommandPayload(query, fetchPlan, metaData, _logger); // This works...
            if(query.ToLower().StartsWith("update"))
                return new InsertCommandPayload(query, fetchPlan, metaData, _logger);
            if (query.ToLower().StartsWith("delete"))
                return new InsertCommandPayload(query, fetchPlan, metaData, _logger); // calling the payload of a delete command "insert" ins't very helpful - need to do something better here

            throw new NotImplementedException(string.Format("Cannot determine the appropriate payload type for query '{0}'", query));
        }
    }
}
