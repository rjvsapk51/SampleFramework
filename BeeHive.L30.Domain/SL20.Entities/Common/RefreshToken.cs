using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities.Common
{
    [Table("refresh_token")]
    public class RefreshTokens
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("hopper_id")]
        public long HopperId { get; set; }
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        [Column("expiration")]
        public DateTime Expiration { get; set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}
