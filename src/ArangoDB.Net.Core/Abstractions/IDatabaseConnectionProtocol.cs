using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArangoDB.Net.Core.Abstractions
{
    public interface IDatabaseConnectionProtocol<TDataType> : IDisposable where TDataType : new()
    {
        IDatabaseServerConnection CreateServerConnection(IDatabaseRecordParser<TDataType> parser, ILogger logger);
    }
}
