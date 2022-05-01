namespace API_MySIRH.Interfaces
{

    /// <summary>
    /// a class that defines an entity
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
        /// <summary>
        /// the creation time of the model
        /// </summary>
        System.DateTime CreationDate { get; set; }

        /// <summary>
        /// the last time the model has been modified
        /// </summary>
        System.DateTime ModificationDate { get; set; } 
    }

    /// <summary>
    /// a class that defines an entity with a an id
    /// </summary>
    /// <typeparam name="Tkey">the type of the id</typeparam>
    public interface IEntity<Tkey> : IEntity
    {
        /// <summary>
        /// the id of the entity
        /// </summary>
        Tkey Id { get; set; }
    }
}
