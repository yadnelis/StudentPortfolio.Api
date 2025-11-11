using StudentPortfolio.API.Models.Dtos.Request.Acknowledgement;
using StudentPortfolio.API.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortfolio.API.Models.Dtos.Request.Student
{
    public class QueryStudentRequest
    {
        public Guid Id { get; set; }
        public string InstitutionalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly? StartDate { get; set; }
        public string Institution { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public ICollection<QueryAcknowledgementRequest> Acknowledgements { get; set; }
    }
}
