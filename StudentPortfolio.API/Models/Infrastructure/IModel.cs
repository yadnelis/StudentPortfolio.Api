namespace StudentPortfolio.API.Models.Infrastructure
{
    public interface IModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
