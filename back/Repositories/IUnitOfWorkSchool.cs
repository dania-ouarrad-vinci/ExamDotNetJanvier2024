
using back.Repositories;
using back.Entities;

namespace back.Repositories
{
    interface IUnitOfWorkSchool
    {
        IRepository<Student> StudentsRepository { get; }

    }
}