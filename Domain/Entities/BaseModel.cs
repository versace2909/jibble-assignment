using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; } 
        public string UpdatedBy { get; set; }
    }
}