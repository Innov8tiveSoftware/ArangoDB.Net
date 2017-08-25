using ArangoDB.Net.Core.Models;
using System.Collections.Generic;

namespace ArangoDB.Net.Core.Abstractions
{
    public interface IDatabaseConnection
    {
        DatabaseInfo Current { get; }
        IEnumerable<TResultType> ExecuteQuery<TResultType>(string aql);
        IEnumerable<TResultType> ExecuteQuery<TResultType>(QueryDefinition queryDefinition);
        void Import<T>(IEnumerable<T> input);
    }
}
