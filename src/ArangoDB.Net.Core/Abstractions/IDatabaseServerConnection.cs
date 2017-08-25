using ArangoDB.Net.Core.Models;
using System.Collections.Generic;

namespace ArangoDB.Net.Core.Abstractions
{
    public interface IDatabaseServerConnection
    {
        IDatabaseConnection Connect(string database);
        IDatabaseConnection CreateDatabase(string database);
        IDatabaseConnection CreateDatabase(DatabaseDefinition database);
        void DeleteDatabase(string database);
        IEnumerable<string> ListDatabases();
    }
}
