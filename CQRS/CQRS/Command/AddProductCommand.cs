using CQRS.Connection;
using CQRS.CQRS.Result;

namespace CQRS.CQRS.Command
{
    public class AddProductCommand
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}
