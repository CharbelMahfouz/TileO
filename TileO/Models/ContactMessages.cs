using System;
using System.Collections.Generic;

namespace TileO.Models
{
    public partial class ContactMessages
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sunject { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string IsDeleted { get; set; }
        public string Direction { get; set; }
        public string OurComment { get; set; }
        public DateTime? CreatedDated { get; set; }
    }
}
