using EBS.Models.Model.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.DTO
{
    public class NotificationDTO : Notification
    {
        public new Guid Id { get; set; }
        public new bool IsDeleted { get; set; }
        public new DateTime CreatedTimeStamp { get; set; }
        public new DateTime UpdatedTimeStamp { get; set; }
        public new Guid? UserId { get; set; }
        public new Guid ProductId { get; set; }
        public new ProductDTO Product { get; set; }
        public new string Message { get; set; }
        public new DateTime NotificationDate { get; set; }
        public new bool IsRead { get; set; }
        public Notification MapDtoToModel(NotificationDTO dto)
        {
            return new Notification()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                UpdatedTimeStamp = dto.UpdatedTimeStamp,
                CreatedTimeStamp = dto.CreatedTimeStamp,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Product = dto.Product,
                Message = dto.Message,
                NotificationDate = dto.NotificationDate,
                IsRead = dto.IsRead
            };
        }

        public NotificationDTO MapModelToDto(Notification entity)
        {
            return new NotificationDTO()
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                UpdatedTimeStamp = entity.UpdatedTimeStamp,
                CreatedTimeStamp = entity.CreatedTimeStamp,
                UserId = entity.UserId,
                ProductId = entity.ProductId,
                Message = entity.Message,
                NotificationDate = entity.NotificationDate,
                IsRead = entity.IsRead
            };
        }
    }
}
