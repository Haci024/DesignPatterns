using CQRS.Connection;
using CQRS.CQRS.Command;

namespace CQRS.CQRS.Handler
{
    public class UpdateProductHandler
    {
        private readonly AppDbContext _db;
        public UpdateProductHandler(AppDbContext db)
        {
            _db = _db;
        }
        public void Update(UpdateProductCommand productCommand)
        {
            

        }
    }
}
