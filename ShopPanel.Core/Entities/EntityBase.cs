using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Core.Entities
{
    public class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; } = "Undefined";
        public string? ModifiedBy { get; set; }
        public string? DeleteBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;

    }
}
