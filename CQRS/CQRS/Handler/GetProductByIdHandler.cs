using CQRS.Connection;
using CQRS.CQRS.Queries;
using CQRS.CQRS.Result;
using CQRS.Models;

namespace CQRS.CQRS.Handler
{
    public class GetProductByIdHandler
    {
        private readonly AppDbContext _db;
        public GetProductByIdHandler(AppDbContext db)
        {
            _db = db;
        }
        public GetProductByIdResult Handle(GetProductByIdQuery query)
        {
            return _db.Products.Select(x => new GetProductByIdResult
            {
             Id = x.Id,
             Name =x.Name,
             Price=x.Price
            }).First(x => x.Id == query.Id);

           
        }
    }
}
