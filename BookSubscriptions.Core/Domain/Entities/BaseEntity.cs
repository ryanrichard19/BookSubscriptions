using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSubscriptions.Core.Domain.Entities
{
    public class BaseEntity
    {
        private DateTime modified;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get => modified; set => modified = value; }
    }
}