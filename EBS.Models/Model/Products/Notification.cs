using EBS.Models.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBS.Models.Model.Products
{
    [Table("Notification")]
    public class Notification : _Base
    {
        public Guid? UserId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Message { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
