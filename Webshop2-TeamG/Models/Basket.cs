using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    internal class Basket
    {
        public int Id { get; set; }
        public List<Game> BasketGames { get; set; }
        public int CustomerId { get; set; }
        public DateTime Today { get; set; }
        public string DeliveryOption { get; set; }
    }
}
