namespace Interview.Projections.JobService
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
