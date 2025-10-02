namespace StudentPortfolio.API.Models.Infrastructure
{
    public interface IDeletable
    {
        public bool Deleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
