namespace Core.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; set; }

        //Relationship
        public virtual User User { get; set; }
    }

}
