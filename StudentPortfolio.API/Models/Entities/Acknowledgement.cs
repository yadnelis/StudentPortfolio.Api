using StudentPortfolio.API.Models.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortfolio.API.Models.Entities
{
    public class Acknowledgement : IDeletable, IModel
    {
        public Guid Id { get; set; }
        
        [Column(TypeName = "tinyint UNSIGNED")]
        public AcknowledgementType Type { get; set; }
        
        [Column(TypeName = "tinytext")]
        public string Place { get; set; }
        
        [Column(TypeName = "mediumtext")]
        public string Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        
        [Column(TypeName = "tinytext")]
        public string OtherType { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        [Column(TypeName = "tinyint UNSIGNED")]
        public uint? CompetitionPosition { get; set; }

        [Column(TypeName = "tinytext")]
        public string CompetitionName{ get; set; }
        
        [Column(TypeName = "tinytext")]
        public string StudentOrganizatonName { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
