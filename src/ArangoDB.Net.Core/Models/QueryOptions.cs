namespace ArangoDB.Net.Core.Models
{
    public class QueryOptions
    {
        public int MaxNumberOfPlans { get; set; }
        public bool AllPlans { get; set; }
        public QueryOptimizer Optimizer { get; set; }
    }
}
