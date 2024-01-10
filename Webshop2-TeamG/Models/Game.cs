using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    
    public enum AgeRating
    {
        Everyone,
        Teen,
        Mature
    }
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int Stock { get; set; }
        public AgeRating AgeRating { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
    }
}
