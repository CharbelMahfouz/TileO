using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TileO.ViewModels
{
    public class Product_VM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public  List<ProductType_VM> ProductTypes { get; set; }
    }
}
