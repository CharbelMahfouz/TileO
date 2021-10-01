using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TileO.Models
{
    public partial class TilesTypes
    {
        [Key]
        public int Id { get; set; }
        [Column("ImageURL")]
        [StringLength(500)]
        public string ImageUrl { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.TilesTypes))]
        public virtual Products Product { get; set; }
    }
}
