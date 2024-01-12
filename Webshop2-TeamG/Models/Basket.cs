using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    public class Basket
    {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }

        public DateTime Today { get; set; }
        public string DeliveryOption { get; set; }

        public ICollection<BasketEntry> BasketEntries { get; set; } = new List<BasketEntry>();

    }
}
