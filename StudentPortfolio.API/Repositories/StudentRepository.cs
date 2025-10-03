using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortfolio.API.Infrastructure;
using StudentPortfolio.API.Models.Dtos.Request;
using StudentPortfolio.API.Models.Entities;
using StudentPortfolio.API.Repositories.Base;

namespace StudentPortfolio.API.Repositories
{
    public interface IStudentsRepository : IRepo<Student>
    {
        Task<Student> Create(CreateStudentRequest request);
        Task<Student> Update(Guid id, UpdateStudentRequest request);
    }


    public class StudentsRepository(StudentPortfolioContext ctx)
        : BaseRepo<Student>(ctx), IStudentsRepository
    {
        public Task<Student> Create(CreateStudentRequest request)
        {
            return base.Create(request.Adapt<Student>());
        }

        public Task<Student> Update(Guid id, UpdateStudentRequest request)
        {
            return base.Update(id,
                (entity) =>
                {
                    entity = request.Adapt(entity);
                });
        }
    }
}
