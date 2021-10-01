using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TileO.Models;

namespace TileO.ViewModels
{
    public class ProductType_VM
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public int? ProductId { get; set; }
      

    }
}
