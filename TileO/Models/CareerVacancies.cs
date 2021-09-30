using System;
using System.Collections.Generic;

namespace TileO.Models
{
    public partial class CareerVacancies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Responsabilities { get; set; }
        public string Experience { get; set; }
        public string Qualifications { get; set; }
        public string About { get; set; }
        public string Status { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
