namespace Interview.Application.UseCases.Jobs.Queries.GetJobsWithPagination
{
    public class GetJobsWithPaginationQueryResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public short Rate { get; set; }
        public DateTime EndedAt { get; set; }
        public decimal Salary { get; set; }
    }
}
