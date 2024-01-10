using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string? CreditCard { get; set; }
        public Customer() 
        {
            History = new HashSet<Basket>();
        }
        public virtual ICollection<Basket> History { get; set; } // when adding to history, add date - ICollection

    }
}
