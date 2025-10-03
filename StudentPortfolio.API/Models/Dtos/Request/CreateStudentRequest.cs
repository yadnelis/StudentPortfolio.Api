namespace StudentPortfolio.API.Models.Dtos.Request
{
    public class CreateStudentRequest
    {
        public string InstitutionalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly? StartDate { get; set; }
        public string Institution { get; set; }
    }
}
