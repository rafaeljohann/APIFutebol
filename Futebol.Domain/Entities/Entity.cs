namespace Futebol.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public long Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}