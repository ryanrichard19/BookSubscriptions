using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSubscriptions.Infrastructure.Data.EntityFramework.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
