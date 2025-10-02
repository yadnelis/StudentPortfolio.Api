namespace StudentPortfolio.API.Models.Dtos.Response
{
    public class GetStudentResponse
    {
        public Guid Id { get; set; }
        public string InstitutionalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly? StartDate { get; set; }
        public string Institution { get; set; }
    }
}
