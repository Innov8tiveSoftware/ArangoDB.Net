using ArangoDB.Net.Core.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace ArangoDB.Net.Protocols.Http
{
    public class HttpProtocol<TDataType> : IDatabaseConnectionProtocol<TDataType> where TDataType : new()
    {
        public HttpProtocol()
        {

        }

        public IDatabaseServerConnection CreateServerConnection(IDatabaseRecordParser<TDataType> parser, ILogger logger)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
 