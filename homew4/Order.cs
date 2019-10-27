using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homew4
{
    public class Order : Entity
    {
        public Guid SellerId { get; set; }
        public Guid BuyerId { get; set; }
        public int OrderPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
