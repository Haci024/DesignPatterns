using CQRS.Connection;
using CQRS.CQRS.Result;

namespace CQRS.CQRS.Handler
{
    public class GetProductHandler
    {
        private readonly AppDbContext _db;
        public GetProductHandler(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<GetProductResult> Handle()
        {
            return _db.Products.Select(x => new GetProductResult
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,

            }).ToList();
        }
    }
}
