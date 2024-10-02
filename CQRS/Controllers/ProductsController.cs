using CQRS.Connection;
using CQRS.CQRS.Command;
using CQRS.CQRS.Handler;
using CQRS.CQRS.Queries;
using CQRS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ProductListHandler _getProducts;
        private readonly AddProductHandler _addProducts;
        private readonly GetProductByIdHandler _byIdProdcts;
        private readonly DeleteProductHandler _deleteProduct;
        private readonly UpdateProductHandler _updateProduct;
        public ProductsController(ProductListHandler getProducts,AddProductHandler addProduct,GetProductByIdHandler byIdHandler, DeleteProductHandler deleteProduct,UpdateProductHandler updateHandler)
        {
               _getProducts =getProducts;
            _updateProduct = updateHandler;
           _addProducts = addProduct;
            _byIdProdcts = byIdHandler;
            _deleteProduct=deleteProduct;   
        }
        [HttpGet("List")]
        public async Task<IActionResult> ProductList()
        {

            return Ok(_getProducts.Handle());
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data=_byIdProdcts.Handle(new GetProductByIdQuery(Id));

            return Ok(data);
        }
        [HttpPost("Create")]
        public IActionResult AddProduct(AddProductCommand products)
        {
              _addProducts.Handle(products);
           
            return Ok("Mehsul əlavə edildi!");
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            _deleteProduct.Handle(new DeleteProductCommand(Id));

            return Ok("Mehsul silindi!");
        }
        [HttpPut("Update/{id}")]
        public IActionResult UpdateProduct(int id,UpdateProductCommand command)
        {
            command.Id = id;
             _updateProduct.Update(command);
           
            return Ok(command);
        }
    }
}
