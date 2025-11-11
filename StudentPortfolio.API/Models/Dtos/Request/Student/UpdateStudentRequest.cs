using StudentPortfolio.API.Models.Dtos.Base;

namespace StudentPortfolio.API.Models.Dtos.Request.Student
{
    public class UpdateStudentRequest : IBaseModRequest
    {
        public string InstitutionalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly? StartDate { get; set; }
        public string Institution { get; set; }
    }
}
