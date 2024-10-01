using CQRS.Connection;
using CQRS.CQRS.Command;

namespace CQRS.CQRS.Handler
{
    public class DeleteProductHandler
    {
        private readonly AppDbContext _db;
        public DeleteProductHandler(AppDbContext db)
        {
            _db = db;
        }
        public void Handle(DeleteProductCommand productCommand)
        {
            var entity = _db.Products.FirstOrDefault(x=>x.Id==productCommand.Id);
            _db.Products.Remove(entity);
            _db.SaveChanges();

        }
    }
}
