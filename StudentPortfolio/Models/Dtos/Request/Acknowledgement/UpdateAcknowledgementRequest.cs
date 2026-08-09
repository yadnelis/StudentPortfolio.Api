using StudentPortfolio.Models.Dtos.Base;
using StudentPortfolio.Models.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortfolio.Models.Dtos.Request.Acknowledgement
{
    public class UpdateAcknowledgementRequest : IBaseModRequest
    {
        public AcknowledgementType? Type { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public DateOnly? Date { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string OtherType { get; set; }
        public string Email { get; set; }
        public uint? CompetitionPosition { get; set; }
        public string CompetitionName { get; set; }
        public string StudentOrganizatonName { get; set; }
    }
}
