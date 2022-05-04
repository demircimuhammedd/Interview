namespace Interview.Domain.Entities
{
    public class WorkType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
