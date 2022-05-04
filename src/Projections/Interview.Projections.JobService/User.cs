namespace Interview.Projections.JobService
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int JobQuantity { get; set; }


        public virtual ICollection<Job> Jobs { get; set; }
    }
}
