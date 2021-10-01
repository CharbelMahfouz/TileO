﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TileO.Models
{
    public partial class AspNetRoleClaims
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRoles.AspNetRoleClaims))]
        public virtual AspNetRoles Role { get; set; }
    }
}
