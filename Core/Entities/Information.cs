namespace Core.Entities
{
    public class Information : BaseEntity
    {
        public string Bio { get; set; }
        public string Website { get; set; }
        public int UserId { get; set; }

        //Relationship
        public virtual User User { get; set; }
    }

}
