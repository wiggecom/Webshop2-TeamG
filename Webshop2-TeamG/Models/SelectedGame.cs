﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    internal class SelectedGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int Stock { get; set; }
        public int SoldTotal { get; set; }
        public AgeRating AgeRating { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
        public int? OnDisplay { get; set; }
    }
}
