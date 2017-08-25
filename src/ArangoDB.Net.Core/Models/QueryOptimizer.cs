using System.Collections.Generic;

namespace ArangoDB.Net.Core.Models
{
    public class QueryOptimizer
    {
        public List<string> Rules { get; set; } = new List<string>();
    }
}
