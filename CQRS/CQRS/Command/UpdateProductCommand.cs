namespace CQRS.CQRS.Command
{
    public class UpdateProductCommand
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
