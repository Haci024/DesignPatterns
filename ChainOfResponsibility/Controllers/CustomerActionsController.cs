using ChainOfResponsibilty.Connection;
using ChainOfResponsibilty.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChainOfResponsibilty.Handlers;

namespace ChainOfResponsibilty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerActionsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CustomerActionsController(AppDbContext db)
        {
            _db= db;
        }
        [HttpPost("process")]
        public IActionResult ProcessTransaction(ActionRequestDTO request)
        {
            var withdrawHandler = new WithdrawHandler(_db);
            var checkBalanceHandler = new CheckBalanceHandler(_db);
            var currencyExchangeHandler = new CurrencyExchangeHandler(_db);
            withdrawHandler.SetNext(checkBalanceHandler);
            checkBalanceHandler.SetNext(currencyExchangeHandler);
            withdrawHandler.Handle(request);

            return Ok();
        }
    }
}
