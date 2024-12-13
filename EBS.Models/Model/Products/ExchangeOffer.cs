using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBS.Models.Model.Products
{
    [Table("ExchangeOffer")]
    public class ExchangeOffer : _Base
    {
        public int OfferedProductId { get; set; }
        public int RequestedProductId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime OfferDate { get; set; }
        public string Status { get; set; }
    }
}
