using API_MySIRH.Interfaces;

namespace API_MySIRH.Entities
{
    public class EntityBase: IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Entity class that implement <see cref="IEntity"/> and inherit from the <see cref="Entity"/> base class
    /// </summary>
    /// <typeparam name="Tkey">type of key</typeparam>
    public abstract class EntityBase<Tkey> : EntityBase, IEntity<Tkey>
    {
        /// <summary>
        /// the id of the entity
        /// </summary>
        public Tkey Id { get; set; }
    }
}
