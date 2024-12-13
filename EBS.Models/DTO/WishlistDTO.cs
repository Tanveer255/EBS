using EBS.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.DTO
{
    internal class WishlistDTO : Wishlist
    {
        public new Guid Id { get; set; }
        public new bool IsDeleted { get; set; }
        public new DateTime CreatedTimeStamp { get; set; }
        public new DateTime UpdatedTimeStamp { get; set; }
        public new Guid? UserId { get; set; }
        public new List<Product> products { get; set; }
        public Wishlist MapDtoToModel(WishlistDTO dto)
        {
            return new Wishlist()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                UpdatedTimeStamp = dto.UpdatedTimeStamp,
                CreatedTimeStamp = dto.CreatedTimeStamp,
                UserId = dto.UserId,
            };
        }

        public WishlistDTO MapModelToDto(Wishlist entity)
        {
            return new WishlistDTO()
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                UpdatedTimeStamp = entity.UpdatedTimeStamp,
                CreatedTimeStamp = entity.CreatedTimeStamp,
                UserId = entity.UserId,
            };
        }
    }
}
