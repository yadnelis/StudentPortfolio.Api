using StudentPortfolio.API.Models.Infrastructure;

namespace StudentPortfolio.API.Models.Entities
{
    public class Student : IModel, IDeletable
    {
        public Guid Id { get; set; }
        public string InstitutionalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly? StartDate { get; set; }
        public string Institution { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<Acknowledgement> Acknowledgements { get; set;}
    }
}
