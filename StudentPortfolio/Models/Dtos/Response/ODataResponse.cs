namespace StudentPortfolio.Models.Dtos.Response
{
    public class ODataResponse<TModel>
    {
        public IQueryable<TModel> Data { get; set; }
        public bool LastPage { get; set; }
    }
}
