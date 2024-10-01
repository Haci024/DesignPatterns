using System.Data.SqlTypes;

namespace CQRS.CQRS.Result
{
    public class GetProductResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
