using StudentPortfolio.API.Models.Dtos.Request.Student;
using StudentPortfolio.API.Models.Entities;
using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Dtos.Request.Acknowledgement
{
    public class QueryAcknowledgementRequest
    {
        public AcknowledgementType Type { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string OtherType { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public uint? CompetitionPosition { get; set; }
        public string CompetitionName { get; set; }
        public string StudentOrganizatonName { get; set; }
        public Guid StudentId { get; set; }
        public QueryStudentRequest Student { get; set; }
    }
}