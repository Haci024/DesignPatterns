using CQRS.Connection;
using CQRS.CQRS.Result;
using CQRS.Models;

namespace CQRS.CQRS.Queries
{
    public class GetProductByIdQuery
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
