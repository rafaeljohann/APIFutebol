using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Futebol.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}