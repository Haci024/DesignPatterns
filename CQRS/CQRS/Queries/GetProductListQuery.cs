namespace CQRS.CQRS.Queries
{
    public class GetProductListQuery
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
