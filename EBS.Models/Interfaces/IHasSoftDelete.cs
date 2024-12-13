using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.Models.Interfaces
{
    public interface IHasSoftDelete
    {
        public bool IsDeleted { get; set; }
        DateTime UpdatedTimeStamp { get; set; }
    }
}
