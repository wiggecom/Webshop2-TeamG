using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    public class Administrator
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
            public string? Street { get; set; }
            public string? PostalCode { get; set; }
            public string? City { get; set; }
            public string? Country { get; set; }

    }
}
