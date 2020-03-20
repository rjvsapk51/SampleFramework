﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities.Common
{
    [Table("hopper")]
    public class Hopper
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("identity")]
        public string Identity { get; set; }
        [Column("token")]
        public string Token { get; set; }
        [Column("individual_id")]
        public long IndividualId { get; set; }
        [Column("is_super_hopper")]
        public bool IsSuperHopper { get; set; }
        [Column("is_blocked")]
        public bool IsBlocked { get; set; }
        [Column("last_hopped")]
        public DateTime LastHopped { get; set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
        [Column("created_by")]
        public long CreatedBy { get; set; }
        [Column("updated_on")]
        public DateTime UpdatedOn { get; set; }
        [Column("updated_by")]
        public long UpdatedBy { get; set; }      
    }
}
