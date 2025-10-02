using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Entities
{
    public class AcknowledgementStudentOrganization : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public DateTimeOffset DateCreated {  get; set; }

        public Guid AcknowledgementId { get; set; }
        public Acknowledgement Acknowledgement { get; set; }
    }
}
