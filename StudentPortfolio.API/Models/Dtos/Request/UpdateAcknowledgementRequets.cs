using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Dtos.Request
{
    public class UpdateAcknowledgementRequets
    {
        public AcknowledgementType Type { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public DateOnly? Date { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string OtherType { get; set; }
        public string Email { get; set; }
        public UpdateAcknowledegementCompetitionRequest Competition { get; set; }
        public UpdateAcknowledgementStudentOrganizationRequest StudentOrganization { get; set; }
    }
}
