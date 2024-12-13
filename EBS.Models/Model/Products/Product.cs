using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBS.Models.Model.Products
{
    [Table("Product")]
    public class Product : _Base
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public DateTime ListingDate { get; set; }

    }
}
