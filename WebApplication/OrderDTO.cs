using System.Collections.Generic;

namespace WebApplication
{
    public class OrderDTO
    {
        public string Number { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
