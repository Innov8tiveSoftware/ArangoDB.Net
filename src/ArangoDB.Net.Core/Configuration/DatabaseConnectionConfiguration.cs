using ArangoDB.Net.Core.Abstractions;
using System;

namespace ArangoDB.Net.Core.Configuration
{
    public class DatabaseConnectionConfiguration<TDataType> where TDataType : new()
    {
        private readonly DatabaseConfiguration _configuration;
        private readonly Action<IDatabaseConnectionProtocol<TDataType>> _configAction;
        private readonly Action<IDatabaseRecordParser<TDataType>> _parser;

        internal DatabaseConnectionConfiguration(DatabaseConfiguration configuration, Action<IDatabaseRecordParser<TDataType>> parser, Action<IDatabaseConnectionProtocol<TDataType>> configAction)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            if (parser == null)
                throw new ArgumentNullException($"{nameof(parser)} cannot be null.");
            if (configAction == null)
                throw new ArgumentNullException($"{nameof(configAction)} cannot be null.");
            _configuration = configuration;
            _configAction = configAction;
            _parser = parser;
        }

        public DatabaseConnectionProtocolConfiguration<TDataType> Connect(IDatabaseConnectionProtocol<TDataType> protocol)
        {
            if (protocol == null)
                throw new ArgumentNullException($"{nameof(protocol)} cannot be null.");
            _configAction(protocol);
            return new DatabaseConnectionProtocolConfiguration<TDataType>(_configuration, _parser, _configAction);
        }
    }
}
