using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Entities
{
    public class Acknowledgement : IDeletable, IModel
    {
        public Guid Id { get; set; }
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
        public bool Deleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public AcknowledgementCompetition AcknowledmentCompetition { get; set; }


        public AcknowledgementStudentOrganization AcknowledgementStudentOrganization { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
