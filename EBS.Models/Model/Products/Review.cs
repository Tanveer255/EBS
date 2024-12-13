using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBS.Models.Model.Products
{
    [Table("Review")]
    public class Review : _Base
    {
        public new Guid Id { get; set; }
        public new bool IsDeleted { get; set; }
        public new DateTime CreatedTimeStamp { get; set; }
        public new DateTime UpdatedTimeStamp { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid? UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
