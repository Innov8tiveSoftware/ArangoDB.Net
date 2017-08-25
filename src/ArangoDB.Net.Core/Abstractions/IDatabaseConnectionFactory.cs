namespace ArangoDB.Net.Core.Abstractions
{
    public interface IDatabaseConnectionFactory
    {
        IDatabaseServerConnection CreateConnection();
    }
}
