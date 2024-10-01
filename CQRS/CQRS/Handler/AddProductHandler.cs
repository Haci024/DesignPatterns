using CQRS.Connection;
using CQRS.CQRS.Command;
using CQRS.Models;
namespace CQRS.CQRS.Handler
{
    public class AddProductHandler
    {
        private readonly AppDbContext _db;
        public AddProductHandler(AppDbContext db)
        {
            _db = db;
        }
        public void Handle(AddProductCommand product)
        {
            _db.Products.Add(new Products
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Status = product.Status,

            });
            _db.SaveChanges();  
        }

    }
    
}
