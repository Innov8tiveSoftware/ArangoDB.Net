using ArangoDB.Net.Core.Abstractions;
using System;

namespace ArangoDB.Net.Core.Configuration
{
    public class DatabaseConnectionProtocolConfiguration<TDataType> where TDataType : new()
    {
        public DatabaseSerializationConfiguration<TDataType> SerializeWith { get; }

        private readonly DatabaseConfiguration _configuration;
        private readonly Action<IDatabaseConnectionProtocol<TDataType>> _configAction;
        private readonly Action<IDatabaseRecordParser<TDataType>> _parserAction;

        internal DatabaseConnectionProtocolConfiguration(DatabaseConfiguration configuration, Action<IDatabaseRecordParser<TDataType>> parserAction, Action<IDatabaseConnectionProtocol<TDataType>> configAction)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            if (parserAction == null)
                throw new ArgumentNullException($"{nameof(parserAction)} cannot be null.");
            if (configAction == null)
                throw new ArgumentNullException($"{nameof(configAction)} cannot be null.");
            _configuration = configuration;
            _configAction = configAction;
            _parserAction = parserAction;
            SerializeWith = new DatabaseSerializationConfiguration<TDataType>(_configuration, _parserAction);
        }
    }
}
