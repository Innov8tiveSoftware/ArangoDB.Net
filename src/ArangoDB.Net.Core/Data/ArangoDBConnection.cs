using ArangoDB.Net.Core.Abstractions;
using System;
using System.Collections.Generic;
using ArangoDB.Net.Core.Models;
using Microsoft.Extensions.Logging;

namespace ArangoDB.Net.Core.Data
{
    public class ArangoDBConnection<TDataType> : IDatabaseConnection where TDataType : new()
    {
        public DatabaseInfo Current => throw new NotImplementedException();

        private readonly ILogger _logger;
        private readonly IDatabaseServerConnection _serverConnection;
        private readonly IDatabaseConnection _databaseConnection;

        internal ArangoDBConnection(IDatabaseRecordParser<TDataType> parser, IDatabaseConnectionProtocol<TDataType> protocol, ILogger logger, string database)
        {
            if (parser == null) throw new ArgumentNullException($"{nameof(parser)}");
            if (protocol == null) throw new ArgumentNullException($"{nameof(protocol)}");
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentException($"{nameof(database)}");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)}");

            _serverConnection = protocol.CreateServerConnection(parser, logger);
            _databaseConnection = _serverConnection.Connect(database);
        }

        public IEnumerable<TResultType> ExecuteQuery<TResultType>(string aql)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResultType> ExecuteQuery<TResultType>(QueryDefinition queryDefinition)
        {
            throw new NotImplementedException();
        }

        public void Import<T>(IEnumerable<T> input)
        {
            throw new NotImplementedException();
        }
    }
}
