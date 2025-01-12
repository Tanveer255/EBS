using EBS.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.DTO
{
    internal class ReviewDTO : Review
    {
        public new Guid Id { get; set; }
        public new bool IsDeleted { get; set; }
        public new DateTime CreatedTimeStamp { get; set; }
        public new DateTime UpdatedTimeStamp { get; set; }
        public new Guid ProductId { get; set; }
        public new Product Product { get; set; } // Foreign key to Item
        public new Guid? UserId { get; set; }// Foreign key to User
        public new string Comment { get; set; }
        public new int Rating { get; set; } // Rating scale (1 to 5)
        public new DateTime ReviewDate { get; set; }
        public Review MapDtoToModel(ReviewDTO dto)
        {
            return new Review()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                UpdatedTimeStamp = dto.UpdatedTimeStamp,
                CreatedTimeStamp = dto.CreatedTimeStamp,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Comment = dto.Comment,
                Rating = dto.Rating,
                ReviewDate = dto.ReviewDate,
            };
        }

        public ReviewDTO MapModelToDto(Review entity)
        {
            return new ReviewDTO()
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                UpdatedTimeStamp = entity.UpdatedTimeStamp,
                CreatedTimeStamp = entity.CreatedTimeStamp,
                UserId = entity.UserId,
                ProductId = entity.ProductId,
                Comment = entity.Comment,
                Rating = entity.Rating,
                ReviewDate = entity.ReviewDate,
            };
        }
    }
}
