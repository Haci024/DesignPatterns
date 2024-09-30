namespace ChainOfResponsibilty.DTO
{
    public class ActionRequestDTO
    {
        public ActionRequestDTO()
        {
            UserId = new Guid();
        }
        public string TransactionType { get; set; }  // İşlem tipi (Withdraw, CheckBalance, CurrencyExchange)
        public decimal Amount { get; set; }          // İşlem miktarı
        public Guid UserId { get; set; }
    }
}
