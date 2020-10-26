using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Number { get; set; }

        private List<OrderLine> _lines = new List<OrderLine>();
        public IReadOnlyCollection<OrderLine> Lines => _lines.AsReadOnly();

        public void AddLine(OrderLine line)
        {
            _lines.Add(line);
        }
    }
}
