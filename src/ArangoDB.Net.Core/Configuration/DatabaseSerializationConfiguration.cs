using ArangoDB.Net.Core.Abstractions;
using System;

namespace ArangoDB.Net.Core.Configuration
{
    public class DatabaseSerializationConfiguration<TDataType> where TDataType : new()
    {
        private readonly DatabaseConfiguration _configuration;
        private readonly Action<IDatabaseRecordParser<TDataType>> _addParser;

        internal DatabaseSerializationConfiguration(DatabaseConfiguration configuration, Action<IDatabaseRecordParser<TDataType>> addParser)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            if (addParser == null)
                throw new ArgumentNullException($"{nameof(addParser)} cannot be null.");
            _configuration = configuration;
            _addParser = addParser;
        }

        public DatabaseConfiguration Serializer(IDatabaseRecordParser<TDataType> parser)
        {
            if (parser == null)
                throw new ArgumentNullException($"{nameof(parser)} cannot be null.");
            _addParser(parser);
            return _configuration;
        }
    }
}
