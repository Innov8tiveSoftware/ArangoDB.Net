using Microsoft.Extensions.Logging;
using System;

namespace ArangoDB.Net.Core.Configuration
{
    public class DatabaseLoggingConfiguration
    {
        private readonly DatabaseConfiguration _configuration;
        private readonly Action<ILogger> _loggerAction;

        internal DatabaseLoggingConfiguration(DatabaseConfiguration configuration, Action<ILogger> loggerAction)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            if (loggerAction == null)
                throw new ArgumentNullException($"{nameof(loggerAction)} cannot be null");
            _configuration = configuration;
            _loggerAction = loggerAction;
        }

        public DatabaseConfiguration Logger(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            _loggerAction(logger);
            return _configuration;
        }
    }
}
