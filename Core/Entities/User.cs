    using Core.Enums;

    namespace Core.Entities
    {
        public class User : BaseEntity
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public Gender Gender { get; set; }


            //Relationship
            public virtual ICollection<Address> Addresses { get; set; }
            public virtual Information Information { get; set; }
            public virtual ICollection<UserRole> Roles { get; set; }
        }
    }
