using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities.Generic
{
    public abstract class CommonAttribute
    {
        [Column("created_by")]
        public long CreatedBy { get; set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
        [Column("updated_by")]
        public long UpdatedBy { get; set; }
        [Column("updated_on")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
