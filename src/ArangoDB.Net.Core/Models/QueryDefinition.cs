using System;
using System.Collections.Generic;
using System.Text;

namespace ArangoDB.Net.Core.Models
{
    public class QueryDefinition
    {
        public string Query { get; set; } = string.Empty;
        public QueryOptions Options { get; set; }
    }
}
