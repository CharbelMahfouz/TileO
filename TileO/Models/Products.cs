using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TileO.Models
{
    public partial class Products
    {
        public Products()
        {
            TilesTypes = new HashSet<TilesTypes>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column("isDeleted")]
        public bool? IsDeleted { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [Column("ImageURL")]
        [StringLength(500)]
        public string ImageUrl { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(300)]
        public string DivId { get; set; }
        [StringLength(300)]
        public string HrefId { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<TilesTypes> TilesTypes { get; set; }
    }
}
