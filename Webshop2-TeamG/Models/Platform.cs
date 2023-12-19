using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    public enum Models { PC, PS4, PS5, Switch, XboxOne, XboxSeries }
    internal class Platform
    {
        public int Id { get; set; }
        public Models Model {get; set; }

        // Navigation Property
        public virtual Game Game { get; set; }
    }
}
