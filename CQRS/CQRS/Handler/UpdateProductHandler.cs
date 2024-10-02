using CQRS.Connection;
using CQRS.CQRS.Command;

namespace CQRS.CQRS.Handler
{
    public class UpdateProductHandler
    {
        private readonly AppDbContext _db;
        public UpdateProductHandler(AppDbContext db)
        {
            _db = db;
        }
        public void Update(UpdateProductCommand productCommand)
        {
           var product = _db.Products.FirstOrDefault(x=>x.Id==productCommand.Id);
            product.Price = productCommand.Price;
            product.Description = productCommand.Description;
            product.Name = productCommand.Name;
            product.Status = productCommand.Status;
            _db.Products.Update(product);
            _db.SaveChanges();

        }
    }
}
