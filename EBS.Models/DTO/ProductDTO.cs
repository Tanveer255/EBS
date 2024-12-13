using EBS.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.DTO
{
    public class ProductDTO : Product
    {
        public new Guid Id { get; set; }
        public new bool IsDeleted { get; set; }
        public new DateTime CreatedTimeStamp { get; set; }
        public new DateTime UpdatedTimeStamp { get; set; }
        public new Guid? UserId { get; set; }
        public new string Title { get; set; }
        public new string Description { get; set; }
        public new string Category { get; set; }
        public new string Condition { get; set; }
        public new DateTime ListingDate { get; set; }
        public new List<Review> Reviews { get; set; }
        public Product MapDtoToModel(ProductDTO dto)
        {
            return new Product()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                UpdatedTimeStamp = dto.UpdatedTimeStamp,
                CreatedTimeStamp = dto.CreatedTimeStamp,
                UserId = dto.UserId,
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Condition = dto.Condition,
                ListingDate = dto.ListingDate,
            };
        }

        public ProductDTO MapModelToDto(Product entity)
        {
            return new ProductDTO()
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                UpdatedTimeStamp = entity.UpdatedTimeStamp,
                CreatedTimeStamp = entity.CreatedTimeStamp,
                UserId = entity.UserId,
                Title = entity.Title,
                Description = entity.Description,
                Category = entity.Category,
                Condition = entity.Condition,
                ListingDate = entity.ListingDate,
            };
        }
    }
}
