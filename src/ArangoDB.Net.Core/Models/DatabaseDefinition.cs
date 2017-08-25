using System.Collections.Generic;

namespace ArangoDB.Net.Core.Models
{
    public class DatabaseDefinition
    {
        public string Name { get; set; } = string.Empty;
        public List<DatabaseUser> Users { get; set; } = new List<DatabaseUser>();
    }
}
