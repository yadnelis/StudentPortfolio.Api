using Microsoft.EntityFrameworkCore;
using StudentPortfolio.API.Infrastructure;
using StudentPortfolio.API.Models.Dtos.Request;
using StudentPortfolio.API.Models.Entities;
using StudentPortfolio.API.Models.Infrastructure;
using System.Linq.Expressions;

namespace StudentPortfolio.API.Repositories.Base
{
    public interface IRepo<TModel>
        where TModel : class, IDeletable, IModel
    {
        Task<TModel> Get(Guid id);
        IQueryable<TModel> GetPaginated(int skip, int take = 10);
        IQueryable<TModel> GetPaginated(Expression<Func<TModel, bool>> filter, int take = 10, int skip = 0);
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter);
        Task Delete(Guid id);
        Task<IEnumerable<TModel>> UpdateMany(Expression<Func<TModel, bool>> filter, Action<TModel> update);
        Task<TModel> Update(Expression<Func<TModel, bool>> filter, Action<TModel> update);
    }

    public abstract class BaseRepo<TModel>(StudentPortfolioContext ctx) : IRepo<TModel>
        where TModel : class, IDeletable, IModel
    {
        public virtual async Task<TModel> Get(Guid id)
            => await ctx.Set<TModel>()
                .Where(x => !x.Deleted)
                .FirstOrDefaultAsync(x => x.Id == id);

        public virtual IQueryable<TModel> GetPaginated(int skip, int take = 10)
            => ctx.Set<TModel>()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.DateCreated)
                .Skip(skip)
                .Take(take);

        public virtual IQueryable<TModel> GetPaginated(Expression<Func<TModel, bool>> filter, int take = 10, int skip = 0)
            => ctx.Set<TModel>()
                .Where(x => !x.Deleted)
                .Where(filter)
                .OrderBy(x => x.DateCreated)
                .Skip(skip)
                .Take(take);

        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter)
            => ctx.Set<TModel>()
                .Where(x => !x.Deleted)
                .Where(filter);


        public virtual async Task Delete(Guid id)
        {
            var updated = await ctx.Set<TModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
            updated.Deleted = true;
            ctx.Update(updated);
            await ctx.SaveChangesAsync();
        }

        public virtual async Task<TModel> Create(TModel entity)
        {
            entity.DateCreated = DateTimeOffset.Now;
            var createdEntity = ctx.Set<TModel>().Add(entity);
            await ctx.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public virtual async Task<IEnumerable<TModel>> UpdateMany(Expression<Func<TModel, bool>> filter, Action<TModel> update)
        {
            var updated = ctx.Set<TModel>().Where(x => !x.Deleted).Where(filter);
            await updated.ForEachAsync(update);
            ctx.Update(updated);
            await ctx.SaveChangesAsync();
            return await updated.ToListAsync();
        }

        public virtual async Task<TModel> Update(Expression<Func<TModel, bool>> filter, Action<TModel> update)
        {
            var updated = await ctx.Set<TModel>().Where(x => !x.Deleted).FirstOrDefaultAsync(filter);
            update.Invoke(updated);
            ctx.Update(updated);
            await ctx.SaveChangesAsync();
            return updated;
        }

        public virtual async Task<TModel> Update(Guid id, Action<TModel> update)
        {
            var updated = await ctx.Set<TModel>().Where(x => !x.Deleted).FirstOrDefaultAsync(x => x.Id == id);
            update.Invoke(updated);
            ctx.Update(updated);
            await ctx.SaveChangesAsync();
            return updated;
        }
    }
}
