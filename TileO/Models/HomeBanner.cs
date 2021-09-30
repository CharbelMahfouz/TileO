using System;
using System.Collections.Generic;

namespace TileO.Models
{
    public partial class HomeBanner
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int? OrderId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
