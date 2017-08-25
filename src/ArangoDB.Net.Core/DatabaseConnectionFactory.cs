using System;
using ArangoDB.Net.Core.Abstractions;
using Microsoft.Extensions.Logging;

namespace ArangoDB.Net.Core
{
    internal class DatabaseConnectionFactory<TDataType> : IDatabaseConnectionFactory where TDataType : new()
    {
        private readonly IDatabaseConnectionProtocol<TDataType> _connectionProtocol;
        private readonly IDatabaseRecordParser<TDataType> _parser;
        private readonly ILogger _logger;

        internal DatabaseConnectionFactory(IDatabaseConnectionProtocol<TDataType> protocol, IDatabaseRecordParser<TDataType> parser, ILogger logger)
        {
            _connectionProtocol = protocol ?? throw new ArgumentNullException($"{nameof(protocol)} cannot be null.");
            _parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} cannot be null");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null");
        }

        public IDatabaseServerConnection CreateConnection()
        {
            return _connectionProtocol.CreateServerConnection(_parser, _logger);
        }
    }
}
