using ChainOfResponsibilty.Connection;
using ChainOfResponsibilty.DTO;
using ChainOfResponsibilty.Handlers;
using ChainOfResponsibilty.Models;

namespace ChainOfResponsibilty.Handlers
{
   
    public class CurrencyExchangeHandler : ActionHandler
    {
        private readonly AppDbContext _context;

        public CurrencyExchangeHandler(AppDbContext context)
        {
            _context = context;
        }

        public override void Handle(ActionRequestDTO request)
        {
            if (request.TransactionType == "CurrencyExchange")
            {
                var account = _context.BankAccounts.FirstOrDefault(a => a.UserId == request.UserId);

                if (account == null)
                {


                    Console.WriteLine("CurrencyExchangeHandler: The User Not Found");
                }
                else
                {
                    Transactions transaction = new();
                    transaction.TransactionType=request.TransactionType;
                    transaction.UserId = account.UserId;
                    var exchangeRate = 1.7m;
                    var exchangedAmount = (account.Balance / exchangeRate);
                    if (exchangedAmount>=request.Amount)
                    {
                        exchangedAmount -= request.Amount;
                        transaction.Amount=request.Amount;
                        account.Balance = exchangedAmount * 1.7m;
                        transaction.result = $"CurrencyExchangeHandler: {request.Amount} USD remove from account. New Balance: {account.Balance} Azn";
                        _context.Update(account);
                    }
                    else
                    {
                        transaction.Amount = 0;
                        transaction.result = $"CurrencyExchangeHandler: Your balance lower than to {request.Amount} USD";
                    }
                    _context.Add(transaction);
                    _context.SaveChanges();
                  
                }   
            }
            else
            {    
            _nextHandler?.Handle(request);

                Console.WriteLine("Prosess ötürüldü");
            }
            
          
        }
    }

}
