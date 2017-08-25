namespace ArangoDB.Net.Core.Models
{
    public class DatabaseInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsSystem { get; set; } = false;
    }
}
