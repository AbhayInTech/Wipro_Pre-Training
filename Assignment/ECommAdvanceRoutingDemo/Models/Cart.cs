using System.Collections.Generic;

namespace ECommAdvanceRoutingDemo.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
