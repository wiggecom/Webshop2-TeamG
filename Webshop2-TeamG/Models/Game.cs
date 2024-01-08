using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    
    public enum AgeRating { age3 = 3, age7 = 7, age12 = 12, age16 = 16, age18 = 18 }
    internal class Game
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
        public AgeRating AgeRating { get; set; }
        public string Publisher { get; set; }
        public bool OnDisplay { get; set; }
        public bool OnSale { get; set; }
        public int SalePercent { get; set; }
        public int Stock { get; set; }

        // Navigation Property
        public virtual Platform platform { get; set; }
    }
}
