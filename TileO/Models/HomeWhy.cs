using System;
using System.Collections.Generic;

namespace TileO.Models
{
    public partial class HomeWhy
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
