namespace Interview.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
