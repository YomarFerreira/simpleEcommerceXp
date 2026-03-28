using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Properties;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UsuarioCriacao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public Status Status { get; set; }
    }
}
