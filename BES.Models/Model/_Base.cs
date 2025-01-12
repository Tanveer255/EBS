using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using EBS.Models.Interfaces;

namespace EBS.Models.Model
{
    public class _Base : IHasSoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public _Base()
        {
            this.CreatedTimeStamp = DateTime.UtcNow;
        }
    }
}
