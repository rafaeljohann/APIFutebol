namespace Futebol.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int? Id { get; init; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}