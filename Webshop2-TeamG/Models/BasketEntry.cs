using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    public class BasketEntry
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int Quantity { get; set; }

    }
}
