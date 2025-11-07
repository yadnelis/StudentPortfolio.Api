namespace StudentPortfolio.API.Infrastructure.Validation.Models
{
    public struct ValidationError
    {
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
