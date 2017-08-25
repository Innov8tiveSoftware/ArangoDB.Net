using System.Collections.Generic;

namespace ArangoDB.Net.Core.Models
{
    public class ArangoDBResultSet<TDataType> where TDataType : new()
    {
        public IEnumerable<TDataType> Result { get; set; }
        public bool HasMore { get; set; }
        public int Count { get; set; }
        public bool Cached { get; set; }
        public bool Error { get; set; }
        public int Code { get; set; }
        public string Id { get; set; }
    }
}
