namespace Interview.Domain.Entities
{
    public class FringeBenefit : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
