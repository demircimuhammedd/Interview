namespace Interview.Projections.JobService
{
    public class FringeBenefit : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
