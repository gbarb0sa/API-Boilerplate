namespace Core.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        //Relationship
        public virtual ICollection<UserRole> Users { get; set; }
    }

}
