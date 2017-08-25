using ArangoDB.Net.Core.Abstractions;
using ArangoDB.Net.Core.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ArangoDB.Net.Core
{
    public class DatabaseConfiguration
    {
        public DatabaseConnectionConfiguration<TResultType> ConnectWith<TResultType>() where TResultType : new()
        {
            _connectionType = typeof(TResultType);
            return new DatabaseConnectionConfiguration<TResultType>(this, (s) =>
            {
                if (s == null)
                    throw new ArgumentNullException($"{nameof(s)} cannot be null.");
                _serializer = s;
            }, (ca) =>
            {
                if (ca == null)
                    throw new ArgumentNullException($"{nameof(ca)} cannot be null.");
                _connectionProtocol = ca;
            });
        }
        public DatabaseLoggingConfiguration LogWith { get; }

        private object _serializer;
        private object _connectionProtocol;
        private ILogger _logger;
        private Type _connectionType;

        private IDatabaseConnection _orientConnection;

        public DatabaseConfiguration()
        {
            LogWith = new DatabaseLoggingConfiguration(this, (l) =>
            {
                if (l == null)
                    throw new ArgumentNullException($"{nameof(l)} cannot be null.");
                _logger = l;
            });
        }


        public IDatabaseConnectionFactory CreateFactory()
        {
            if (_connectionProtocol == null)
                throw new NullReferenceException($"{_connectionProtocol} cannot be null.");
            if (_serializer == null)
                throw new NullReferenceException($"{_serializer} cannot be null.");
            if (_logger == null)
                throw new NullReferenceException($"{_logger} cannot be null.");

            var factoryType = typeof(DatabaseConnectionFactory<>).MakeGenericType(_connectionType);

            ConstructorInfo info = factoryType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            return (IDatabaseConnectionFactory)info.Invoke(new object[] { _connectionProtocol, _serializer, _logger });
        }
    }
}
