using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using StudentPortfolio.API.Infrastructure.Validation.Models;
using StudentPortfolio.API.Models.Dtos.Base;
using StudentPortfolio.API.Models.Entities;
using StudentPortfolio.API.Models.Infrastructure;
using StudentPortfolio.API.Repositories.Base;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentPortfolio.API.Infrastructure.Validation
{
    public interface IValidator<T, TCreate, TUpdate>
    {
        Task<ValidationResult<TCreate>> ValidateCreate(TCreate request);
        Task<ValidationResult<TUpdate>> ValidateUpdate(TUpdate request);
    }

    public class RequestValidator<TModel, TRequest>(IRepo<TModel> repo, TRequest request)
        where TRequest : IBaseModRequest where TModel : class, IDeletable, IModel
    {
        public IEnumerable<ValidationError> NotNull<TResult>(Expression<Func<TRequest, TResult>> selector)
        {
            var errors = new List<ValidationError>();
            var memberExpression = (MemberExpression)selector.Body;
            var propertyName = memberExpression.Member.Name;

            if (selector.Compile().Invoke(request) == null)
                errors.Add(new ValidationError
                {
                    Property = propertyName,
                    Message = "Must be defined."
                });

            return errors;
        }

        public async Task<IEnumerable<ValidationError>> MustBeUnique<TResult>(Expression<Func<TModel, TResult>> selector, TResult property)
        {
            var errors = new List<ValidationError>();

            var memberExpression = (MemberExpression)selector.Body;
            var propertyName = memberExpression.Member.Name;
            var parameter = Expression.Parameter(typeof(TModel));
            var selectionExpression = Expression.Invoke(selector, parameter);
            var comparisonValueExpression = Expression.Constant(property);
            var comparisonExpression = Expression.Equal(selectionExpression, comparisonValueExpression);
            var filterExpression = Expression.Lambda(comparisonExpression, parameter) as Expression<Func<TModel, bool>>;


            var exists = await repo.Get(filterExpression).FirstOrDefaultAsync();
            if (exists != null)
                errors.Add(new ValidationError
                {
                    Property = propertyName,
                    Message = "Must be unique."
                });

            return errors;
        }
    }
}
