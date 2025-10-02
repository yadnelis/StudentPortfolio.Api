using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Dtos.Response
{
    public class GetAcknowledgementResponse
    {

        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? CompetitionId { get; set; }
        public AcknowledgementType Type { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public DateOnly? Date { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string OtherType { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public GetStudentResponse Student { get; set; }
        public GetAcknowledgementCompetitionResponse Competition {  get; set; }
        public GetAcknowledgementStudentOrganizationResult StudentOrganization { get; set; }
    }
}

