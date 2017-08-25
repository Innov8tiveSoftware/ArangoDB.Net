using System;
using System.Collections.Generic;
using System.Text;

namespace ArangoDB.Net.Core.Abstractions
{
    public interface IDatabaseRecordParser<TDataType> where TDataType : new()
    {
    }
}
