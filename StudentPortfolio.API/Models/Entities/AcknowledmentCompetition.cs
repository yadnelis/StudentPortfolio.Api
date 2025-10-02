using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Entities
{
    public class AcknowledmentCompetition : IModel
    {
        public Guid Id { get; set; }
        public int? Position {  get; set; }
        public int Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Guid AcknowledgementId { get; set; }
        public Acknowledgement Acknowledgement { get; set; }
    }
}
