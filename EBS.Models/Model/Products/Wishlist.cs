using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBS.Models.Model.Products
{
    [Table("Wishlist")]
    public class Wishlist : _Base
    {
        public Guid? UserId { get; set; }
    }
}
