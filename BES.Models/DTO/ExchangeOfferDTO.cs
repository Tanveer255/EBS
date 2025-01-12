using EBS.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.DTO
{
    public class ExchangeOfferDTO : ExchangeOffer
    {
        public new Guid Id { get; set; }
        public new bool IsDeleted { get; set; }
        public new DateTime CreatedTimeStamp { get; set; }
        public new DateTime UpdatedTimeStamp { get; set; }
        public new int OfferedProductId { get; set; }
        public new int RequestedProductId { get; set; }

        public new Guid? UserId { get; set; }
        public new DateTime OfferDate { get; set; }
        public new string Status { get; set; } = string.Empty;
        public ExchangeOffer MapDtoToModel(ExchangeOfferDTO dto)
        {
            return new ExchangeOffer()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                UpdatedTimeStamp = dto.UpdatedTimeStamp,
                CreatedTimeStamp = dto.CreatedTimeStamp,
                UserId = dto.UserId,
                RequestedProductId = dto.RequestedProductId,
                OfferedProductId = dto.OfferedProductId,
                OfferDate = dto.OfferDate,
                Status = dto.Status
            };
        }

        public ExchangeOfferDTO MapModelToDto(ExchangeOffer entity)
        {
            return new ExchangeOfferDTO()
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                UpdatedTimeStamp = entity.UpdatedTimeStamp,
                CreatedTimeStamp = entity.CreatedTimeStamp,
                UserId = entity.UserId,
                RequestedProductId = entity.RequestedProductId,
                OfferedProductId = entity.OfferedProductId,
                OfferDate = entity.OfferDate,
                Status = entity.Status
            };
        }
    }
}
