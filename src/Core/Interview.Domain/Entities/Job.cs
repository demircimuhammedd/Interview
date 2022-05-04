namespace Interview.Domain.Entities
{
    public class Job : BaseEntity
    {
        public Guid CreatedById { get; set; }
        public string Description { get; set; }
        public DateTime EndedAt { get; set; }
        public short Rate { get; set; }
        public Guid? FringeBenefitId { get; set; }
        public Guid? WorkTypeId { get; set; }
        public decimal? Salary { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<FringeBenefit?> FringeBenefit { get; set; }
        public virtual ICollection<WorkType?> WorkType { get; set; }
    }
}
