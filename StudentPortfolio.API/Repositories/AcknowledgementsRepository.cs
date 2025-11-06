using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortfolio.API.Infrastructure;
using StudentPortfolio.API.Models.Dtos.Request;
using StudentPortfolio.API.Models.Entities;
using StudentPortfolio.API.Repositories.Base;

namespace StudentPortfolio.API.Repositories
{
    public interface IAcknowledgementsRepository : IRepo<Acknowledgement> 
    {
        Task<Acknowledgement> Create(CreateAcknowledgementRequest request);
        Task<Acknowledgement> Update(Guid id, UpdateAcknowledgementRequest request);
    }


    public class AcknowledgementsRepository(StudentPortfolioContext ctx)
        : BaseRepo<Acknowledgement>(ctx), IAcknowledgementsRepository
    {
        public override IQueryable<Acknowledgement> IncludeRelatedEntities(IQueryable<Acknowledgement> query)
            => query.Include(x => x.Student);

        public Task<Acknowledgement> Create(CreateAcknowledgementRequest request)
        {
            return base.Create(request.Adapt<Acknowledgement>());
        }

        public Task<Acknowledgement> Update(Guid id, UpdateAcknowledgementRequest request)
        {
            return base.Update(id, 
                (entity) =>
                {
                    entity = request.Adapt(entity);
                });
            }
    }
}
